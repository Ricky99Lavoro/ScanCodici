using API_Articoli.Models;
using Dapper;
using System.Data.SqlClient;

namespace API_Articoli.Functions
{
    public class Funzioni_Get
    {
        private static readonly string ConnString = "Server=svr-app-02,1500; Database=smartoffi_eur; UID=sa; PWD=Pcplanet.1208";

        public static List<ItemArt> GetItems(int Id_DocTes, out string error)
        {
            string cSql = @"select
                                Id_DocRig,
                                DocRig.Codart,
                                DesDocRig as Description,
                                Quantitare,
                                Quantita,
                                0 QuantitaPre,
                                Alias
                            from DocRig
                            left join artalias on DocRig.Codart = artalias.CodArt
                            where Id_DocTes = @Id_DocTes  --1506045 or Id_DocTes = 1506044 or Id_DocTes = 1506043 or Id_DocTes = 1506042 ";
            var list = GetList<ItemArt>(cSql, out error, new { Id_DocTes });
            return list;
        }


        private static List<T> GetList<T>(string cSql, out string error, object par = null)
        {
            error = null;
            List<T> retList = default;
            try
            {
                using (var db = new SqlConnection(ConnString))
                {
                    retList = db.Query<T>(cSql, par).ToList();
                }
            }
            catch (Exception ex)
            {
                error = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
            return retList;
        }
    }
}
