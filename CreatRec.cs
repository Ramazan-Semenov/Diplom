using MaterialSkin.Controls;
//using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;
namespace WindowsFormsApp4
{
    public partial class CreatRec : MaterialForm
    {
        public CreatRec()
        {
            InitializeComponent();
            rep();
            viewscomb();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            sfdbg();
        }
        private void rep()
        {
           SqlConnection connection = new SqlConnection(ConnectionDB.connection.ConnectionString);


            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();

                SqlCommand dataAdapter = new SqlCommand("select [Имя рецепта] from [Рецепты] ", connection);
              
                SqlDataReader reader = dataAdapter.ExecuteReader();
                while (reader.Read())
                {
                    listBox1.Items.Add($"{reader[0]} ");

                }
                connection.Close();
                connection.Dispose();
            }
        }

        private void sfdbg()
        {
            SqlConnection connection = new SqlConnection(ConnectionDB.connection.ConnectionString);

            if (listBox1.SelectedItem.ToString() != null)
            {
                listBox2.Items.Clear();
                connection.Open();
                DataTable dataTable = new DataTable();
                SqlCommand dataAdapter = new SqlCommand("select Ингредиент from Ингредиенты where рецепт= '" + listBox1.SelectedItem.ToString() + "'", connection);
                SqlDataReader reader = dataAdapter.ExecuteReader();
                while (reader.Read())
                {
                    listBox2.Items.Add($"{reader[0]} ");

                }

                connection.Close();
                connection.Dispose();
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CreatRec_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void viewscomb()
        {
            ViewsCombobox viewsCombobox = new ViewsCombobox();
            viewsCombobox.Views_1("Наименование", "Товар", comboBox1);


        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(ConnectionDB.connection.ConnectionString);

            try
            {

                connection.Open();
               
                SqlCommand command = new SqlCommand("INSERT INTO [Ингредиенты](Ингредиент,рецепт) VALUES(@i,@r)", connection);
                command.Parameters.AddWithValue("i", comboBox1.Text);
                command.Parameters.AddWithValue("r", materialSingleLineTextField1.Text);
                command.ExecuteNonQuery();
               
                connection.Close();
                connection.Dispose();
                listBox3.Items.Add(materialSingleLineTextField1.Text+ "  "+comboBox1.Text);
                rep();
            }
            catch (Exception exp) { MessageBox.Show(exp.Message); connection.Close();
                connection.Dispose();
            }
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(ConnectionDB.connection.ConnectionString);

            try
            {
                connection.Open();
                SqlCommand command1 = new SqlCommand("INSERT INTO [Рецепты]([Имя рецепта]) VALUES(@rep)", connection);
                command1.Parameters.AddWithValue("@rep", materialSingleLineTextField1.Text);
                command1.ExecuteNonQuery();
                connection.Close();
                connection.Dispose();
                rep();
            }
            catch
            {
                connection.Close();
                connection.Dispose();
            }
        }
    }
}
