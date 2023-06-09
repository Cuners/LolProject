using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LolProject2.Utils
{
    interface ICloseWindow
    {
        Action Close { get; set; }
        bool CanClose();
    }
}
