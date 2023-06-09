using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LolProject2.View;
namespace LolProject2.ViewModels
{
    public class PolzovatelVM :ViewModel
    {
       private Polzovatel _polzovatel;
       public Polzovatel Polzovatel
       {
            get { return _polzovatel; }
            set=> Set(ref _polzovatel, value);
       }
        private string _login;
        public string Login
        {
            get { return _login; }
            set=> Set(ref _login, value);
        }
       public PolzovatelVM()
        {
            Polzovatel = new Polzovatel();
        }
        public PolzovatelVM(Polzovatel polzovatel)
        {
            _polzovatel = polzovatel;
            _login = polzovatel.Login;
        }
        private PolzovatelVMList _polzovatelVMList;
        public PolzovatelVMList PolzovatelVMList
        {
            get { return _polzovatelVMList; }
            set => Set(ref _polzovatelVMList, value);
        }
    }
}
