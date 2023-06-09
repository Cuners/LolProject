using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LolProject2.View;
namespace LolProject2.ViewModels
{
    public class SkillsTabVM : ViewModel
    {
        public Skills _skills;
        public Skills Skills
        {
            get { return _skills; }
            set => Set(ref _skills, value);
        }
        public SkillsTabVM()
        {
            Skills = new Skills();
        }
        public SkillsTabVM(Skills skills)
        {
            Skills = skills;

        }
        public RelayCommand _OpenImageSkill;

        public RelayCommand OpenImageSkill
        {
            get
            {
                return _OpenImageSkill ?? (_OpenImageSkill = new RelayCommand(obj =>
                {
                    OpenFileDialog dlg = new OpenFileDialog()
                    {
                        Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" + "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" + "Portable Network Graphic (*.png)|*.png"
                    };
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        Skills.ImageSkill = File.ReadAllBytes(dlg.FileName);
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
