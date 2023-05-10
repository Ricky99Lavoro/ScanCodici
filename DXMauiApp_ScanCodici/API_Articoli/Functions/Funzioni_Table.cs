using Dapper;
using System.Data.SqlClient;

namespace API_Articoli.Functions
{
    public class Funzioni_Table
    {
        private static readonly string ConnString = "Server=svr-app-02,1500; Database=smartoffi_eur; UID=sa; PWD=Pcplanet.1208";

        public static void DropTableP_Items(out string error)
        {
            string cSql = @"IF OBJECT_ID('dbo.P_Items', 'U') IS NOT NULL
                            DROP TABLE dbo.P_Items;";
            Execute(cSql, out error, null);
        }

        public static void CreateTableP_Items(out string error) {
            string cSql = @"IF OBJECT_ID('dbo.P_Items', 'U') IS NOT NULL
                            DROP TABLE dbo.P_Items;
                            CREATE TABLE P_Items (
                                Id_DocRig int,
                                Codart varchar(255),
                                DesDocRig varchar(255),
                                Quantitare int,
                                Quantita int,
                                QuantitaPre int,
                                Alias varchar(255)
                            )";
            Execute(cSql, out error, null);
        }

        public static void InsertTableP_Items(int Id_DocRig, string Codart, string DesDocRig, int Quantitare, int Quantita, int QuantitaPre, string Alias, out string error)
        {
            string cSql = @"INSERT INTO P_Items (Id_DocRig, Codart, DesDocRig, Quantitare, Quantita, QuantitaPre, Alias)
                            VALUES (@Id_DocRig, @Codart, @DesDocRig, @Quantitare, @Quantita, @QuantitaPre, @Alias);";
            Execute(cSql, out error, new { Id_DocRig, Codart, DesDocRig, Quantitare, Quantita, QuantitaPre, Alias });
        }

        private static void Execute(string cSql, out string error, object par = null)
        {
            error = null;
            try
            {
                using (var conn = new SqlConnection(ConnString))
                {
                    conn.Execute(cSql, par);
                }
            }
            catch (Exception ex)
            {
                error = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
        }
    }
}