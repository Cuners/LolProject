using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LolProject2.ViewModels;
namespace LolProject2
{
    public class BaseScalesStore : ViewModel
    {
        public BaseScalesStore(BaseScales baseScales)
        {
            this.NameHero = baseScales.NameHero;
            this.AD=baseScales.AD;
            this.Health=baseScales.Health;
            this.Armor=baseScales.Armor;
            this.Mana=baseScales.Mana;
            this.ID=baseScales.ID;
            this.ResistMagic=baseScales.ResistMagic;
            this.Crit=baseScales.Crit;
            this.MoveSpeed=baseScales.MoveSpeed;
            this.Speed_Attack=baseScales.Speed_Attack;
        }
        public BaseScalesStore()
        {

        }
        public string NameHero { get; set; }
        private Nullable<double> _Health;
        public Nullable<double> Health
        {
            get { return _Health; }
            set => Set(ref _Health, value);
        }
        private Nullable<double> _Armor;
        public Nullable<double> Armor
        {
            get { return _Armor; }
            set => Set(ref _Armor, value);
        }
        private Nullable<double> _Mana;
        public Nullable<double> Mana
        {
            get { return _Mana; }
            set => Set(ref _Mana, value);
        }
        private Nullable<double> _AD;
        public Nullable<double> AD
        {
            get { return _AD; }
            set => Set(ref _AD, value);
        }
        private Nullable<double> _ResistMagic;
        public Nullable<double> ResistMagic
        {
            get { return _ResistMagic; }
            set => Set(ref _ResistMagic, value);
        }
        private Nullable<double> _Crit;
        public Nullable<double> Crit
        {
            get { return _Crit; }
            set => Set(ref _Crit, value);
        }
        private Nullable<double> _MoveSpeed;
        public Nullable<double> MoveSpeed
        {
            get { return _MoveSpeed; }
            set => Set(ref _MoveSpeed, value);
        }
        private Nullable<double> _Speed_Attack;
        public Nullable<double> Speed_Attack
        {
            get { return _Speed_Attack; }
            set => Set(ref _Speed_Attack, value);
        }

        public int ID { get; set; }

        public virtual Heroes Heroes { get; set; }
    }
}
