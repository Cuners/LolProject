using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Data.Entity;
using LolProject2.View;
using LolProject2.Utils;
using System.Windows;
using System.Windows.Controls;
using System.Threading;
using APIRIOT.ViewModels;
namespace LolProject2.ViewModels
{
    public class MainListVM : ViewModel, ICloseWindow
    {
        #region Svoistva
        private int i = 0;
        private UserControl currentCunt;
        private UserControl _tacticsControl;
        private UserControl _heroesSelectControl;
        private UserControl _itemsSelectControl;
        public UserControl CurrentCunt
        {
            get { return currentCunt; }
            set=>Set(ref currentCunt, value);
        }
        public ObservableCollection<Heroes> Heroes { get; set; }
        private List<Heroes> _heroesList;
        public List<Heroes> HeroesList 
        {
            get { return _heroesList; }
            set=>Set(ref _heroesList, value);
        } 
        
        public List<Items> ResultItems { get; set; }
        private List<Items> _Items;
        public List<Items> Items 
        {
            get { return _Items; }
            set=>Set(ref _Items, value);
        }
        public List<ItemsDifferents> ItemsDifferents { get; set; }

        public List<Items> ItemsNach { get; set; }
        public List<Items> ItemsRash { get; set; }
        public List<Items> ItemsBase { get; set; }
        public List<Items> ItemsBoots { get; set; }
        public List<Items> ItemsEpic { get; set; }
        public List<Items> ItemsLegend { get; set; }
        public List<Items> ItemsMythic { get; set; }
        public List<Skill_Hero> Skill_Heroes { get; set; }
        
        private string _NameHero;
        public string NameHero
        {
            get { return _NameHero; }
            set => Set(ref _NameHero, value);
        }
        
        #region SelectedImage
        private byte[] _ImageHero;
        public byte[] ImageHero
        {
            get { return _ImageHero; }
            set => Set(ref _ImageHero, value);
        }
        private Items items1;
        public Items Items1
        {
            get { return items1; }
            set=> Set(ref items1, value);
        }
        private byte[] _ImageItem1;
        public byte[] ImageItem1
        {
            get { return _ImageItem1; }
            set=>Set(ref _ImageItem1, value);
        }
        private byte[] _ImageItem2;
        public byte[] ImageItem2
        {
            get { return _ImageItem2; }
            set => Set(ref _ImageItem2, value);
        }
        private Items items2;
        public Items Items2
        {
            get { return items2; }
            set => Set(ref items2, value);
        }
        private byte[] _ImageItem3;
        public byte[] ImageItem3
        {
            get { return _ImageItem3; }
            set => Set(ref _ImageItem3, value);
        }
        private Items items3;
        public Items Items3
        {
            get { return items3; }
            set => Set(ref items3, value);
        }
        private byte[] _ImageItem4;
        public byte[] ImageItem4
        {
            get { return _ImageItem4; }
            set => Set(ref _ImageItem4, value);
        }
        private Items items4;
        public Items Items4
        {
            get { return items4; }
            set => Set(ref items4, value);
        }
        private byte[] _ImageItem5;
        public byte[] ImageItem5
        {
            get { return _ImageItem5; }
            set => Set(ref _ImageItem5, value);
        }
        private Items items5;
        public Items Items5
        {
            get { return items5; }
            set => Set(ref items5, value);
        }
        private byte[] _ImageItem6;
        public byte[] ImageItem6
        {
            get { return _ImageItem6; }
            set => Set(ref _ImageItem6, value);
        }
        private Items items6;
        public Items Items6
        {
            get { return items6; }
            set => Set(ref items6, value);
        }
        private Heroes heroselected;
        public Heroes HeroSelected
        {
            get { return heroselected; }
            set => Set(ref heroselected, value);
        }
        private BaseScales heroBaseScales;
        public BaseScales HeroBaseScales
        {
            get { return heroBaseScales; }
            set => Set(ref heroBaseScales, value);
        }
       public BaseScalesStore baseScalesStore { get; set; }
        public BaseScales HeroBaseScales2 { get; set; }
       
