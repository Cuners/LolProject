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
    public partial class Scales : ViewModel
    {
        private string _nameHero;
        public string NameHero 
        { 
            get { return _nameHero; }   
            set => Set(ref _nameHero, value); 
        }
        private Nullable<double> _damage;
        public Nullable<double> Damage 
        { 
            get { return _damage; }
            set => Set(ref _damage, value); 
        }
        private Nullable<double> _armor;
        public Nullable<double> Armor 
        { 
            get { return _armor; }
            set => Set(ref _armor, value); 
        }
        public int Id { get; set; }
        private Nullable<double> _health;
        public Nullable<double> Health 
        { 
            get { return _health; }
            set => Set(ref _health, value);
        }
        private Nullable<double> _mana;
        public Nullable<double> Mana 
        { 
            get { return _mana; }
            set => Set(ref _mana, value);
        }
        private Nullable<double> _resistMagic;
        public Nullable<double> ResistMagic 
        { 
            get { return _resistMagic; }
            set => Set(ref _resistMagic, value);
        }
    
        public virtual Heroes Heroes { get; set; }
    }
}
