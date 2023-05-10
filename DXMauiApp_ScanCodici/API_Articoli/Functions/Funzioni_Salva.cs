using Dapper;
using System.Data.SqlClient;

namespace API_Articoli.Functions
{
    public class Funzioni_Salva
    {
        private static readonly string ConnString = "Server=svr-app-02,1500; Database=smartoffi_eur; UID=sa; PWD=Pcplanet.1208";

        public static void SaveQuantity(int Qta, int Id_DocTes, string CodArt,out string error)
        {
            string cSql = @"update DocRig set Quantita = @Qta where Id_DocTes = @Id_DocTes and CodArt = @CodArt";
            Execute(cSql, out error, new { Qta, Id_DocTes, CodArt });
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
