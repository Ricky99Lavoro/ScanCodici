using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXMauiApp_ScanCodici.Classes
{
    public class Riga_GridDataViewModel_Items
    {
        readonly Riga_ItemsData data;

        public event PropertyChangedEventHandler PropertyChanged;
        public IReadOnlyList<ItemArt> Righe_Items { get => data.ItemsRiga; }

        public Riga_GridDataViewModel_Items()
        {
            data = new Riga_ItemsData();
        }

        protected void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
