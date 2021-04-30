using MaterialSkin.Controls;
using System;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class ConDB : MaterialForm
    {
        ConnectionDB connetionDB = new ConnectionDB();
        public ConDB()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            

        }

        private void DataSourcetextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void AttachDBFilenametextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ConnectTimeout_TextChanged(object sender, EventArgs e)
        {

        }

        private void ConDB_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           /* try
            {
                connetionDB.con(textBox3.Text, textBox2.Text);
                Close();
            }  
            catch { MessageBox.Show("Соединение не установлено", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }*/



        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
           /* string txt= @"server="+ textBox6.Text+";user="+ textBox5.Text + ";database="+ textBox4.Text+ ";password= " + textBox1.Text;
            ConnectionDB.connection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="+@"C:\Users\Roma\Desktop\БД и прога\отпр\Localdb.mdf"+";Integrated Security=True;Connect Timeout=30";// txt;
      //      ConnectionDB.kkk = txt.ToString();

            kassa kassa = new kassa();
            kassa.Show();
            ConDB conDB = new ConDB();
            conDB.Close();*/
        
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
          /*  try
            {
                connetionDB.con(DataSourcetextBox.Text, AttachDBFilenametextBox.Text, InitialCatalog.Text, ConnectTimeout.Text);
                Close();

            }
            catch { MessageBox.Show("Соединение не установлено", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }*/

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

         
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string txt =  "Data Source =" + textBox2.Text + @";AttachDbFilename=" + /*@textBox7.Text*/ Directory.GetCurrentDirectory()+"\\" + textBox3.Text + ";Integrated Security=True;Connect Timeout=30";

            ConnectionDB.connection.ConnectionString = txt.ToString();//@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + @"C:\Users\Roma\Desktop\БД и прога\отпр\Localdb.mdf" + ";Integrated Security=True;Connect Timeout=30";// txt;
                                                                                                                                                                                                                       //      ConnectionDB.kkk = txt.ToString();

            kassa kassa = new kassa();
            kassa.Show();
            ConDB conDB = new ConDB();
            conDB.Close();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
