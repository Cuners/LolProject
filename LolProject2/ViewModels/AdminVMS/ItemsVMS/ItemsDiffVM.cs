using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LolProject2.ViewModels
{
    public class ItemsDiffVM : ViewModel
    {
        public Items_Difference _itemsDiff;
        public Items_Difference ItemsDiff
        {
            get { return _itemsDiff; }
            set => Set(ref _itemsDiff, value);
        }
        public ItemsDiffVM()
        {
            ItemsDiff = new Items_Difference();
        }
        public ItemsDiffVM(Items_Difference itemDiff)
        {
            ItemsDiff = itemDiff;

        }
        private ItemsTabVMList _ItemsTabVMList;
        public ItemsTabVMList ItemsTabVMList
        {
            get { return _ItemsTabVMList; }
            set => Set(ref _ItemsTabVMList, value);
        }
    }
}
