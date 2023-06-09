using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LolProject2.ViewModels
{
    public class ItemsSlozhVM : ViewModel
    {
        public ItemsDifferents _itemsDifft;
        public ItemsDifferents ItemsDifft
        {
            get { return _itemsDifft; }
            set => Set(ref _itemsDifft, value);
        }
        public ItemsSlozhVM()
        {
            ItemsDifft = new ItemsDifferents();
        }
        public ItemsSlozhVM(ItemsDifferents itemDifft)
        {
            ItemsDifft = itemDifft;

        }
        private ItemsTabVMList _ItemsTabVMList;
        public ItemsTabVMList ItemsTabVMList
        {
            get { return _ItemsTabVMList; }
            set => Set(ref _ItemsTabVMList, value);
        }
    }
}
