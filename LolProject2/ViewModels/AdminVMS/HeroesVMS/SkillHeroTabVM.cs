using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LolProject2.ViewModels
{
    public class SkillHeroTabVM : ViewModel
    {
        public Skill_Hero _skillsHero;
        public Skill_Hero SkillsHero
        {
            get { return _skillsHero; }
            set => Set(ref _skillsHero, value);
        }
        public SkillHeroTabVM()
        {
            SkillsHero = new Skill_Hero();
        }
        public SkillHeroTabVM(Skill_Hero skillsHero)
        {
            SkillsHero = skillsHero;

        }
        private HeroesTabVMList _HeroesTabVMList;
        public HeroesTabVMList HeroesTabVMList
        {
            get { return _HeroesTabVMList; }
            set => Set(ref _HeroesTabVMList, value);
        }
    }
}
