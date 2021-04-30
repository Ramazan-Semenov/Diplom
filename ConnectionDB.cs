//using MySql.Data.MySqlClient;
using System.Data.SqlClient;
namespace WindowsFormsApp4
{
    internal class ConnectionDB
    {
        protected SqlCommandBuilder  sqlCommandBuilder = null;
        protected SqlDataAdapter SqlDataAdapter = null;
        //  @"server=localhost;user=root;database=dipbd;password=root";
        public  static  string kkk { get; set; }

        public static SqlConnection connection = new SqlConnection(kkk);

       /* public void con(string DataSourcetxt, string AttachDBFilenametxt, string InitialCatalogtxt, string ConnectTimeouttxt)
        {
            connection = new MySqlConnection(
                new MySqlConnectionStringBuilder()
                {
                    DataSource = @DataSourcetxt,
                    AttachDBFilename = @AttachDBFilenametxt,
                    InitialCatalog = @InitialCatalogtxt,
                    IntegratedSecurity = true,
                    ConnectTimeout = int.Parse(ConnectTimeouttxt),

                }.ConnectionString);

        }*/
     
        public void con(string DataSourcetxt, string AttachDBFilenametxt, string InitialCatalogtxt, string ConnectTimeouttxt)
        {
            connection = new SqlConnection(
                new SqlConnectionStringBuilder()
                {
                    DataSource = @DataSourcetxt,
                    AttachDBFilename = @AttachDBFilenametxt,
                    InitialCatalog = @InitialCatalogtxt,
                    IntegratedSecurity = true,
                    ConnectTimeout = int.Parse(ConnectTimeouttxt),

                }.ConnectionString);

        }



    }
}
