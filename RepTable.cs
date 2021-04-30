using MaterialSkin.Controls;
//using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class RepTable :MaterialForm
    {
        public RepTable()
        {
            InitializeComponent();
            report();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void report()
        {
            try
            {
                SqlConnection connection = new SqlConnection(ConnectionDB.connection.ConnectionString);
                DataSet ds = new DataSet();
                string txtquery = "SELECT [Приход товара].[Наименование поставщика] AS 'Приход товара'," +
                    " [Приход товара].[Количество товара] ," +
                    " [Приход товара].[Единица измерения]," +
                    " [Приход товара].[Цена за единицу товара] * [Приход товара].[Количество товара] AS 'Цена'," +
                    " [Приход товара].[Наименование поставщика] AS 'Cписанные товары'," +
                    " [Приход товара].[ФИО принявшего товар]," +
                    " [Расход товара].[Наименование товара] AS 'Cписанные товары'," +
                    " [Расход товара].[Количество товара]," +
                    " [Расход товара].[Цена за единицу товара]*[Расход товара].[Количество товара] AS 'Сумма списания'," +
                    " [Товар].Количество " +
                    " FROM [Товар] " +
                    " JOIN [Приход товара] ON Товар.Наименование=[Приход товара].[Наименование товара]" +
                    " JOIN [Расход товара] ON [Расход товара].[Наименование товара]= [Товар].[Наименование]";




                SqlDataAdapter dataAdapter = new SqlDataAdapter(txtquery, connection);
                //Вторым параметром ты присваиваешь имя для текущей таблицы в датасете
                dataAdapter.Fill(ds, "Товар");
                //Здесь указываешь имя нужной таблицы            
                dataGridView1.DataSource = ds.Tables["Товар"];

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {

                ConnectionDB.connection.Close();
            }
        }

        private void RepTable_Load(object sender, EventArgs e)
        {

            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView1.BackgroundColor = Color.White;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;


        }
    }
}
