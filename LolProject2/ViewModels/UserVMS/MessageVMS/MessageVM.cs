using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LolProject2.ViewModels
{
    public class MessageVM : ViewModel
    {
        private Appeal appeal;
        public Appeal Appeal
        {
            get { return appeal; }
            set=> Set(ref appeal, value);
        }
        public MessageVM()
        {
            Appeal = new Appeal();
        }
        public MessageVM(Appeal appealnow)
        {
            Appeal = appealnow;
        }
        private MessageVMList messageVMList;
        public MessageVMList MessageVMList
        {
            get { return messageVMList; }
            set=> Set(ref messageVMList, value);
        }
    }
}
