using DXMauiApp_ScanCodici.Helpers;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXMauiApp_ScanCodici.Functions
{
    public class Funzioni_Salva
    {
        public static void PutItems(int Qta, int Id_DocTes, string CodArt, out string error)
        {
            error = null;
            var client = new RestClient(oApp.baseurl + "Articoli?Id_DocTes=" + Id_DocTes);
            var request = new RestRequest();
            request.Method = Method.Put;
            request.AddHeader("Accept", "*/*");
            RestResponse response = client.Execute(request);
            if (response.IsSuccessful)
            {
                var content = response.Content;
            }
            else
            {
                var content = response.Content;
                error = $"Errore inserimento Articolo: {response.StatusCode} - {response.StatusDescription} - {response.Content}";
            }
        }
    }
}
