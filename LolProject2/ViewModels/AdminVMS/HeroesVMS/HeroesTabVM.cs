using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using LolProject2.View;
using LolProject2.ViewModels;
namespace LolProject2.ViewModels
{
    public class HeroesTabVM : ViewModel
    {
        
        //  LoginsListViewModel loginListViewModel;

        public Heroes _heroes;
        public Heroes Heroes
        {
            get { return _heroes; }
            set => Set(ref _heroes, value);
        }
        public string _HeroName;
        public string HeroName
        {
            get { return _HeroName; }
            set=>Set(ref _HeroName, value);
        }
        public HeroesTabVM()
        {
            Heroes = new Heroes();
        }
        public HeroesTabVM(Heroes hero)
        {
            Heroes = hero;
            _HeroName = hero.NameHero;
        }
        
        public RelayCommand _OpenImageHero;

        public RelayCommand OpenImageHero
        {
            get
            {
                return _OpenImageHero ?? (_OpenImageHero = new RelayCommand(obj =>
                {
                    OpenFileDialog dlg = new OpenFileDialog()
                    {
                        Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" + "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" + "Portable Network Graphic (*.png)|*.png"
                    };
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        Heroes.ImageHero = File.ReadAllBytes(dlg.FileName);
                    }
                }));
            }
        }
        public RelayCommand _OpenImageHeroIcon;

        public RelayCommand OpenImageHeroIcon
        {
            get
            {
                return _OpenImageHeroIcon ?? (_OpenImageHeroIcon = new RelayCommand(obj =>
                {
                    OpenFileDialog dlg = new OpenFileDialog()
                    {
                        Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" + "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" + "Portable Network Graphic (*.png)|*.png"
                    };

                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        Heroes.ImageHeroIcon = File.ReadAllBytes(dlg.FileName);
                    }
                }));
            }
        }
        private HeroesTabVMList _HeroesTabVMList;
        public HeroesTabVMList HeroesTabVMList
        {
            get { return _HeroesTabVMList; }
            set => Set(ref _HeroesTabVMList, value);
        }
    }
}
