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
    public partial class Items_Difference : ViewModel
    {
        public int Id { get; set; }
        private Nullable<int> _id_Item;
        public Nullable<int> Id_Item 
        { 
            get { return _id_Item; }
            set =>  Set(ref _id_Item, value);
        }
        private Nullable<int> _id_Diff;
        public Nullable<int> Id_Diff 
        { 
            get { return _id_Diff; } 
            set => Set(ref _id_Diff, value); 
        }
    
        public virtual Items Items { get; set; }
        public virtual ItemsDifferents ItemsDifferents { get; set; }
    }
}
