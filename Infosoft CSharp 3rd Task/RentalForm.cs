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
            cmbCustomer.Items.Clear(); // Clear existing items
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

            string query = @"SELECT r.rental_id, c.customer_name AS customer,
                     v.title AS video, r.rent_date, r.due_date, r.return_date
              FROM rentals r
              JOIN customers c ON r.customer_id = c.customer_id
              JOIN videos v ON r.video_id = v.video_id
              WHERE r.return_date IS NULL";

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
                        reader["return_date"] == DBNull.Value ? "" : Convert.ToDateTime(reader["return_date"]).ToString("yyyy-MM-dd")
                    );
                }
            }
        }

        private void LoadVideos()
        {
            cmbVideo.Items.Clear(); // Clear existing items
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

            LoadRentals(); // Refresh grid

            // ✅ Reset the form selections here:
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

            int rentalId = Convert.ToInt32(dgvRentals.SelectedRows[0].Cells[0].Value); // rental_id

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new MySqlCommand("UPDATE rentals SET return_date = CURDATE() WHERE rental_id = @id", conn);
                cmd.Parameters.AddWithValue("@id", rentalId);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Video returned.");
            LoadRentals(); // Refresh list
        }

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
