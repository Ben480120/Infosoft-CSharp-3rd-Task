using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Infosoft_CSharp_3rd_Task
{
    public partial class VideoForm : Form
    {
        string connectionString = "server=localhost;database=bvs_db;uid=root;pwd=;";
        public VideoForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string query = "INSERT INTO videos (title, category, quantity_in, quantity_out, rental_days_allowed) VALUES (@title, @category, @quantity_in, @quantity_out, @rental_days_allowed)";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@title", txtVideoTitle.Text);
                cmd.Parameters.AddWithValue("@category", cmbCategory.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@quantity_in", txtQuantityIn.Text);
                cmd.Parameters.AddWithValue("@quantity_out", txtQuantityOut.Text);
                cmd.Parameters.AddWithValue("@rental_days_allowed", txtRentalDaysAllowed.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Video added successfully!");

                LoadVideos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                if (dgvVideos.SelectedRows.Count > 0)
                {
                    int videoId = Convert.ToInt32(dgvVideos.SelectedRows[0].Cells[0].Value);
                    string query = "UPDATE videos SET title = @title, category = @category, quantity_in = @quantity_in, quantity_out = @quantity_out, rental_days_allowed = @rental_days_allowed WHERE video_id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@title", txtVideoTitle.Text);
                    cmd.Parameters.AddWithValue("@category", cmbCategory.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@quantity_in", txtQuantityIn.Text);
                    cmd.Parameters.AddWithValue("@quantity_out", txtQuantityOut.Text);
                    cmd.Parameters.AddWithValue("@rental_days_allowed", txtRentalDaysAllowed.Text);
                    cmd.Parameters.AddWithValue("@id", videoId);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Video updated successfully!");
                   
                    LoadVideos();
                }
                else
                {
                    MessageBox.Show("Please select a video to edit.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                if (dgvVideos.SelectedRows.Count > 0)
                {
                    int videoId = Convert.ToInt32(dgvVideos.SelectedRows[0].Cells[0].Value);
                    string query = "DELETE FROM videos WHERE video_id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@id", videoId);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Video deleted successfully!");
               
                    LoadVideos();
                }
                else
                {
                    MessageBox.Show("Please select a video to delete.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        private void LoadVideos()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string query = "SELECT * FROM videos";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvVideos.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtVideoTitle.Clear();
            cmbCategory.SelectedIndex = -1; 
            txtQuantityIn.Clear();
            txtQuantityOut.Clear();
            txtRentalDaysAllowed.Clear();
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
