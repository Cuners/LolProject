using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace LolProject2.ViewModels
{
    public class MainVM:ViewModel
    {
        #region Heroes
        private string _NameHero;
        public string NameHero
        {
            get { return _NameHero; }
            set=>Set(ref _NameHero, value);
        }
        private byte[] _ImageHero;
        public byte[] ImageHero
        {
            get { return _ImageHero; }
            set => Set(ref _ImageHero, value);
        }
        private byte[] _ImageHeroIcon;
        public byte[] ImageHeroIcon
        {
            get { return _ImageHeroIcon; }
            set => Set(ref _ImageHeroIcon, value);
        }
        private int _Level;
        public int Level
        {
            get {  return _Level; }
            set
            {
                _Level = value;
                foreach (var basescales in _BaseScales)
                {
                    foreach (var scales in _Scales)
                    {
                            basescales.AD = BaseScales2.AD + scales.Damage * Convert.ToDouble(Level);
                            basescales.Armor =BaseScales2.Armor+ scales.Armor * Convert.ToDouble(Level);
                            basescales.Health =BaseScales2.Health + scales.Health * Convert.ToDouble(Level);
                            basescales.Mana = BaseScales2.Mana + scales.Mana * Convert.ToDouble(Level);
                            basescales.ResistMagic = BaseScales2.ResistMagic + scales.ResistMagic * Convert.ToDouble(Level);
                    }
                }

                OnPropertyChanged("Level");
                
            }
            
        }
        private List<Skills> _Skills;
        public List<Skills> Skills
        {
            get { return _Skills; }
            set => Set(ref _Skills, value);
        }
        private List<BaseScales> _BaseScales;
        public List<BaseScales> BaseScales
        {
            get { return _BaseScales; }
            set =>Set(ref _BaseScales, value);
           
        }
        private BaseScalesStore _BaseScales2;
        public BaseScalesStore BaseScales2
        {
            get { return _BaseScales2; }
            set => Set(ref _BaseScales2, value);

        }

        private List<Scales> _Scales;
        public List<Scales> Scales
        {
            get { return _Scales; }
            set => Set(ref _Scales, value);
        }
        private MainListVM _MainListVM;
        public MainListVM MainListVM
        {
            get { return _MainListVM; }
            set =>Set(ref _MainListVM, value);
        }
        #endregion
       
        public MainVM()
        {
            
        }
        public MainVM(Heroes heroes)
        {
            
            _NameHero = heroes.NameHero;
            _ImageHero = heroes.ImageHero;
            _Skills = new List<Skills>();
            _BaseScales = new List<BaseScales>();
            
            _Scales=new List<Scales>();
            using (LOLPROJECTEntities lOLPROJECT = new LOLPROJECTEntities())
            {
                foreach (Heroes heroes1 in lOLPROJECT.Heroes)
                {
                    if (heroes.NameHero == heroes1.NameHero)
                    {
                        foreach (Skill_Hero skill_Hero in lOLPROJECT.Skill_Hero)
                        {
                            if (skill_Hero.NameHero == heroes1.NameHero)
                            {
                                foreach (Skills skills in lOLPROJECT.Skills)
                                {
                                    if (skill_Hero.Nameskill == skills.NameSkills)
                                    {
                                        _Skills.Add(skill_Hero.Skills);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            
            using (LOLPROJECTEntities loLPROJECT = new LOLPROJECTEntities())
            {
                foreach(Heroes heroes1 in loLPROJECT.Heroes)
                {
                    if(heroes.NameHero == heroes1.NameHero)
                    {
                        foreach(BaseScales baseScales in loLPROJECT.BaseScales)
                        {
                            if (baseScales.NameHero == heroes1.NameHero)
                            {
                                _BaseScales.Add(baseScales);
                                _BaseScales2 = new BaseScalesStore(baseScales);
                            }
                        }
                    }
                }
            }
            
            using (LOLPROJECTEntities loLPROJECT = new LOLPROJECTEntities())
            {
                foreach (Heroes heroes1 in loLPROJECT.Heroes)
                {
                    if (heroes.NameHero == heroes1.NameHero)
                    {
                        foreach (Scales scales in loLPROJECT.Scales)
                        {
                            if (scales.NameHero == heroes1.NameHero)
                            {
                                _Scales.Add(scales);
                            }
                        }
                    }
                }
            }
            _ImageHeroIcon = heroes.ImageHeroIcon;
            
        }

    }
}
