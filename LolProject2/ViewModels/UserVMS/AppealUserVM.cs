using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LolProject2.ViewModels
{
    public class AppealUserVM : ViewModel
    {
        private string _login = LoginMod.LoginNow;
        public string Login
        {
            get { return _login; }
            set=>Set(ref _login, value);
        }
        private string _tema;
        public string Tema
        {
            get { return _tema; }
            set => Set(ref _tema, value);
        }
        private string _opisanie;
        public string Opisanie
        {
            get { return _opisanie;}
            set=>Set(ref _opisanie, value);
        }
        private RelayCommand _OtpravkaAppeal;
        public RelayCommand OtpravkaAppea
        {
            get
            {
                return _OtpravkaAppeal ?? (_OtpravkaAppeal = new RelayCommand(obj =>
                {
                    if(string.IsNullOrWhiteSpace(Login) || string.IsNullOrWhiteSpace(Tema) || string.IsNullOrWhiteSpace(Opisanie))
                    {
                        MessageBox.Show("Вы не ввели что-то");
                        return;
                    }
                    using(LOLPROJECTEntities lOLPROJECT=new LOLPROJECTEntities())
                    {
                        Appeal appeal=new Appeal { User_login=Login, Opisanie=Opisanie, Tema=Tema,Status="Ожидается"};
                        lOLPROJECT.Appeal.Add(appeal);
                        lOLPROJECT.SaveChanges();
                        MessageBox.Show("Жалоба отправлена");
                    }
                }));
            }
        }
    }
}
