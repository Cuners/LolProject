using LolProject2.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using LolProject2.Utils;
using LolProject2;
namespace LolProject2.ViewModels
{
    public class AuthAndRegistVM : ViewModel, ICloseWindow
    {
        private UserControl _authUserControl;
        private UserControl _registeredUserControl;
        private UserControl _adminUserControl;
        private UserControl currentControl;
        private UserControl _heroesUserControl;
        
        private UserControl _itemsUserControl;
        private UserControl _scalesUserControl;
        private UserControl _polzUserControl;
        private UserControl _appealsUserControl;
        public UserControl CurrentControl
        {
            get { return currentControl; }
            set => Set(ref currentControl, value);
        }

        private string _Login;
        public string Login
        {
            get { return _Login; }
            set => Set(ref _Login, value);
        }
        private string _Password;
        public string Password
        {
            get { return _Password; }
            set  
            {
                _Password = value;
                OnPropertyChanged("Password");
                if (string.IsNullOrEmpty(_RepeatedPass) && string.IsNullOrEmpty(_Password))
                {
                    EqualPass = "";
                }
                else if (RepeatedPass != Password || Password != RepeatedPass)
                {
                    EqualPass = "Пароли не совпадают";
                }
                else if (RepeatedPass == Password)
                {
                    EqualPass = "";
                }
            }
        }
        private string _EqualPass;
        public string EqualPass
        {
            get { return _EqualPass; }
            set=>Set(ref _EqualPass, value);
        }
        private string _RepeatedPass;
        public string RepeatedPass
        {
            get { return _RepeatedPass; }
            set
            {
                _RepeatedPass= value;
                OnPropertyChanged("RepeatedPas");
                if (string.IsNullOrEmpty(_RepeatedPass) && string.IsNullOrEmpty(_Password))
                {
                    EqualPass = "";
                }
                else if (RepeatedPass != Password || Password!=RepeatedPass)
                {
                    EqualPass = "Пароли не совпадают";
                }
                else if (RepeatedPass == Password)
                {
                    EqualPass = "";
                }
                
                
            }
        }
        private string _Email;
        public string Email
        {
            get { return _Email; }
            set => Set(ref _Email, value);
        }
        private DateTime _DateOfBirthday=DateTime.Now;
        public DateTime DateOfBirthday
        {
            get { return _DateOfBirthday; }
            set => Set(ref _DateOfBirthday, value);
        }
        public AuthAndRegistVM()
        {
            _authUserControl = new AuthUserControl();
            _registeredUserControl = new RegistUserControl();
            _adminUserControl = new AdminEnterUserControl();
            _heroesUserControl = new HeroesTablesUserControl();
            _itemsUserControl = new ItemsTalbesUserControl();
            _scalesUserControl = new ScalesTablesUserControl();
            _polzUserControl=new PolzovatelUserControl();
            _appealsUserControl=new AppealBaseUserControl();
            //_heroesEditUserControl=new HeroesEditTabUserControl(null);
            //ShowFirstUserControlCommand = new RelayCommand(ShowFirstUserControl);
            //ShowSecondUserControlCommand = new RelayCommand(ShowSecondUserControl);
            CurrentControl = _authUserControl;
            
        }
        public RelayCommand _ShowFirstUserControlCommand;

        public RelayCommand ShowFirstUserControlCommand
        {
            get
            {
                return _ShowFirstUserControlCommand ?? (_ShowFirstUserControlCommand = new RelayCommand(obj =>
                {
                    CurrentControl = _authUserControl;
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
                    CurrentControl = _registeredUserControl;
                }));
            }
        }
        public RelayCommand _ShowThirdUserControlCommand;

        public RelayCommand ShowThirdUserControlCommand
        {
            get
            {
                return _ShowSecondUserControlCommand ?? (_ShowSecondUserControlCommand = new RelayCommand(obj =>
                {
                    CurrentControl = _adminUserControl;
                }));
            }
        }
        public RelayCommand _ShowHeroesUserControlCommand;

