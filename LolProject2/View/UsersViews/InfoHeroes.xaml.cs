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
using System.Windows.Shapes;
using LolProject2.ViewModels;
namespace LolProject2.View
{
    /// <summary>
    /// Логика взаимодействия для InfoHeroes.xaml
    /// </summary>
    public partial class InfoHeroes : Window
    {
        public MainVM Skills { get; set; }
        public InfoHeroes(MainVM vm)
        {
            InitializeComponent();
            Skills = vm;
            this.DataContext = Skills;
           
        }
      /*  public AnalitikProductViewModel Product { get; set; }
        public DeistviaProducts(AnalitikProductViewModel vm)
        {
            InitializeComponent();
            Product = vm;
            this.DataContext = Product; */
    }
}
