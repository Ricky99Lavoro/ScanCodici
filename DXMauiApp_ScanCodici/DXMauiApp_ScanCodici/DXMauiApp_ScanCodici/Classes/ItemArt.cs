using DevExpress.Maui.Controls;
using DXMauiApp_ScanCodici.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXMauiApp_ScanCodici.Classes
{
    public class ItemArt
    {
        public string Description { get; set; }
        public string CodArt { get; set; }
        public int Quantita { get; set; }
        public int Quantitare { get; set; }
        public int QuantitaPre { get; set; }
        public string Alias { get; set; }

        public string CodCliFor { get; set; }

        public ItemArt(string description, string codArt, int quantity, int quantitare, int quantitapre, string alias)
        {
            Description = description;
            CodArt = codArt;
            Quantita = quantity;
            Quantitare = quantitare;
            QuantitaPre = quantitapre;
            Alias = alias;
        }
    }
    public class Riga_ItemsData
    {
        void GenerateRigaItems()
        {
            List<ItemArt> riga_Item = new List<ItemArt>();

            riga_Item = Functions.Funzioni_Get.GetItems(LoginPage._textEditCodeLogin, out string error);

            ItemsRiga = new ObservableCollection<ItemArt>(riga_Item);
        }

        public ObservableCollection<ItemArt> ItemsRiga { get; private set; }

        public Riga_ItemsData()
        {
            GenerateRigaItems();
        }
    }
}
