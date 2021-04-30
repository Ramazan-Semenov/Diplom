using MaterialSkin.Controls;
//using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Report : MaterialForm
    {
        public Report()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void rep()
        {
            SqlConnection connection = new SqlConnection(ConnectionDB.connection.ConnectionString);


            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();

                SqlCommand dataAdapter = new SqlCommand("select имя,количество from склад ", connection);
                /* DataSet dataSet = new DataSet();

                 dataAdapter.FillAsync(dataSet, "склад");*/
                // listBox1.DataSource = dataSet.Tables["склад"].DefaultView;
                SqlDataReader reader = dataAdapter.ExecuteReader();
                listBox1.Items.Add("Название     Количество");
                while (reader.Read())
                {
                    listBox1.Items.Add($"{reader[0]} " + $"{reader[1],13}");

                }
                connection.Close();
                connection.Dispose();
            }
        }

        private void Report_Load(object sender, EventArgs e)
        {
            rep();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