        public RelayCommand ShowHeroesUserControlCommand
        {
            get
            {
                return _ShowHeroesUserControlCommand ?? (_ShowHeroesUserControlCommand = new RelayCommand(obj =>
                {
                    CurrentControl = _heroesUserControl;
                }));
            }
        }
        public RelayCommand _ShowItemsUserControlCommand;

        public RelayCommand ShowItemsUserControlCommand
        {
            get
            {
                return _ShowItemsUserControlCommand ?? (_ShowItemsUserControlCommand = new RelayCommand(obj =>
                {
                    CurrentControl = _itemsUserControl;
                }));
            }
        }
        private RelayCommand _ShowScalesUserControlCommand;

        public RelayCommand ShowScalesUserControlCommand
        {
            get
            {
                return _ShowScalesUserControlCommand ?? (_ShowScalesUserControlCommand = new RelayCommand(obj =>
                {
                    CurrentControl = _scalesUserControl;
                }));
            }
        }
        private RelayCommand _ShowPolzUserControlCommand;

        public RelayCommand ShowPolzUserControlCommand
        {
            get
            {
                return _ShowPolzUserControlCommand ?? (_ShowPolzUserControlCommand = new RelayCommand(obj =>
                {
                    CurrentControl = _polzUserControl;
                }));
            }
        }
        private RelayCommand _ShowAppealsUserControlCommand;

        public RelayCommand ShowAppealsUserControlCommand
        {
            get
            {
                return _ShowAppealsUserControlCommand ?? (_ShowAppealsUserControlCommand = new RelayCommand(obj =>
                {
                    CurrentControl = _appealsUserControl;
                }));
            }
        }
        public RelayCommand _RegistCommand;

        public RelayCommand RegistCommand
        {
            get
            {
                return _RegistCommand ?? (_RegistCommand = new RelayCommand(obj =>
                {
                    try
                    {
                        if (string.IsNullOrWhiteSpace(Login) || string.IsNullOrWhiteSpace(Password) || string.IsNullOrWhiteSpace(RepeatedPass) || string.IsNullOrWhiteSpace(Email))
                        {
                            MessageBox.Show("Вы не ввели что-то");
                            return;
                        }
                        else if(Password!=RepeatedPass){
                            MessageBox.Show("Пароли не совпадают");
                            return;
                        }
                        else
                        {
                            using (LOLPROJECTEntities lOLPROJECTEntities = new LOLPROJECTEntities())
                            {
                                string EncryptPass = EncryptDecryptMD5.Encrypt(Password);
                                Polzovatel polzovatel = new Polzovatel { Login = Login, Password = EncryptPass, DateOfBirth= DateOfBirthday,Email=Email,IdRole=2 };
                                lOLPROJECTEntities.Polzovatel.Add(polzovatel);
                                lOLPROJECTEntities.SaveChanges();
                                MessageBox.Show("Вы успешно зарегистрировались");
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Такой логин уже существует");
                    }
                }));
            }
        }
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
        public RelayCommand _AuthCommand;

        public RelayCommand AuthCommand
        {
            get
            {
                return _AuthCommand ?? (_AuthCommand = new RelayCommand(obj =>
                {
                    using (LOLPROJECTEntities lOLPROJECTEntities = new LOLPROJECTEntities())
                    {
                       
                        if (string.IsNullOrWhiteSpace(Login) || string.IsNullOrWhiteSpace(Password))
                        {
                            MessageBox.Show("Вы не ввели что-то");
                            return;
                        }
                        foreach (Polzovatel polzovatel in lOLPROJECTEntities.Polzovatel)
                        {
                            if (polzovatel.IdRole == 1 && polzovatel.Login==Login && EncryptDecryptMD5.Decrypt(polzovatel.Password)==Password)
                            {
                                LoginMod.LoginNow = Login;
                                CurrentControl=_adminUserControl;
                            } 
                            if(polzovatel.IdRole==2 && polzovatel.Login==Login && EncryptDecryptMD5.Decrypt(polzovatel.Password) == Password)
                            {
                                LoginMod.LoginNow = Login;
                                MessageBox.Show("Вы успшное авторизовались, теперь вы можете отправлять жалобы");
                                CloseWindow();
                                int i = 0;
                            }

                        }
                    }
                }));
            }
        }
    }
}
