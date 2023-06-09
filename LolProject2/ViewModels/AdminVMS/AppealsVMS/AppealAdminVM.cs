using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LolProject2.ViewModels;
namespace LolProject2.ViewModels
{
    public class AppealAdminVM : ViewModel
    {
        public Appeal _appeal;
        public Appeal Appeal1
        {
            get { return _appeal; }
            set=>Set(ref _appeal, value);
        }
        public AppealAdminVM()
        {
            Appeal1 = new Appeal();
        }
        public AppealAdminVM(Appeal appeal)
        {
            _appeal = appeal;
            _appeal.Admin_Login = LoginMod.LoginNow;
        }
        private AppealAdminVMList _appealAdminVMList;
        public AppealAdminVMList AppealAdminVMList
        {
            get { return _appealAdminVMList; }
            set=> Set(ref _appealAdminVMList, value);
        }
        
    }
}