        private Scales heroScales;
        public Scales HeroScales
        {
            get { return heroScales; }
            set => Set(ref heroScales, value);
        }
        private OnlyStats onlyStats;
        public OnlyStats OnlyStats
        {
            get { return onlyStats; }
            set=>Set(ref onlyStats, value); 
        }
        private Nullable<double> _Health=0;
        public Nullable<double> Health
        {
            get { return _Health; }
            set => Set(ref _Health, value);
        }
        private Nullable<double> _Armor=0;
        public Nullable<double> Armor
        {
            get { return _Armor; }
            set => Set(ref _Armor, value);
        }
        private Nullable<double> _Mana=0;
        public Nullable<double> Mana
        {
            get { return _Mana; }
            set => Set(ref _Mana, value);
        }
        private Nullable<double> _AD=0;
        public Nullable<double> AD
        {
            get { return _AD; }
            set => Set(ref _AD, value);
        }
        private Nullable<double> _AP=0;
        public Nullable<double> AP
        {
            get { return _AP; }
            set => Set(ref _AP, value);
        }
        private Nullable<double> _ResistMagic=0;
        public Nullable<double> ResistMagic
        {
            get { return _ResistMagic; }
            set => Set(ref _ResistMagic, value);
        }
        private Nullable<double> _Crit=0;
        public Nullable<double> Crit
        {
            get { return _Crit; }
            set => Set(ref _Crit, value);
        }
        private Nullable<double> _MoveSpeed=0;
        public Nullable<double> MoveSpeed
        {
            get { return _MoveSpeed; }
            set => Set(ref _MoveSpeed, value);
        }
        private Nullable<double> _Speed_Attack=0;
        public Nullable<double> Speed_Attack
        {
            get { return _Speed_Attack; }
            set => Set(ref _Speed_Attack, value);
        }
        private int iterations = 0;
        public int Iterations
        {
            get { return iterations; }
            set=>Set(ref iterations, value);
        }
        #endregion
        private string _TxtEntered;
        public string TxtEntered
        {
            get { return _TxtEntered; }
            set
            {
                _TxtEntered = value;
                OnPropertyChanged("TxtEnterd");
                if (string.IsNullOrEmpty(_TxtEntered))
                {
                    Items = ResultItems;
                }
                else
                {
                    Items = ResultItems.Where(x => x.ItemName.ToLower().Contains(TxtEntered.ToLower())).ToList();
                }
            }
        }
        #endregion 


       
        #region UserControls
        private UserControl _heroesUserControlMain;
        private UserControl _heroesUserControlInfo;

        private UserControl currentControl;
        public UserControl CurrentControl
        {
            get { return currentControl; }
            set => Set(ref currentControl, value);
        }
        #endregion
        #region CloseCommands
        public RelayCommand _closeCommand;

