using Dapper;
using DXMauiApp_ScanCodici.Classes;
using DXMauiApp_ScanCodici.Helpers;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXMauiApp_ScanCodici.Functions
{
    public class Funzioni_Get
    {
        public static List<ItemArt> GetItems(int Id_DocTes, out string error)
        {
            error = null;
            var client = new RestClient(oApp.baseurl + "Articoli?Id_DocTes=" + Id_DocTes);
            if(client == null)
            {
                error = $"Client null";
                return new List<ItemArt>();
            }
            var request = new RestRequest();
            request.Method = Method.Get;
            request.AddHeader("Accept", "*/*");
            RestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var content = response.Content;
                var item = JsonConvert.DeserializeObject<List<ItemArt>>(content);
                var list = item.ToList();
                error = $"Nessun Errore: {response.StatusCode} - {response.StatusDescription} - {list.Count} - {response.Content} + {oApp.baseurl + "Articoli?Id_DocTes=" + Id_DocTes}";
                return list;
            }
            else
            {
                var content = response.Content;
                error = $"Errore inserimento Articolo: {response.StatusCode} - {response.StatusDescription} - {response.Content} + {oApp.baseurl + "Articoli?Id_DocTes=" + Id_DocTes}";
            }
            var statusCode = (int)response.StatusCode;

            return new List<ItemArt>();
        }
    }
}
