using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LolProject2.View;
namespace LolProject2.ViewModels
{
    public class ItemsVMList : ViewModel
    {
        public Items _items;
        public Items Items
        {
            get { return _items; }
            set => Set(ref _items, value);
        }
     
        public RelayCommand _OpenImageItem;

        public RelayCommand OpenImageItem
        {
            get
            {
                return _OpenImageItem ?? (_OpenImageItem = new RelayCommand(obj =>
                {
                    OpenFileDialog dlg = new OpenFileDialog()
                    {
                        Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" + "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" + "Portable Network Graphic (*.png)|*.png"
                    };
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        Items.ImageItem = File.ReadAllBytes(dlg.FileName);
                    }
                }));
            }
        }
        public ItemsVMList()
        {
            Items = new Items();
        }
        public ItemsVMList(Items item)
        {
            Items = item;
            
        }
        private ItemsTabVMList _ItemsTabVMList;
        public ItemsTabVMList ItemsTabVMList
        {
            get { return _ItemsTabVMList; }
            set => Set(ref _ItemsTabVMList, value);
        }
    }
}
