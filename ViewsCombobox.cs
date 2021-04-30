using System.Data.SqlClient;
//using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    internal class ViewsCombobox: ConnectionDB
    {
        private readonly string column_Name_DisplayMember;
        private readonly string column_Name_ValueMember;
        private readonly string NameTable;
        private readonly ComboBox comboBox;
        private readonly ConnectionDB connetionDB=new ConnectionDB();
        public ViewsCombobox(string column_Name_DisplayMember, string column_Name_ValueMember, string NameTable, ComboBox comboBox)
        {

            this.column_Name_DisplayMember = column_Name_DisplayMember;
            this.column_Name_ValueMember = column_Name_ValueMember;
            this.NameTable = NameTable;
            this.comboBox = comboBox;
        }
        public ViewsCombobox()
        { }
        public void Views()
        {
            SqlCommand sqlCommand;
            DataTable dataTable;
            SqlDataAdapter sqlDataAdapter;
            string SqlCommandText = "SELECT " + " " + column_Name_DisplayMember + ", " + "" + column_Name_ValueMember + " " + " FROM " + "" + NameTable + " ";
            ConnectionDB.connection.Open();

            sqlCommand = new SqlCommand(SqlCommandText, ConnectionDB.connection);
            dataTable = new DataTable();
            sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dataTable);
            comboBox.DataSource = dataTable;
            comboBox.DisplayMember = column_Name_DisplayMember;
            comboBox.ValueMember = column_Name_ValueMember;
            comboBox.SelectedValue = column_Name_ValueMember;
            connection.Close();
            connection.Dispose();
        }
        public void Views_1( string column_Name_ValueMember, string NameTable, ComboBox comboBox)
        {
            SqlConnection connection = new SqlConnection(ConnectionDB.connection.ConnectionString);
            SqlCommand sqlCommand;
            DataTable dataTable;
            SqlDataAdapter sqlDataAdapter;
            string SqlCommandText = "SELECT "+ "[" + column_Name_ValueMember + "] " + " FROM " + "[" + NameTable + "] ";
            connection.Open();

            sqlCommand = new SqlCommand(SqlCommandText, connection);
            dataTable = new DataTable();
            sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dataTable);
            comboBox.DataSource = dataTable;
            comboBox.DisplayMember = column_Name_ValueMember;
            comboBox.ValueMember = column_Name_ValueMember;
            comboBox.SelectedValue = column_Name_ValueMember;
            connection.Close();
            connection.Dispose();
        }

    }
}
