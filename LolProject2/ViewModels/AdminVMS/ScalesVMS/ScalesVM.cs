using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LolProject2.ViewModels
{
    public class ScalesVM:ViewModel
    {
        public Scales _scales;
        public Scales Scales
        {
            get { return _scales; }
            set => Set(ref _scales, value);
        }
        public ScalesVM()
        {
            Scales = new Scales();
        }
        public ScalesVM(Scales scales)
        {
            Scales = scales;

        }
        private ScalesTabVMList _ScalesTabVMList;
        public ScalesTabVMList ScalesTabVMList
        {
            get { return _ScalesTabVMList; }
            set => Set(ref _ScalesTabVMList, value);
        }
    }
}
