using DXMauiApp_ScanCodici.Helpers;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXMauiApp_ScanCodici.Functions
{
    public class Funzioni_Table
    {
        public static void DropTable_P_Items_Maui(out string error)
        {
            error = null;
            var client = new RestClient(oApp.baseurl + "Documenti/Drop");
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
        public static void CreateTable_P_Items_Maui(out string error)
        {
            error = null;
            var client = new RestClient(oApp.baseurl + "Documenti/Create");
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
        public static void InsertTable_P_Items_Maui(int Id_DocRig, string Codart, string DesDocRig, int Quantitare, int Quantita, int QuantitaPre, string Alias, out string error)
        {
            error = null;
            var client = new RestClient(oApp.baseurl + $"Documenti?Id_DocRig={Id_DocRig}&Codart={Codart}&DesDocRig={DesDocRig}&Quantitare={Quantitare}&Quantita={Quantita}&QuantitaPre={QuantitaPre}&Alias={Alias}");
            var request = new RestRequest();
            request.Method = Method.Post;
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
