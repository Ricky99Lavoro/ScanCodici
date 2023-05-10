using DevExpress.Maui.DataGrid;
using DXMauiApp_ScanCodici.Functions;
using DXMauiApp_ScanCodici.Pages;
using DXMauiApp_ScanCodici.Classes;
using Microsoft.Maui.Layouts;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;
using DevExpress.Maui.Controls;
using DevExpress.Utils;
using System.Collections.ObjectModel;
using DevExpress.Maui.Core.Internal;
using DevExpress.CodeParser;
using System.Diagnostics;

namespace DXMauiApp_ScanCodici
{
    public partial class MainPage : ContentPage
    {
        bool CheckQuantity = false;
        public int Id_DocTes;
        List<ItemArt> InitialListItem = new List<ItemArt>();

        public MainPage(int _Id_DocTes)
        {
            Id_DocTes = _Id_DocTes;
            InitializeComponent();
            ObservableCollection<ItemArt> tempItem = grid.ItemsSource as ObservableCollection<ItemArt>;
            InitialListItem = tempItem.ToList();
        }

        private void textEditCode_Completed(object sender, EventArgs e)
        {
            CheckNewItem();
        }

        private void Button_AddNewClicked(object sender, EventArgs e)
        {
            CheckNewItem();
        }

        private void CheckNewItem()
        {
            ObservableCollection<ItemArt> tempItem1 = grid.ItemsSource as ObservableCollection<ItemArt>;
            List<ItemArt> list = tempItem1.ToList();

            ObservableCollection<ItemArt> tempItem = grid.ItemsSource as ObservableCollection<ItemArt>;
            List<ItemArt> itemArtList = tempItem.ToList();


            if (!string.IsNullOrWhiteSpace(textEditCode.Text))
            {
                foreach (var item in itemArtList)
                {
                    if (item.CodArt.TrimEnd() == textEditCode.Text || item.Alias.TrimEnd() == textEditCode.Text)
                    {
                        item.QuantitaPre += 1;
                        item.Quantitare -= 1;
                        CheckQuantity = true;
                    }
                }
                if (CheckQuantity == false)
                {
                    itemArtList.Add(new ItemArt("Descrizione Mancante", textEditCode.Text, 0, -1, 1, "Alias Mancante"));
                }

                CheckQuantity = false;
                grid.ItemsSource = null;
                grid.ItemsSource = itemArtList.ToObservableCollection();

                textEditCode.Text = string.Empty;
            }
        }

        private async void Button_SaveClicked(object sender, EventArgs e)
        {
            ObservableCollection<ItemArt> tempItem = grid.ItemsSource as ObservableCollection<ItemArt>;
            List<ItemArt> list = tempItem.ToList().Where(q => q.QuantitaPre > 0).ToList();
            //Funzioni_Salva.PutItems(item.Quantita, Id_DocTes, item.CodArt, out string error);
            if (list.Count > 0)
            {
                bool answer = await DisplayAlert("Confermare?", "Vuoi confermare l'ordine?", "Si", "No");
                if (answer == true)
                {
                    bool answerAttention = await DisplayAlert("Attenzione", "Confermando l'ordine non potrai più modificarlo.\nSei sicuro?", "Si", "No");
                    if (answerAttention == true)
                    {
                        Funzioni_Table.DropTable_P_Items_Maui(out string errorDrop);
                        Funzioni_Table.CreateTable_P_Items_Maui(out string errorCreate);
                        int id_DocRig = 0;
                        foreach (var item in list)
                        {
                            Funzioni_Table.InsertTable_P_Items_Maui(id_DocRig++, item.CodArt, item.Description, item.Quantitare, item.Quantita, item.QuantitaPre, item.Alias, out string errorInsert);
                        }
                        await DisplayAlert("Inseriti", "Gli articoli variati sono stati inseriti e/o modificati", "Ok");

                        Navigation.RemovePage(Navigation.NavigationStack[0]);
                        await Navigation.PushAsync(new LoginPage());
                        Navigation.RemovePage(Navigation.NavigationStack[0]);
                    }
                }
            }
            else
            {
                await DisplayAlert("Attenzione", "Non ci sono articoli modificati da aggiungere all'ordine", "Ok");
            }
        }



        private void grid_CustomCellAppearance(object sender, CustomCellAppearanceEventArgs e)
        {
            int valueQuantitaPre = (int)grid.GetCellValue(e.RowHandle, "QuantitaPre");
            int valueQuantita = (int)grid.GetCellValue(e.RowHandle, "Quantita");

            if (valueQuantitaPre <= 0 /*&& valueQuantitare == 0*/)
            {
                e.BackgroundColor = Color.FromArgb("#ffd2cf");
                e.FontColor = Color.FromArgb("#000000");
            }
            else if ((valueQuantitaPre > 0 && valueQuantitaPre < valueQuantita) /*|| valueQuantita > valueQuantitare*/)
            {
                e.BackgroundColor = Color.FromArgb("#f3f5ce");
                e.FontColor = Color.FromArgb("#000000");
            }
            else if (valueQuantitaPre == valueQuantita)
            {
                e.BackgroundColor = Color.FromArgb("#d8f5ce");
                e.FontColor = Color.FromArgb("#000000");
            }
            else if (valueQuantitaPre > valueQuantita)
            {
                e.BackgroundColor = Color.FromArgb("#c7e0ff");
                e.FontColor = Color.FromArgb("#000000");
            }
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            ImageButton imageButton = (ImageButton)sender;
            CellData imageButton_CD = (CellData)imageButton.BindingContext;
            ItemArt imageButton_CD_ItemArt = (ItemArt)imageButton_CD.Item;

            if (!InitialListItem.Contains(imageButton_CD_ItemArt))
            {
                ObservableCollection<ItemArt> tempItem = grid.ItemsSource as ObservableCollection<ItemArt>;
                List<ItemArt> list = tempItem.ToList();
                list.Remove(imageButton_CD_ItemArt);
                grid.ItemsSource = list.ToObservableCollection();
            }
            else if (InitialListItem.Contains(imageButton_CD_ItemArt))
            {
                ObservableCollection<ItemArt> tempItem = grid.ItemsSource as ObservableCollection<ItemArt>;
                List<ItemArt> list = tempItem.ToList();
                imageButton_CD_ItemArt.QuantitaPre = 0;
                grid.ItemsSource = list.ToObservableCollection();
            }
        }
    }
}