        public RelayCommand CloseCommand
        {
            get
            {
                return _closeCommand ?? (_closeCommand = new RelayCommand(obj =>
                {
                    CloseWindow();
                }));
            }
        }
        public Action Close { get; set; }
        void CloseWindow()
        {
            Close?.Invoke();
        }
        public bool CanClose()
        {
            return true;
        }
        #endregion
        #region MainListVM
        public MainListVM()
        {
            _heroesUserControlMain = new HeroesMainControl();
            _heroesUserControlInfo = new HeroesUserControl(null);
            
            _tacticsControl = new TacticsView();
            CurrentControl = _heroesUserControlMain;
            CurrentCunt = _tacticsControl;
            ItemsLegend = new List<Items>();
            ItemsNach = new List<Items>();
            ItemsRash = new List<Items>();
            ItemsBase = new List<Items>();
            ItemsBoots = new List<Items>();
            ItemsEpic = new List<Items>();
            Items = new List<Items>();
            ItemsMythic = new List<Items>();
            OnlyStats = new OnlyStats();
            
            using (LOLPROJECTEntities lOLPROJECT=new LOLPROJECTEntities())
            {
                Heroes = new ObservableCollection<Heroes>(lOLPROJECT.Heroes);
                //TacticsViewVM = new TacticsViewVM();
                HeroesList = new List<Heroes>(lOLPROJECT.Heroes);
                ItemsDifferents = new List<ItemsDifferents>(lOLPROJECT.ItemsDifferents);
                ResultItems = new List<Items>(lOLPROJECT.Items);
                Items = new List<Items>(lOLPROJECT.Items);
                #region AllItems
                foreach (Items items in lOLPROJECT.Items)
                {
                    
                    foreach (Items_Difference items_Difference in lOLPROJECT.Items_Difference)
                    {
                        if(items.Id==items_Difference.Id_Item && items_Difference.Id_Diff == 1)
                        {
                            ItemsNach.Add(items_Difference.Items);
                           
                        }
                    }
                }
                foreach (Items items in lOLPROJECT.Items)
                {
                    foreach (Items_Difference items_Difference in lOLPROJECT.Items_Difference)
                    {
                        if (items.Id == items_Difference.Id_Item && items_Difference.Id_Diff == 2)
                        {
                            ItemsRash.Add(items_Difference.Items);
                        }
                    }
                }
                foreach (Items items in lOLPROJECT.Items)
                {
                    foreach (Items_Difference items_Difference in lOLPROJECT.Items_Difference)
                    {
                        if (items.Id == items_Difference.Id_Item && items_Difference.Id_Diff == 3)
                        {
                            ItemsBase.Add(items_Difference.Items);
                        }
                    }
                }
                foreach (Items items in lOLPROJECT.Items)
                {
                    foreach (Items_Difference items_Difference in lOLPROJECT.Items_Difference)
                    {
                        if (items.Id == items_Difference.Id_Item && items_Difference.Id_Diff == 4)
                        {
                            ItemsBoots.Add(items_Difference.Items);
                        }
                    }
                }
                foreach (Items items in lOLPROJECT.Items)
                {
                    foreach (Items_Difference items_Difference in lOLPROJECT.Items_Difference)
                    {
                        if (items.Id == items_Difference.Id_Item && items_Difference.Id_Diff == 5)
                        {
                            ItemsEpic.Add(items_Difference.Items);
                        }
                    }
                }
                foreach (Items items in lOLPROJECT.Items)
                {
                    foreach (Items_Difference items_Difference in lOLPROJECT.Items_Difference)
                    {
                        if (items.Id == items_Difference.Id_Item && items_Difference.Id_Diff == 6)
                        {
                            ItemsLegend.Add(items_Difference.Items);
                        }
                    }
                }
                foreach (Items items in lOLPROJECT.Items)
                {
                    foreach (Items_Difference items_Difference in lOLPROJECT.Items_Difference)
                    {
                        if (items.Id == items_Difference.Id_Item && items_Difference.Id_Diff == 7)
                        {
                            ItemsMythic.Add(items_Difference.Items);
                        }
                    }
                }
#endregion
                Skill_Heroes = new List<Skill_Hero>(lOLPROJECT.Skill_Hero);
            }
            
        }
        #endregion
        private int _Level;
        public int Level
        {
            get { return _Level; }
            set
            {
                
                    _Level = value;
                if (HeroBaseScales != null) 
                {
                    Podshet(HeroBaseScales, null, false);
                    HeroBaseScales.AD = baseScalesStore.AD + HeroScales.Damage * Convert.ToDouble(Level);
                    HeroBaseScales.Armor = baseScalesStore.Armor + HeroScales.Armor * Convert.ToDouble(Level);
                    HeroBaseScales.Health = baseScalesStore.Health + HeroScales.Health * Convert.ToDouble(Level);
                    HeroBaseScales.Mana = baseScalesStore.Mana + HeroScales.Mana * Convert.ToDouble(Level);
                    HeroBaseScales.ResistMagic = baseScalesStore.ResistMagic + HeroScales.ResistMagic * Convert.ToDouble(Level);
                    Podshet(HeroBaseScales, null, true);
                    
                   /* Health = HeroBaseScales.Health;
                    AD = HeroBaseScales.AD;
                    Armor = HeroBaseScales.Armor;
                    MoveSpeed = HeroBaseScales.MoveSpeed; */
                    OnPropertyChanged("Level");
                }
                else
                {
                    MessageBox.Show("Выберите героя");
                    return;
                }
               
            }

        }
        private Heroes selectedHero;
        public Heroes SelectedHero
        {
            get { return selectedHero; }
            set
            {
                selectedHero = value;
                OnPropertyChanged("SelectedHero");
                ImageHero = selectedHero.ImageHero;
                HeroSelected = selectedHero;
                using(LOLPROJECTEntities lOLPROJECTEntities=new LOLPROJECTEntities())
                {
                    foreach(BaseScales baseScales in lOLPROJECTEntities.BaseScales)
                    {
                        if (selectedHero.NameHero == baseScales.NameHero)
                        {
                            HeroBaseScales=baseScales;
                            baseScalesStore=new BaseScalesStore() { AD=baseScales.AD,Armor=baseScales.Armor, Crit=0, Health=baseScales.Health, MoveSpeed=baseScales.MoveSpeed, ResistMagic=baseScales.ResistMagic};
                        }
                    }
                    foreach(Scales scales in lOLPROJECTEntities.Scales)
                    {
                        if (selectedHero.NameHero == scales.NameHero)
                        {
                            HeroScales=scales;
                        }
                    }
                    
                    
                }
                _tacticsControl = new TacticsView();
                CurrentCunt = _tacticsControl;
               
               
            }
        }
        public void Podshet(BaseScales scales,Items items,bool flag)
        {
            if (scales != null && flag==false && Health!=0)
            {
                OnlyStats.AD -= scales.AD;
                OnlyStats.Armor -= scales.Armor;
                OnlyStats.Health -= scales.Health;
                OnlyStats.MoveSpeed -= scales.MoveSpeed;
                OnlyStats.ResistMagic-= scales.ResistMagic;
                OnlyStats.Speed_Attack -= scales.Speed_Attack;
               
            }
            if (scales != null && flag == true)
            {
                OnlyStats.AD += scales.AD;
                OnlyStats.Armor += scales.Armor;
                OnlyStats.Health += scales.Health;
                OnlyStats.MoveSpeed += scales.MoveSpeed;
                OnlyStats.ResistMagic += scales.ResistMagic;
                OnlyStats.Speed_Attack+=scales.Speed_Attack;
               
            }
            if (items!=null && flag==false)
            {
                if (items.AD != null)
                {
                    OnlyStats.AD -= items.AD;
                }
                if (items.Armor != null)
                {
                    OnlyStats.Armor -= items.Armor;
                }
                if (items.HP != null)
                {
                    OnlyStats.Health -= items.HP;
                }
                if (items.Crit != null)
                {
                    OnlyStats.Crit -= items.Crit;
                }

            }
            else if(items!=null && flag==true)
            {
                if (items.AD != null)
                {
                    OnlyStats.AD += items.AD;
                }
                if (items.Armor != null)
                {
                    OnlyStats.Armor += items.Armor;
                }
                if (items.HP != null)
                {
                    OnlyStats.Health += items.HP;
                }
                if (items.Crit != null)
                {
                    OnlyStats.Crit += items.Crit;
                }
            }
            if (OnlyStats != null)
            {
                Health = OnlyStats.Health;
                AD = OnlyStats.AD;
                Armor = OnlyStats.Armor;
                MoveSpeed = OnlyStats.MoveSpeed;
                ResistMagic=OnlyStats.ResistMagic;

            }
        }
        Random random = new Random();
        double sreddmg = 0;
        double alltime = 0;
        private void Rasch()
        {
          
            for (int i = 0; i < Iterations; i++)
            {
                double health = Convert.ToDouble(OnlyStats.Health);
                double dmg = 0;
                double sum = 0;
                double speed = 0;
                double time = 0;
                while (health > 0)
                {
                    if (OnlyStats.Crit != null)
                    {
                        if (random.Next(1, 100) < OnlyStats.Crit)
                        {
                            dmg = Convert.ToDouble(OnlyStats.AD * (100 / (100 + OnlyStats.Armor)) * 1.75);
                        }
                        else
                        {
                            dmg = Convert.ToDouble(OnlyStats.AD * (100 / (100 + OnlyStats.Armor)));
                        }
                    }
                    while (speed < OnlyStats.Speed_Attack)
                    {
                        speed += 0.050;
                        time += speed;
                    }
                    health -= dmg;
                    sum += dmg;
                }
                sreddmg += sum;
                alltime += time;
            }
            sreddmg /= iterations;
            alltime /= iterations;
        }
        private Items selectedItem;
        public Items SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged("SelectedItem");
                if (selectedItem != null)
                {
                    
                    switch (i)
                    {
                        case 1:
                            ImageItem1 = selectedItem.ImageItem;
                            Podshet(null, Items1, false);
                            Items1 = selectedItem;
                            Podshet(null , Items1, true);  
                            _tacticsControl = new TacticsView();
                            CurrentCunt = _tacticsControl;
                            break;
                        case 2:
                            ImageItem2 = selectedItem.ImageItem;
                            Podshet(null, Items2, false);
                            Items2 = selectedItem;
                            Podshet(null, Items2, true);
                            _tacticsControl = new TacticsView();
                            CurrentCunt = _tacticsControl;
                            break;
                        case 3:
                            ImageItem3 = selectedItem.ImageItem;
                            Podshet(null, Items3, false);
                            Items3 = selectedItem;
                            Podshet(null, Items3, true);
                            _tacticsControl = new TacticsView();
                            CurrentCunt = _tacticsControl;
                            break;
                        case 4:
                            ImageItem4 = selectedItem.ImageItem;
                            Podshet(null, Items4, false);
                            Items4 = selectedItem;
                            Podshet(null, Items4, true);
                            _tacticsControl = new TacticsView();
                            CurrentCunt = _tacticsControl;
                            break;
                        case 5:
                            ImageItem5 = selectedItem.ImageItem;
                            Podshet(null, Items5, false);
                            Items5 = selectedItem;
                            Podshet(null, Items5, true);
                            _tacticsControl = new TacticsView();
                            CurrentCunt = _tacticsControl;
                            break;
                        case 6:
                            ImageItem6 = selectedItem.ImageItem;
                            Podshet(null, Items6, false);
                            Items6 = selectedItem;
                            Podshet(null, Items6, true);
                            _tacticsControl = new TacticsView();
                            CurrentCunt = _tacticsControl;
                            break;
                        default:

                            break;
                    }
                }

            }
        }
        private Heroes selectedHeroesInfo;
        public Heroes SelectedHeroesInfo
        {
            get { return selectedHeroesInfo; }
            set
            {
                //BooksViewModel book=value;
                selectedHeroesInfo = value;
                MainVM viewModel = new MainVM(selectedHeroesInfo) { MainListVM=this};
                OnPropertyChanged("SelectedHeroesInfo");
                _heroesUserControlInfo = new HeroesUserControl(viewModel);
                CurrentControl = _heroesUserControlInfo;
                // InfoHeroes heroesSelect = new InfoHeroes(viewModel);
                // heroesSelect.Show();

            }
        }
        #region ShowUserContols
        public RelayCommand _ShowFirstUserControlCommand;

         public RelayCommand ShowFirstUserControlCommand
         {
             get
             {
                 return _ShowFirstUserControlCommand ?? (_ShowFirstUserControlCommand = new RelayCommand(obj =>
                 {
                     _heroesUserControlMain = new HeroesMainControl();
                     CurrentControl = _heroesUserControlMain;
                 }));
             }
         } 
        

        public RelayCommand _ShowSecondUserControlCommand;

        public RelayCommand ShowSecondUserControlCommand
        {
            get
            {
                return _ShowSecondUserControlCommand ?? (_ShowSecondUserControlCommand = new RelayCommand(obj =>
                {
                    CurrentControl = _heroesUserControlInfo;
                }));
            }
        }
        #endregion
        public RelayCommand _OpenHeroes;

        public RelayCommand OpenHeroes
        {
            get
            {
                return _OpenHeroes ?? (_OpenHeroes = new RelayCommand(obj =>
                {
                    _heroesSelectControl = new HeroesSelectUserControl();
                    CurrentCunt = _heroesSelectControl;
                }));
            }
        }
        public RelayCommand _OpenItems;

        public RelayCommand OpenItems
        {
            get
            {
                return _OpenItems ?? (_OpenItems = new RelayCommand(obj =>
                {
                    i = 1;
                    _itemsSelectControl=new ItemsSelectUserControl();
                    CurrentCunt= _itemsSelectControl;
                }));
            }
        }
        public RelayCommand _OpenItems2;

        public RelayCommand OpenItems2
        {
            get
            {
                return _OpenItems2 ?? (_OpenItems2 = new RelayCommand(obj =>
                {
                    i = 2;
                    _itemsSelectControl = new ItemsSelectUserControl();
                    CurrentCunt = _itemsSelectControl;
                }));
            }
        }
        public RelayCommand _OpenItems3;

        public RelayCommand OpenItems3
        {
            get
            {
                return _OpenItems3 ?? (_OpenItems3 = new RelayCommand(obj =>
                {
                    i = 3;
                    _itemsSelectControl = new ItemsSelectUserControl();
                    CurrentCunt = _itemsSelectControl;
                }));
            }
        }
        public RelayCommand _OpenItems4;

        public RelayCommand OpenItems4
        {
            get
            {
                return _OpenItems4 ?? (_OpenItems4 = new RelayCommand(obj =>
                {
                    i = 4;
                    _itemsSelectControl = new ItemsSelectUserControl();
                    CurrentCunt = _itemsSelectControl;
                }));
            }
        }
        public RelayCommand _OpenItems5;

        public RelayCommand OpenItems5
        {
            get
            {
                return _OpenItems5 ?? (_OpenItems5 = new RelayCommand(obj =>
                {
                    i = 5;
                    _itemsSelectControl = new ItemsSelectUserControl();
                    CurrentCunt = _itemsSelectControl;
                }));
            }
        }
        public RelayCommand _OpenItems6;

        public RelayCommand OpenItems6
        {
            get
            {
                return _OpenItems6 ?? (_OpenItems6 = new RelayCommand(obj =>
                {
                    i = 6;
                    _itemsSelectControl = new ItemsSelectUserControl();
                    CurrentCunt = _itemsSelectControl;
                }));
            }
        }
        public RelayCommand _OpenAuthAndRegist;

        public RelayCommand OpenAuthAndRegist
        {
            get
            {
                return _OpenAuthAndRegist ?? (_OpenAuthAndRegist = new RelayCommand(obj =>
                {
                    AuthAndRegistWindow authAndRegistWindow= new AuthAndRegistWindow();
                    authAndRegistWindow.Show();
                }));
            }
        }
        private RelayCommand _OpenAppeal;
        public RelayCommand OpenAppeal
        {
            get
            {
                return _OpenAppeal ?? (_OpenAppeal = new RelayCommand(obj =>
                {
                    if (LoginMod.LoginNow == null)
                    {
                        
                        MessageBox.Show("Вы еще не авторизовались");
                        return;
                    }
                    else
                    {
                        AppealWindow appealWindow = new AppealWindow();
                        appealWindow.Show();
                    }
                }));
            }
        }
        private RelayCommand _OpenMessage;
        public RelayCommand OpenMessage
        {
            get
            {
                return _OpenMessage ?? (_OpenMessage = new RelayCommand(obj =>
                {
                    if (LoginMod.LoginNow == null)
                    {

                        MessageBox.Show("Вы еще не авторизовались");
                        return;
                    }
                    else
                    {
                        MessageWindow messageWindow = new MessageWindow();
                        messageWindow.Show();
                    }
                }));
            }
        }
        public RelayCommand _RasschetCommand;

        public RelayCommand RasschetCommand
        {
            get
            {
                return _RasschetCommand ?? (_RasschetCommand = new RelayCommand(obj =>
                {
                    Rasch();
                    RasschetVM rasschetVM = new RasschetVM(sreddmg, alltime);
                    RasschetWindow rasschetWindow = new RasschetWindow(rasschetVM);
                    rasschetWindow.Show();
                }));
            }
        }
        public RelayCommand _OpenInfoPlayers;

        public RelayCommand OpenInfoPlayers
        {
            get
            {
                return _OpenInfoPlayers ?? (_OpenInfoPlayers = new RelayCommand(obj =>
                {
                    MainWindows mainWindows = new MainWindows();
                    mainWindows.Show();
                }));
            }
        }

    }
}
