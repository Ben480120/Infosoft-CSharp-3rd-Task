using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Infosoft_CSharp_3rd_Task
{
    public partial class RentalForm : Form
    {
        string connectionString = "server=localhost;database=bvs_db;uid=root;pwd=;";

        private void RentalForm_Load(object sender, EventArgs e)
        {
            LoadCustomers();
            LoadVideos();
            LoadRentals();
        }

        private void LoadCustomers()
        {
            cmbCustomer.Items.Clear(); 
            string query = "SELECT customer_id, customer_name FROM customers";

            using (MySqlConnection conn = new MySqlConnection("server=localhost;database=bvs_db;uid=root;pwd=;"))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32("customer_id");
                    string name = reader.GetString("customer_name");
                    cmbCustomer.Items.Add(new ComboBoxItem(name, id.ToString()));
                }

                conn.Close();
            }

            if (cmbCustomer.Items.Count > 0)
                cmbCustomer.SelectedIndex = 0;
        }

        //Load Data into DGV
        private void LoadRentals()
        {
            dgvRentals.Rows.Clear();
            dgvRentals.Columns.Clear();

            dgvRentals.Columns.Add("rental_id", "Rental ID");
            dgvRentals.Columns.Add("customer", "Customer");
            dgvRentals.Columns.Add("video", "Video");
            dgvRentals.Columns.Add("rent_date", "Rent Date");
            dgvRentals.Columns.Add("due_date", "Due Date");
            dgvRentals.Columns.Add("return_date", "Return Date");

            string query = @"
            SELECT 
                r.rental_id, 
                c.customer_name AS customer,
                v.title AS video, 
                r.rent_date, 
                r.due_date, 
                r.return_date
            FROM rentals r
            JOIN customers c ON r.customer_id = c.customer_id
            JOIN videos v ON r.video_id = v.video_id
            ORDER BY r.rent_date DESC";  //Show most recent rentals first

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new MySqlCommand(query, conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    dgvRentals.Rows.Add(
                        reader["rental_id"].ToString(),
                        reader["customer"].ToString(),
                        reader["video"].ToString(),
                        Convert.ToDateTime(reader["rent_date"]).ToString("yyyy-MM-dd"),
                        Convert.ToDateTime(reader["due_date"]).ToString("yyyy-MM-dd"),
                        reader["return_date"] == DBNull.Value
                            ? ""
                            : Convert.ToDateTime(reader["return_date"]).ToString("yyyy-MM-dd")
                    );
                }
            }
        }

        private void LoadVideos()
        {
            cmbVideo.Items.Clear(); 
            string query = "SELECT video_id, title FROM videos";

            using (MySqlConnection conn = new MySqlConnection("server=localhost;database=bvs_db;uid=root;pwd=;"))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32("video_id");
                    string title = reader.GetString("title");
                    cmbVideo.Items.Add(new ComboBoxItem(title, id.ToString()));
                }

                conn.Close();
            }

            if (cmbVideo.Items.Count > 0)
                cmbVideo.SelectedIndex = 0;
        }


        public RentalForm()
        {
            InitializeComponent();
            LoadCustomers();
            LoadVideos();
        }

        private void btnRent_Click(object sender, EventArgs e)
        {
            if (cmbCustomer.SelectedItem == null || cmbVideo.SelectedItem == null)
            {
                MessageBox.Show("Please select a customer and a video.");
                return;
            }

            var customer = (ComboBoxItem)cmbCustomer.SelectedItem;
            var video = (ComboBoxItem)cmbVideo.SelectedItem;
            int days = (int)numDays.Value;

            DateTime rentDate = DateTime.Now;
            DateTime dueDate = rentDate.AddDays(days);

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new MySqlCommand(@"INSERT INTO rentals (customer_id, video_id, rent_date, due_date)
                                     VALUES (@cust, @vid, @rent, @due)", conn);

                cmd.Parameters.AddWithValue("@cust", customer.Value);
                cmd.Parameters.AddWithValue("@vid", video.Value);
                cmd.Parameters.AddWithValue("@rent", rentDate);
                cmd.Parameters.AddWithValue("@due", dueDate);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Rental added.");
            }

            LoadRentals(); 

            
            cmbCustomer.SelectedIndex = 0;
            cmbVideo.SelectedIndex = 0;
            numDays.Value = 1;
        }
        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (dgvRentals.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a rental to return.");
                return;
            }

            int rentalId = Convert.ToInt32(dgvRentals.SelectedRows[0].Cells[0].Value); 

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new MySqlCommand("UPDATE rentals SET return_date = CURDATE() WHERE rental_id = @id", conn);
                cmd.Parameters.AddWithValue("@id", rentalId);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Video returned.");
            LoadRentals(); 
        }

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvRentals_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string selectedCustomer = dgvRentals.Rows[e.RowIndex].Cells["customer"].Value.ToString();
                string selectedVideo = dgvRentals.Rows[e.RowIndex].Cells["video"].Value.ToString();

                cmbCustomer.SelectedItem = cmbCustomer.Items
                    .Cast<ComboBoxItem>()
                    .FirstOrDefault(item => item.Text == selectedCustomer);

                cmbVideo.SelectedItem = cmbVideo.Items
                    .Cast<ComboBoxItem>()
                    .FirstOrDefault(item => item.Text == selectedVideo);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvRentals.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a rental to edit.");
                return;
            }

            int rentalId = Convert.ToInt32(dgvRentals.SelectedRows[0].Cells["rental_id"].Value);

            var customer = (ComboBoxItem)cmbCustomer.SelectedItem;
            var video = (ComboBoxItem)cmbVideo.SelectedItem;
            int days = (int)numDays.Value;

            DateTime rentDate = DateTime.Now;
            DateTime dueDate = rentDate.AddDays(days);

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new MySqlCommand("UPDATE rentals SET customer_id = @cust, video_id = @vid, rent_date = @rent, due_date = @due WHERE rental_id = @id", conn);
                cmd.Parameters.AddWithValue("@cust", customer.Value);
                cmd.Parameters.AddWithValue("@vid", video.Value);
                cmd.Parameters.AddWithValue("@rent", rentDate);
                cmd.Parameters.AddWithValue("@due", dueDate);
                cmd.Parameters.AddWithValue("@id", rentalId);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Rental updated.");
            LoadRentals();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvRentals.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a rental to delete.");
                return;
            }

            int rentalId = Convert.ToInt32(dgvRentals.SelectedRows[0].Cells["rental_id"].Value);

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new MySqlCommand("DELETE FROM rentals WHERE rental_id = @id", conn);
                cmd.Parameters.AddWithValue("@id", rentalId);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Rental deleted.");
            LoadRentals();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        //Search Function
        private void SearchRentals(string searchText)
        {
            dgvRentals.Rows.Clear();
            dgvRentals.Columns.Clear();

            dgvRentals.Columns.Add("rental_id", "Rental ID");
            dgvRentals.Columns.Add("customer", "Customer");
            dgvRentals.Columns.Add("video", "Video");
            dgvRentals.Columns.Add("rent_date", "Rent Date");
            dgvRentals.Columns.Add("due_date", "Due Date");
            dgvRentals.Columns.Add("return_date", "Return Date");

            string query = @"SELECT r.rental_id, c.customer_name AS customer,
                     v.title AS video, r.rent_date, r.due_date, r.return_date
                     FROM rentals r
                     JOIN customers c ON r.customer_id = c.customer_id
                     JOIN videos v ON r.video_id = v.video_id
                     AND (c.customer_name LIKE @search OR v.title LIKE @search)";

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@search", "%" + searchText + "%");

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dgvRentals.Rows.Add(
                        reader["rental_id"].ToString(),
                        reader["customer"].ToString(),
                        reader["video"].ToString(),
                        Convert.ToDateTime(reader["rent_date"]).ToString("yyyy-MM-dd"),
                        Convert.ToDateTime(reader["due_date"]).ToString("yyyy-MM-dd"),
                        reader["return_date"] == DBNull.Value ? "" : Convert.ToDateTime(reader["return_date"]).ToString("yyyy-MM-dd")
                    );
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            if (!string.IsNullOrEmpty(keyword))
            {
                SearchRentals(keyword);
            }
            else
            {
                LoadRentals(); // Show all if empty
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch.PerformClick(); // Simulates clicking the Search button
                e.SuppressKeyPress = true; // Optional: prevent ding sound
            }
        }

        private void RentalForm_Load_1(object sender, EventArgs e)
        {
            LoadRentals();
        }
    }
}
