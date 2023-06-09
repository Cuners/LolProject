using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LolProject2.ViewModels;
namespace LolProject2.ViewModels
{
    public class RasschetVM : ViewModel
    {
        private double damage;
        public double Damage
        {
            get { return damage; }
            set=>Set(ref damage, value);
        }
        private double timer;
        public double Timer
        {
            get { return timer; }
            set=>Set(ref timer, value);
        }
        public RasschetVM()
        {
            Damage = 0;
            Timer = 0;
        }
        public RasschetVM(double dmg,double time)
        {
            Damage = dmg;
            Timer = time;
        }
    }
}
