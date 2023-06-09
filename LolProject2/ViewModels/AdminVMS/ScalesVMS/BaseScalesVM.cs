using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LolProject2.View;
namespace LolProject2.ViewModels
{
    public class BaseScalesVM : ViewModel
    {
        public BaseScales _baseScales;
        public BaseScales BaseScales
        {
            get { return _baseScales; }
            set => Set(ref _baseScales, value);
        }
        public BaseScalesVM()
        {
            BaseScales = new BaseScales();
        }
        public BaseScalesVM(BaseScales baseScales)
        {
            BaseScales= baseScales;

        }
        private ScalesTabVMList _ScalesTabVMList;
        public ScalesTabVMList ScalesTabVMList
        {
            get { return _ScalesTabVMList; }
            set => Set(ref _ScalesTabVMList, value);
        }
    }
}
