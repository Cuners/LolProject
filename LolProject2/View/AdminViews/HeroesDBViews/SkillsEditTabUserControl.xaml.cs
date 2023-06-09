using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LolProject2.ViewModels;
namespace LolProject2.View
{
    /// <summary>
    /// Логика взаимодействия для SkillsEditTabUserControl.xaml
    /// </summary>
    public partial class SkillsEditTabUserControl : UserControl
    {
        public SkillsTabVM Skills { get; set; } 
        public SkillsEditTabUserControl(SkillsTabVM vm)
        {
            InitializeComponent();
            Skills = vm;
            this.DataContext = vm;
        }
    }
}
