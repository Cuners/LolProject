//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LolProject2
{
    using System;
    using System.Collections.Generic;
    using LolProject2.ViewModels;
    public partial class BaseScales : ViewModel
    {
        private string _nameHero;
        public string NameHero 
        { 
            get { return _nameHero; }
            set => Set(ref _nameHero, value);
        }
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
