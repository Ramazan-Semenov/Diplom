using MaterialSkin.Controls;
//using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class kassa : MaterialForm
    {
        public kassa()
        {
            InitializeComponent();
        }

        private void kassa_Load(object sender, EventArgs e)
        {
            reload();
        }

        private decimal cena()
        {
            decimal res;

            // MySqlConnection connection = new MySqlConnection(@"server=localhost;user=root;database=сеть_ресторанов;password=root");
            SqlConnection connection = new SqlConnection(ConnectionDB.connection.ConnectionString);



            connection.Open();
                    SqlCommand mySqlCommand = new SqlCommand("SELECT [цена] FROM [склад] WHERE [idсклад]=" + "'" + UserControl1.id + "'", connection);
                    res = (decimal)mySqlCommand.ExecuteScalar();
                    connection.Close();
                    connection.Dispose();
                    return res;
               
               
            
        
        }

        private string name()
        {


            SqlConnection connection = new SqlConnection(ConnectionDB.connection.ConnectionString);

            string res;

            connection.Open();
            SqlCommand mySqlCommand = new SqlCommand("SELECT [имя] FROM [склад] WHERE [idсклад]=" + "'" + UserControl1.id + "'", connection);
            res = (string)mySqlCommand.ExecuteScalar();
            connection.Close();
            connection.Dispose();
            return res;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
           
        }

        private void reload()
        {

            userControl11.ListViewProducts.ItemsSource = LoadDB().DefaultView;

        }

 
        public DataTable LoadDB()
        {
            DataSet dataSet = new DataSet();

            //   MySqlConnection connection = new MySqlConnection(@"server=localhost;user=root;database=сеть_ресторанов;password=root");
            try
            {
                SqlConnection connection = new SqlConnection(ConnectionDB.connection.ConnectionString);


                connection.Open();

                SqlDataAdapter SqlDataAdapter = new SqlDataAdapter("SELECT * FROM " + "[" + "склад" + "]", connection);
                SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(SqlDataAdapter);
                //  sqlCommandBuilder.GetDeleteCommand();
                SqlDataAdapter.Fill(dataSet, "склад");
                dataSet.Tables[0].Locale = System.Globalization.CultureInfo.InvariantCulture;
                connection.Close();
                connection.Dispose();
                return dataSet.Tables[0];
            }
            catch(Exception exp) { MessageBox.Show(exp.Message); return dataSet.Tables[0]; }


        }

        private void button2_Click(object sender, EventArgs e)
        {
          
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void elementHost1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(ConnectionDB.connection.ConnectionString);

            try
            {




                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT количество from [склад] WHERE [idсклад]= "+ UserControl1.id, connection);
              int x=(int)  sqlCommand.ExecuteScalar();
                if (x > 0)
                {


                    SqlCommand mySqlCommand = new SqlCommand("UPDATE [склад] SET [количество]=[количество]-1 WHERE [idсклад]=" + "'" + UserControl1.id + "'", connection);
                    mySqlCommand.ExecuteNonQuery();
                    connection.Close();

                    connection.Dispose();


                    Form1 form = new Form1(cena(), name(), UserControl1.id);
                    form.ShowDialog();

                    reload();
                }
                else
                {
                    MessageBox.Show("Товар закончился");
                    reload();
                    connection.Close();

                    connection.Dispose();
                }
            }
            catch(Exception exp) { MessageBox.Show(exp.Message); }
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            addTov addTov = new addTov();
            addTov.ShowDialog();
            reload();
        }

        private void materialRaisedButton3_Click(object sender, EventArgs e)
        {
            Report report = new Report();
            report.Show();
        }

        private void materialRaisedButton4_Click(object sender, EventArgs e)
        {
            RepTable repTable = new RepTable();
            repTable.ShowDialog();
        }

        private void materialRaisedButton5_Click(object sender, EventArgs e)
        {
            CreatRec creatRec = new CreatRec();
            creatRec.ShowDialog();
        }

        private void materialRaisedButton6_Click(object sender, EventArgs e)
        {
            DB dB = new DB();
            dB.ShowDialog();
            dB.Dispose();
        }

        private void materialRaisedButton7_Click(object sender, EventArgs e)
        {
            ConDB conDB = new ConDB();
            conDB.ShowDialog();
        }
    }
}
