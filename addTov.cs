using MaterialSkin.Controls;
//using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class addTov : MaterialForm
    {
        private static string p;
        public addTov()
        {
            InitializeComponent();
        }

        private void addTov_Load(object sender, EventArgs e)
        {
            view();
        }

        private void add()
        {
            try
            {
                SqlConnection connection = new SqlConnection(ConnectionDB.connection.ConnectionString);

                string sql = "INSERT INTO [склад] (имя,image,количество,цена) VALUES (@имя,@file,@количество,@цена)";

                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);

                // parameterize query to safeguard against sql injection attacks, etc. 
                cmd.Parameters.AddWithValue("@file", File.ReadAllBytes(@p));
                cmd.Parameters.AddWithValue("@количество", int.Parse(materialSingleLineTextField3.Text));
                cmd.Parameters.AddWithValue("@имя", comboBox1.Text);
                cmd.Parameters.AddWithValue("@цена", decimal.Parse(materialSingleLineTextField2.Text));
                cmd.ExecuteNonQuery();

                connection.Close();
                connection.Dispose();
            }
            catch { MessageBox.Show("Такой товар уже есть"); }


        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            add();
           
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)

            {
                p = openFileDialog.FileName;
                materialSingleLineTextField4.Text = p;
            }
        }

        private void materialSingleLineTextField1_Click(object sender, EventArgs e)
        {

        }

        private void materialSingleLineTextField2_Click(object sender, EventArgs e)
        {

        }

        private void materialSingleLineTextField3_Click(object sender, EventArgs e)
        {

        }

        private void materialSingleLineTextField4_Click(object sender, EventArgs e)
        {

        }

        private void materialDivider1_Click(object sender, EventArgs e)
        {
          
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void view()
        {
            ViewsCombobox combobox = new ViewsCombobox();
            combobox.Views_1("Имя рецепта", "Рецепты", comboBox1);
        
        
        }
        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
