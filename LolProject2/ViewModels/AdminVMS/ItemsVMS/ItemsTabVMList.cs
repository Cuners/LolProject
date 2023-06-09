using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using LolProject2.View;
namespace LolProject2.ViewModels
{
    public class ItemsTabVMList : ViewModel
    {
        private UserControl _itemsTabControl;
        private UserControl _itemsEditControl;
        private UserControl _itemsDiffTabControl;
        private UserControl _itemsDiffEditControl;
        private UserControl _itemsSlozhTabControl;
        private UserControl _itemsSloshDiffEditControl;
        private UserControl _currentItemsControl;
        private UserControl _currentItemsDiffControl;
        private UserControl _currentItemsSloshControl;
        public UserControl CurrentItemsControl
        {
            get { return _currentItemsControl; }
            set => Set(ref _currentItemsControl, value);
        }
        public UserControl CurrentItemsDiffControl
        {
            get { return _currentItemsDiffControl; }
            set => Set(ref _currentItemsDiffControl, value);
        }
        public UserControl CurrentItemsSlozhControl
        {
            get { return _currentItemsSloshControl; }
            set => Set(ref _currentItemsSloshControl, value);
        }
        private List<Items> _items;
        public List<Items> Items
        {
            get { return _items; }
            set=>Set(ref _items, value);
        }
        private List<Items_Difference> _itemsDiff;
        public List<Items_Difference> ItemsDiff
        {
            get { return _itemsDiff; }
            set => Set(ref _itemsDiff, value);
        }
        private List<ItemsDifferents> _itemsDifft;
        public List<ItemsDifferents> ItemsDifft
        {
            get { return _itemsDifft; }
            set => Set(ref _itemsDifft, value);
        }
        private Items selectedItem;
        public Items SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                if (SelectedItem != null)
                {
                    OnPropertyChanged("SelectedItem");
                    ItemsVMList viewModel = new ItemsVMList(selectedItem) { ItemsTabVMList = this };
                    _itemsEditControl = new ItemsEditTabUserControl(viewModel);
                    CurrentItemsControl = _itemsEditControl;
                }
                else
                {
                    return;
                }

            }
        }
        private Items_Difference selectedItem_Diff;
        public Items_Difference SelectedItem_Diff
        {
            get { return selectedItem_Diff; }
            set
            {
                selectedItem_Diff = value;
                if (SelectedItem != null)
                {
                    OnPropertyChanged("SelectedItem_Diff");
                    ItemsDiffVM viewModel = new ItemsDiffVM(selectedItem_Diff) { ItemsTabVMList = this };
                    _itemsDiffEditControl = new ItemsDiffEditTabUserControl(viewModel);
                    CurrentItemsControl = _itemsDiffTabControl;
                }
                else
                {
                    return;
                }

            }
        }
        private ItemsDifferents selectedItemSlozh;
        public ItemsDifferents SelectedItemSlozh
        {
            get { return selectedItemSlozh; }
            set
            {
                selectedItemSlozh = value;
                if (SelectedItem != null)
                {
                    OnPropertyChanged("SelectedItemSlozh");
                    ItemsSlozhVM viewModel = new ItemsSlozhVM(selectedItemSlozh) { ItemsTabVMList = this };
                    _itemsSloshDiffEditControl = new ItemsSlozhEditUserControl(viewModel);
                    CurrentItemsControl = _itemsDiffTabControl;
                }
                else
                {
                    return;
                }

            }
        }
        #region ItemsTables
        public RelayCommand _BackToTableItem;

        public RelayCommand BackToTableItem
        {
            get
            {
                return _BackToTableItem ?? (_BackToTableItem = new RelayCommand(obj =>
                {
                    _itemsTabControl = new ItemsTabUserControl();
                    CurrentItemsControl = _itemsTabControl;
                }));
            }
        }
        public RelayCommand _ItemsAddEdit;

        public RelayCommand ItemsAddEdit
        {
            get
            {
                return _ItemsAddEdit ?? (_ItemsAddEdit = new RelayCommand(obj =>
                {
                    ItemsVMList Item = obj as ItemsVMList;
                    if (Item.Items.Id != 0)
                    {
                        using (LOLPROJECTEntities tRPO = new LOLPROJECTEntities())
                        {
                            try
                            {

                                Items item = new Items
                                {
                                    Id = Item.Items.Id,
                                    ImageItem = Item.Items.ImageItem,
                                    AD = Item.Items.AD,
                                    Crit = Item.Items.Crit,
                                    AP = Item.Items.AP,
                                    Attack_speed = Item.Items.Attack_speed,
                                    Movement = Item.Items.Movement,
                                    Armor = Item.Items.Armor,
                                    HP = Item.Items.HP,
                                    Modificators = Item.Items.Modificators,
                                    ItemName = Item.Items.ItemName
                                };
                                tRPO.Entry(item).State = EntityState.Modified;
                                tRPO.SaveChanges();

                                CurrentItemsControl = _itemsTabControl;
                                //RemoveTovar(selectedAppeal.Id);
                            }
                            catch
                            {
                                MessageBox.Show("Вы что-то не ввели");
                            }
                        }
                    }
                    else
                    {
                        using (LOLPROJECTEntities tRPO = new LOLPROJECTEntities())
                        {
                            try
                            {
                                Items item = new Items
                                {
                                    Id = Item.Items.Id,
                                    ImageItem = Item.Items.ImageItem,
                                    AD = Item.Items.AD,
                                    Crit = Item.Items.Crit,
                                    AP = Item.Items.AP,
                                    Attack_speed = Item.Items.Attack_speed,
                                    Movement = Item.Items.Movement,
                                    Armor = Item.Items.Armor,
                                    HP = Item.Items.HP,
                                    Modificators = Item.Items.Modificators,
                                    ItemName = Item.Items.ItemName
                                };
                                tRPO.Entry(item).State = EntityState.Added;
                                tRPO.SaveChanges();
                                Items.Add(item);
                                CurrentItemsControl = _itemsTabControl;
                            }
                            catch
                            {
                                MessageBox.Show("Вы что-то не ввели");
                            }
                        }
                    }
                }));
            }
        }
        public RelayCommand _ItemDelete;

        public RelayCommand ItemDelete
        {
            get
            {
                return _ItemDelete ?? (_ItemDelete = new RelayCommand(obj =>
                {
                    ItemsVMList Item = obj as ItemsVMList;

                    using (LOLPROJECTEntities tRPO = new LOLPROJECTEntities())
                    {
                        try
                        {
                            Items item = new Items
                            {
                                Id = Item.Items.Id,
                                ImageItem = Item.Items.ImageItem,
                                AD = Item.Items.AD,
                                Crit = Item.Items.Crit,
                                AP = Item.Items.AP,
                                Attack_speed = Item.Items.Attack_speed,
                                Movement = Item.Items.Movement,
                                Armor = Item.Items.Armor,
                                HP = Item.Items.HP,
                                Modificators = Item.Items.Modificators,
                                ItemName = Item.Items.ItemName
                            };
                            tRPO.Entry(item).State = EntityState.Deleted;
                            tRPO.SaveChanges();
                            RemoveItem(Item.Items.Id);
                            CurrentItemsControl = _itemsTabControl;

                        }
                        catch
                        {
                            MessageBox.Show("Ошибка");
                        }
                    }

                }));
            }
        }
        public void RemoveItem(int iditem)
        {
            Items item = null;
            foreach (Items items in Items)
            {
                if (items.Id == iditem)
                {
                    item = items;
                    break;
                }
            }
            if (item != null)
            {
                Items.Remove(item);
            }
        }
        #endregion
        #region ItemsDiff
        public RelayCommand _BackToTableItemDiff;

        public RelayCommand BackToTableItemDiff
        {
            get
            {
                return _BackToTableItemDiff ?? (_BackToTableItemDiff = new RelayCommand(obj =>
                {
                    _itemsDiffTabControl = new ItemsDiffTabUserControl();
                    CurrentItemsDiffControl = _itemsDiffTabControl;
                }));
            }
        }
        public RelayCommand _ItemsDiffAddEdit;

        public RelayCommand ItemsDiffAddEdit
        {
            get
            {
                return _ItemsDiffAddEdit ?? (_ItemsDiffAddEdit = new RelayCommand(obj =>
                {
                    ItemsDiffVM ItemDiff = obj as ItemsDiffVM;
                    if (ItemDiff.ItemsDiff.Id != 0)
                    {
                        using (LOLPROJECTEntities tRPO = new LOLPROJECTEntities())
                        {
                            try
                            {
                                Items_Difference itemDiff = new Items_Difference
                                {
                                    Id = ItemDiff.ItemsDiff.Id,
                                    Id_Item = ItemDiff.ItemsDiff.Id_Item,
                                    Id_Diff = ItemDiff.ItemsDiff.Id_Diff
                                    
                                };
                                tRPO.Entry(itemDiff).State = EntityState.Modified;
                                tRPO.SaveChanges();

                                CurrentItemsDiffControl = _itemsDiffTabControl;
                                //RemoveTovar(selectedAppeal.Id);
                            }
                            catch
                            {
                                MessageBox.Show("Вы что-то не ввели");
                            }
                        }
                    }
                    else
                    {
                        using (LOLPROJECTEntities tRPO = new LOLPROJECTEntities())
                        {
                            try
                            {
                                Items_Difference itemDiff = new Items_Difference
                                {
                                    Id = ItemDiff.ItemsDiff.Id,
                                    Id_Item = ItemDiff.ItemsDiff.Id_Item,
                                    Id_Diff = ItemDiff.ItemsDiff.Id_Diff

                                };
                                tRPO.Entry(itemDiff).State = EntityState.Added;
                                tRPO.SaveChanges();
                                ItemsDiff.Add(itemDiff);
                                CurrentItemsDiffControl = _itemsDiffTabControl;
                            }
                            catch
                            {
                                MessageBox.Show("Вы что-то не ввели");
                            }
                        }
                    }
                }));
            }
        }
        public RelayCommand _ItemDiffDelete;

        public RelayCommand ItemDiffDelete
        {
            get
            {
                return _ItemDelete ?? (_ItemDelete = new RelayCommand(obj =>
                {
                    ItemsDiffVM ItemDiff = obj as ItemsDiffVM;

                    using (LOLPROJECTEntities tRPO = new LOLPROJECTEntities())
                    {
                        try
                        {
                            Items_Difference itemDiff = new Items_Difference
                            {
                                Id = ItemDiff.ItemsDiff.Id,
                                Id_Item = ItemDiff.ItemsDiff.Id_Item,
                                Id_Diff = ItemDiff.ItemsDiff.Id_Diff

                            };
                            tRPO.Entry(itemDiff).State = EntityState.Deleted;
                            tRPO.SaveChanges();
                            RemoveItemDiff(ItemDiff.ItemsDiff .Id);
                            CurrentItemsDiffControl = _itemsDiffTabControl;

                        }
                        catch
                        {
                            MessageBox.Show("Ошибка");
                        }
                    }

                }));
            }
        }
        public void RemoveItemDiff(int iditem)
        {
            Items_Difference item = null;
            foreach (Items_Difference items in ItemsDiff)
            {
                if (items.Id == iditem)
                {
                    item = items;
                    break;
                }
            }
            if (item != null)
            {
                ItemsDiff.Remove(item);
            }
        }
        #endregion
        #region ItemsSlozh
        public RelayCommand _BackToTableItemSlozh;

        public RelayCommand BackToTableItemSlozh
        {
            get
            {
                return _BackToTableItemSlozh ?? (_BackToTableItemSlozh = new RelayCommand(obj =>
                {
                    _itemsSlozhTabControl = new ItemsSlozhTabUserControl();
                    CurrentItemsSlozhControl = _itemsSlozhTabControl;
                }));
            }
        }
        public RelayCommand _ItemsSlozhAddEdit;

        public RelayCommand ItemsSlozhAddEdit
        {
            get
            {
                return _ItemsSlozhAddEdit ?? (_ItemsSlozhAddEdit = new RelayCommand(obj =>
                { 
                    ItemsSlozhVM ItemSlozh = obj as ItemsSlozhVM;
                    if (ItemSlozh.ItemsDifft.Id != 0)
                    {
                        using (LOLPROJECTEntities tRPO = new LOLPROJECTEntities())
                        {
                            try
                            {
                                ItemsDifferents itemSlozh = new ItemsDifferents
                                {
                                    Id = ItemSlozh.ItemsDifft.Id,
                                    ItemsDiff = ItemSlozh.ItemsDifft.ItemsDiff
                                   
                                };
                                tRPO.Entry(itemSlozh).State = EntityState.Modified;
                                tRPO.SaveChanges();

                                CurrentItemsSlozhControl = _itemsSlozhTabControl;
                                //RemoveTovar(selectedAppeal.Id);
                            }
                            catch
                            {
                                MessageBox.Show("Вы что-то не ввели");
                            }
                        }
                    }
                    else
                    {
                        using (LOLPROJECTEntities tRPO = new LOLPROJECTEntities())
                        {
                            try
                            {
                                ItemsDifferents itemSlozh = new ItemsDifferents
                                {
                                    Id = ItemSlozh.ItemsDifft.Id,
                                    ItemsDiff = ItemSlozh.ItemsDifft.ItemsDiff

                                };
                                tRPO.Entry(itemSlozh).State = EntityState.Added;
                                tRPO.SaveChanges();
                                ItemsDifft.Add(itemSlozh);
                                CurrentItemsSlozhControl = _itemsSlozhTabControl;
                            }
                            catch
                            {
                                MessageBox.Show("Вы что-то не ввели");
                            }
                        }
                    }
                }));
            }
        }
        public RelayCommand _ItemSlozhDelete;

        public RelayCommand ItemSlozhDelete
        {
            get
            {
                return _ItemSlozhDelete ?? (_ItemSlozhDelete = new RelayCommand(obj =>
                {
                    ItemsSlozhVM ItemSlozh = obj as ItemsSlozhVM;

                    using (LOLPROJECTEntities tRPO = new LOLPROJECTEntities())
                    {
                        try
                        {
                            ItemsDifferents itemSlozh = new ItemsDifferents
                            {
                                Id = ItemSlozh.ItemsDifft.Id,
                                ItemsDiff = ItemSlozh.ItemsDifft.ItemsDiff

                            };
                            tRPO.Entry(itemSlozh).State = EntityState.Deleted;
                            tRPO.SaveChanges();
                            RemoveItemSlozh(ItemSlozh.ItemsDifft.Id);
                            CurrentItemsDiffControl = _itemsDiffTabControl;

                        }
                        catch
                        {
                            MessageBox.Show("Ошибка");
                        }
                    }

                }));
            }
        }
        public void RemoveItemSlozh(int iditem)
        {
            ItemsDifferents item = null;
            foreach (ItemsDifferents items in ItemsDifft)
            {
                if (items.Id == iditem)
                {
                    item = items;
                    break;
                }
            }
            if (item != null)
            {
                ItemsDifft.Remove(item);
            }
        }
        #endregion
        public RelayCommand _ShowItemsAdd;

        public RelayCommand ShowItemsAdd
        {
            get
            {
                return _ShowItemsAdd ?? (_ShowItemsAdd = new RelayCommand(obj =>
                {
                    _itemsEditControl = new ItemsEditTabUserControl(new ItemsVMList() { ItemsTabVMList = this });
                    CurrentItemsControl = _itemsEditControl;
                }));
            }
        }
        public RelayCommand _ShowItemsDiffAdd;

        public RelayCommand ShowItemsDiffAdd
        {
            get
            {
                return _ShowItemsDiffAdd ?? (_ShowItemsDiffAdd = new RelayCommand(obj =>
                {
                    _itemsDiffEditControl = new ItemsDiffEditTabUserControl(new ItemsDiffVM() { ItemsTabVMList = this });
                    CurrentItemsDiffControl = _itemsDiffEditControl;
                }));
            }
        }
        public RelayCommand _ShowItemsSlozhAdd;

        public RelayCommand ShowItemsSlozhAdd
        {
            get
            {
                return _ShowItemsSlozhAdd ?? (_ShowItemsSlozhAdd = new RelayCommand(obj =>
                {
                    _itemsSloshDiffEditControl = new ItemsSlozhEditUserControl(new ItemsSlozhVM() { ItemsTabVMList = this });
                    CurrentItemsSlozhControl = _itemsSloshDiffEditControl;
                }));
            }
        }
        public ItemsTabVMList()
        {
            _itemsTabControl=new ItemsTabUserControl();
            _itemsDiffTabControl=new ItemsDiffTabUserControl();
            _itemsSlozhTabControl=new ItemsSlozhTabUserControl();
            using(LOLPROJECTEntities lOLPROJECTEntities=new LOLPROJECTEntities())
            {
                Items = new List<Items>(lOLPROJECTEntities.Items);
                ItemsDiff=new List<Items_Difference>(lOLPROJECTEntities.Items_Difference);
                ItemsDifft=new List<ItemsDifferents>(lOLPROJECTEntities.ItemsDifferents);
            }
            CurrentItemsControl = _itemsTabControl;
            CurrentItemsDiffControl = _itemsDiffTabControl;
            CurrentItemsSlozhControl = _itemsSlozhTabControl;
        }
    }
}
