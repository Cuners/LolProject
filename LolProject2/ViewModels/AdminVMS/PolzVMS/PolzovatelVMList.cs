using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using LolProject2.View;
namespace LolProject2.ViewModels
{
    public class PolzovatelVMList : ViewModel
    {
        private UserControl _polzovatelTabControl;
        private UserControl _polzovatelEditTabControl;
        private UserControl _currentControlPolz;
        public UserControl CurrentControlPolz
        {
            get { return _currentControlPolz; }
            set => Set(ref _currentControlPolz, value);
        }
        private List<Polzovatel> _polzovatels;
        public List<Polzovatel> Polzovatels
        {
            get { return _polzovatels; }
            set=>Set(ref _polzovatels, value);
        }
        private Polzovatel selectedPolz;
        public Polzovatel SelectedPolz
        {
            get { return selectedPolz; }
            set
            {

                selectedPolz = value;
                if (selectedPolz!=null)
                {
                    
                    PolzovatelVM viewModel = new PolzovatelVM(selectedPolz) { PolzovatelVMList = this };
                    OnPropertyChanged("SelectedPolz");
                    _polzovatelEditTabControl = new PolzovatelEditTabUserControl(viewModel);
                    CurrentControlPolz = _polzovatelEditTabControl;
                }
                else
                {
                    return;
                }

            }
        }
        public RelayCommand _BackToTable;

        public RelayCommand BackToTable
        {
            get
            {
                return _BackToTable ?? (_BackToTable = new RelayCommand(obj =>
                {
                    _polzovatelTabControl = new PolzovatelTabUserControl();
                    CurrentControlPolz = _polzovatelTabControl;
                    
                }));
            }
        }
        public RelayCommand _ShowPolzAdd;

        public RelayCommand ShowPolzAdd
        {
            get
            {
                return _ShowPolzAdd ?? (_ShowPolzAdd = new RelayCommand(obj =>
                {
                    _polzovatelEditTabControl = new PolzovatelEditTabUserControl(new PolzovatelVM() { PolzovatelVMList = this });
                    CurrentControlPolz = _polzovatelEditTabControl;
                }));
            }
        }
        public RelayCommand _PolzAddEdit;

        public RelayCommand PolzAddEdit
        {
            get
            {
                return _PolzAddEdit ?? (_PolzAddEdit = new RelayCommand(obj =>
                {
                    PolzovatelVM polzovatelVM = obj as PolzovatelVM;
                    if (polzovatelVM.Polzovatel.Login != null)
                    {
                        using (LOLPROJECTEntities tRPO = new LOLPROJECTEntities())
                        {
                            try
                            {
                                Polzovatel polz = new Polzovatel
                                {
                                    Login = polzovatelVM.Polzovatel.Login,
                                    Password = polzovatelVM.Polzovatel.Password,
                                    DateOfBirth = polzovatelVM.Polzovatel.DateOfBirth,
                                    Email = polzovatelVM.Polzovatel.Email,
                                    IdRole = polzovatelVM.Polzovatel.IdRole
                                };
                                tRPO.Entry(polz).State = EntityState.Modified;
                                tRPO.SaveChanges();

                                CurrentControlPolz = _polzovatelTabControl;
                                //RemoveTovar(selectedAppeal.Id);
                            }
                            catch
                            {
                                MessageBox.Show("Сначала удалите связанные данные");
                            }
                        }
                    }
                    else
                    {
                        using (LOLPROJECTEntities tRPO = new LOLPROJECTEntities())
                        {
                            try
                            {
                                Polzovatel polz = new Polzovatel
                                {
                                    Login = polzovatelVM.Polzovatel.Login,
                                    Password = polzovatelVM.Polzovatel.Password,
                                    DateOfBirth = polzovatelVM.Polzovatel.DateOfBirth,
                                    Email = polzovatelVM.Polzovatel.Email,
                                    IdRole = polzovatelVM.Polzovatel.IdRole
                                };
                                tRPO.Entry(polz).State = EntityState.Added;
                                tRPO.SaveChanges();
                                Polzovatels.Add(polz);
                                CurrentControlPolz = _polzovatelTabControl;
                                //RemoveTovar(selectedAppeal.Id);
                            }
                            catch
                            {
                                MessageBox.Show("Сначала удалите связанные данные");
                            }
                        }
                    }
                }));
            }
        }
        public RelayCommand _PolzDelete;

        public RelayCommand PolzDelete
        {
            get
            {
                return _PolzDelete ?? (_PolzDelete = new RelayCommand(obj =>
                {
                    PolzovatelVM polzovatelVM = obj as PolzovatelVM;
                    
                        using (LOLPROJECTEntities tRPO = new LOLPROJECTEntities())
                        {
                            try
                            {
                                Polzovatel polz = new Polzovatel
                                {
                                    Login = polzovatelVM.Polzovatel.Login,
                                    Password = polzovatelVM.Polzovatel.Password,
                                    DateOfBirth = polzovatelVM.Polzovatel.DateOfBirth,
                                    Email = polzovatelVM.Polzovatel.Email,
                                    IdRole = polzovatelVM.Polzovatel.IdRole
                                };
                                tRPO.Entry(polz).State = EntityState.Deleted;
                                tRPO.SaveChanges();
                            RemovePolz(polzovatelVM.Polzovatel.Login);
                                CurrentControlPolz = _polzovatelTabControl;
                                //RemoveTovar(selectedAppeal.Id);
                            }
                            catch
                            {
                                MessageBox.Show("Сначала удалите связанные данные");
                            }
                        }
                    
                }));
            }
        }
        
        public void RemovePolz(string polzovatel)
        {
            Polzovatel item = null;
            foreach (Polzovatel polz1 in Polzovatels)
            {
                if (polz1.Login == polzovatel)
                {
                    item = polz1;
                    break;
                }
            }
            if (item != null)
            {
                Polzovatels.Remove(item);
            }
        }

        public PolzovatelVMList()
        {
            _polzovatelTabControl = new PolzovatelTabUserControl();
            using(LOLPROJECTEntities lOLPROJECTEntities = new LOLPROJECTEntities())
            {
                Polzovatels=new List<Polzovatel>(lOLPROJECTEntities.Polzovatel);
            }
            
            CurrentControlPolz = _polzovatelTabControl;
        }
    }
}
