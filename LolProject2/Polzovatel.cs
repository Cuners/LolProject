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
    public partial class Polzovatel : ViewModel
    {
        private string _login;
        public string Login 
        { 
            get { return _login; }
            set => Set(ref _login, value);
        }
        private string _password;
        public string Password 
        { 
            get { return _password; }
            set => Set(ref _password, value); 
        }
        private Nullable<System.DateTime> _dateOfBirth;
        public Nullable<System.DateTime> DateOfBirth 
        { 
            get { return _dateOfBirth;} 
            set => Set(ref _dateOfBirth, value); 
        }
        private string _email;
        public string Email 
        {
            get { return _email; }
            set => Set(ref _email, value); 
        }
        private Nullable<int> _idRole;
        public Nullable<int> IdRole 
        { 
            get { return _idRole; }
            set => Set(ref _idRole, value);
        }
    
        public virtual Roles Roles { get; set; }
    }
}
