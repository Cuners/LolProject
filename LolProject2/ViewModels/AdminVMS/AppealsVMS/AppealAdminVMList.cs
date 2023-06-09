using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using LolProject2.View;
namespace LolProject2.ViewModels
{
    public class AppealAdminVMList : ViewModel
    {
        private UserControl _appealUserControl;
        private UserControl _appealEditUserControl;
        private UserControl _currentAppealControl;
        public UserControl CurrentAppealControl
        {
            get { return _currentAppealControl;}
            set=> Set(ref _currentAppealControl, value);
        }
        private List<Appeal> _appeal;
        public List<Appeal> Appeal
        {
            get { return _appeal; }
            set => Set(ref _appeal, value);
        }
        private string _user_login;
        public string User_login
        {
            get { return _user_login; }
            set =>Set (ref _user_login, value);
        }
        private string _tema;
        public string Tema
        {
            get { return _tema; }
            set=>Set(ref _tema, value);
        }
        private string _opisanie;
        public string Opisanie
        {
            get { return _opisanie;}
            set => Set(ref _opisanie, value);
        }
        private Appeal selectedAppeal;
        public Appeal SelectedAppeal
        {
            get { return selectedAppeal;}
            set
            {
                //BooksViewModel book=value;
                selectedAppeal = value;
                User_login = selectedAppeal.User_login;
                Tema=selectedAppeal.Tema;
                Opisanie = selectedAppeal.Opisanie;
                OnPropertyChanged("SelectedAppeal");
            }
        }
        public RelayCommand _ShowAppealAdminVM;

        public RelayCommand ShowAppealAdminVM
        {
            get
            {
                return _ShowAppealAdminVM ?? (_ShowAppealAdminVM = new RelayCommand(obj =>
                {
                    if (SelectedAppeal != null)
                    {
                        AppealAdminVM viewModel = new AppealAdminVM(selectedAppeal) { AppealAdminVMList = this };
                        _appealEditUserControl = new AppealEditUserControl(viewModel);
                        CurrentAppealControl= _appealEditUserControl;
                    }
                    else
                    {
                        MessageBox.Show("Вы не выбрали жалобу");
                        return;
                    }
                }));
            }
        }
        public void RemoveTovar(int appeal)
        {
            Appeal item = null;
            foreach (Appeal appeals in Appeal)
            {
                if (appeals.Id == appeal)
                {
                    item = appeals;
                    break;
                }
            }
            if (item != null)
            {
                Appeal.Remove(item);
            }
        }
        public RelayCommand _Addappeal { get; set; }
        private void Addappeal(object obj)
        {
           
            AppealAdminVM Appeal1=obj as AppealAdminVM;
            using (LOLPROJECTEntities tRPO = new LOLPROJECTEntities())
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(Appeal1.Appeal1.Tema) || string.IsNullOrWhiteSpace(Appeal1.Appeal1.Otvet))
                    {
                        MessageBox.Show("Присутствуют пробелы или строка пуста");
                    }
                    else
                    {
                        Appeal appeal = new Appeal
                        {
                            Id = Appeal1.Appeal1.Id,
                            Tema = Appeal1.Appeal1.Tema,
                            Opisanie = Appeal1.Appeal1.Opisanie,
                            User_login = Appeal1.Appeal1.User_login,
                            Admin_Login = Appeal1.Appeal1.Admin_Login,
                            Otvet = Appeal1.Appeal1.Otvet,
                            Status = "Отвечено"
                        };
                        tRPO.Entry(appeal).State = EntityState.Modified;
                        tRPO.SaveChanges();
                        _appealUserControl = new AppealUserControl();
                        CurrentAppealControl = _appealUserControl;
                        RemoveTovar(Appeal1.Appeal1.Id);
                    }
                    
                }
                catch
                {
                    MessageBox.Show("Такого не существует");
                }
            }
            OnPropertyChanged("Appeal");
        }
        public RelayCommand _BackToTable;

        public RelayCommand BackToTable
        {
            get
            {
                return _BackToTable ?? (_BackToTable = new RelayCommand(obj =>
                {
                    _appealUserControl = new AppealUserControl();
                    CurrentAppealControl = _appealUserControl;
                }));
            }
        }
        public AppealAdminVMList()
        {
            _appealUserControl=new AppealUserControl();
            
            Appeal = new List<Appeal>();
            using(LOLPROJECTEntities lOLPROJECT=new LOLPROJECTEntities())
            {
                foreach(Appeal appeals in lOLPROJECT.Appeal)
                {
                    if (appeals.Status == "Ожидается")
                    {
                        Appeal.Add(appeals);
                    }
                }
            }
            _Addappeal = new RelayCommand(Addappeal);
            CurrentAppealControl = _appealUserControl;
        }
    }
}
