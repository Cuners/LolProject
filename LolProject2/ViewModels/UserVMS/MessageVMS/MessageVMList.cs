using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using LolProject2.View;
namespace LolProject2.ViewModels
{
    public class MessageVMList:ViewModel
    {
        private UserControl _messageAllControl;
        private UserControl _messageSeeControl;
        private UserControl _currentMessage;
        public UserControl CurrentMessage
        {
            get { return _currentMessage; }
            set=> Set(ref _currentMessage, value);
        }
        private List<Appeal> appeals;
        public List<Appeal> Appeals
        {
            get { return appeals; }
            set=>Set(ref appeals, value);
        }
        private Appeal selectedAppeal;
        public Appeal SelectedAppeal
        {
            get { return selectedAppeal; }
            set
            {
                selectedAppeal = value;
                OnPropertyChanged("SelectedAppeal");
                MessageVM messageVM = new MessageVM(selectedAppeal) { MessageVMList=this};
                _messageSeeControl = new MessageSeeUserControl(messageVM);
                CurrentMessage = _messageSeeControl;
            }
        }
        public RelayCommand _BackToMessageAll;

        public RelayCommand BackToMessageAll
        {
            get
            {
                return _BackToMessageAll ?? (_BackToMessageAll = new RelayCommand(obj =>
                {
                    _messageAllControl = new MessageAllUserControl();
                    CurrentMessage = _messageAllControl;
                }));
            }
        }
        public MessageVMList()
        {
            Appeals = new List<Appeal>();
            _messageAllControl = new MessageAllUserControl();
            using(LOLPROJECTEntities lOLPROJECTEntities=new LOLPROJECTEntities())
            {
                foreach(Appeal appeal in lOLPROJECTEntities.Appeal)
                {
                    if(appeal.User_login == LoginMod.LoginNow && appeal.Admin_Login != null)
                    {
                        Appeals.Add(appeal);
                    }
                }
            }
            CurrentMessage = _messageAllControl;
        }

    }
}
