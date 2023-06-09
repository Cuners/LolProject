using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using LolProject2.View;
using LolProject2.ViewModels;
namespace LolProject2.ViewModels
{
    public class HeroesTabVMList : ViewModel
    {
        private UserControl _heroesTabControl;
        private UserControl _heroesEditTabControl;
        private UserControl _skillsTabControl;
        private UserControl _skillsEditTabControl;
        private UserControl _skillsHeroTabUserControl;
        private UserControl _skillsHeroEditTabUserControl;
        private UserControl currentControl2;
        private UserControl currentControlSkills;
        private UserControl currentControlSkillsHero;
        public UserControl CurrentControl2
        {
            get { return currentControl2; }
            set => Set(ref currentControl2, value);
        }
        public UserControl CurrentControlSkills
        {
            get { return currentControlSkills; }
            set => Set(ref currentControlSkills, value);
        }
        public UserControl CurrentControlSkillHero
        {
            get { return currentControlSkillsHero; }
            set=>Set(ref currentControlSkillsHero, value);
        }
        private List<Heroes> _heroes;
        public List<Heroes> Heroes
        {
            get { return _heroes; }
            set => Set(ref _heroes, value);
        }
        private List<Skills> _skills;
        public List<Skills> Skills
        {
            get { return _skills; }
            set=>Set(ref _skills, value);
        }
        private List<Skill_Hero> _skillsHero;
        public List<Skill_Hero> SkillHeroes
        {
            get { return _skillsHero; }
            set => Set(ref _skillsHero, value);
        }
        private Heroes selectedHero;
        public Heroes SelectedHero
        {
            get { return selectedHero; }
            set
            {
              
                selectedHero = value;
                if (SelectedHero != null)
                {
                    OnPropertyChanged("SelectedHero");
                    HeroesTabVM viewModel = new HeroesTabVM(selectedHero) { HeroesTabVMList = this };
                   
                    _heroesEditTabControl = new HeroesEditTabUserControl(viewModel);
                    CurrentControl2 = _heroesEditTabControl;
                }
                else
                {
                    return;
                }

            }
        }
        private Skills selectedSkill;
        public Skills SelectedSkill
        {
            get { return selectedSkill; }
            set
            {
                selectedSkill = value;
                if (SelectedSkill != null)
                {
                    OnPropertyChanged("SelectedSkill");
                    SkillsTabVM viewModel = new SkillsTabVM(selectedSkill) { HeroesTabVMList = this };
                    _skillsEditTabControl = new SkillsEditTabUserControl(viewModel);
                    CurrentControlSkills = _skillsEditTabControl;
                }
                else
                {
                    return;
                }

            }
        }
        private Skill_Hero selectedSkillHero;
        public Skill_Hero SelectedSkillHero
        {
            get { return selectedSkillHero; }
            set
            {
                selectedSkillHero = value;
                if (SelectedSkillHero != null)
                {
                    OnPropertyChanged("SelectedSkillHero");
                    SkillHeroTabVM viewModel = new SkillHeroTabVM(selectedSkillHero) { HeroesTabVMList = this };
                    _skillsHeroEditTabUserControl = new SkillHeroEditTabUserControl(viewModel);
                    CurrentControlSkillHero = _skillsHeroEditTabUserControl;
                }
                else
                {
                    return;
                }

            }
        }
        #region HeroesTabEdit
        public RelayCommand _BackToTableHero;

        public RelayCommand BackToTableHero
        {
            get
            {
                return _BackToTableHero ?? (_BackToTableHero = new RelayCommand(obj =>
                {
                    _heroesTabControl = new HeroesTabUserControl();
                    CurrentControl2 = _heroesTabControl;
                }));
            }
        }
        public RelayCommand _HeroesAddEdit;

        public RelayCommand HeroesAddEdit
        {
            get
            {
                return _HeroesAddEdit ?? (_HeroesAddEdit = new RelayCommand(obj =>
                {
                    HeroesTabVM Hero1 = obj as HeroesTabVM;
                    if (Hero1.HeroName != null)
                    {
                        using (LOLPROJECTEntities tRPO = new LOLPROJECTEntities())
                        {
                            try
                            {
                                if (string.IsNullOrWhiteSpace(Hero1.Heroes.NameHero))
                                {
                                    MessageBox.Show("Вы что-то не ввели");
                                    return;
                                }
                                else
                                {
                                    Heroes appeal = new Heroes
                                    {
                                        NameHero = Hero1.Heroes.NameHero,
                                        ImageHero = Hero1.Heroes.ImageHero,
                                        ImageHeroIcon = Hero1.Heroes.ImageHeroIcon
                                    };
                                    tRPO.Entry(appeal).State = EntityState.Modified;
                                    tRPO.SaveChanges();

                                    CurrentControl2 = _heroesTabControl;
                                }
                                //RemoveTovar(selectedAppeal.Id);
                            }
                            catch
                            {
                                MessageBox.Show("Вы что-то не ввели");
                            }
                        }
                    }
                    else
                    {
                        using (LOLPROJECTEntities tRPO = new LOLPROJECTEntities())
                        {
                            try
                            {
                                if (string.IsNullOrWhiteSpace(Hero1.Heroes.NameHero))
                                {
                                    MessageBox.Show("Вы что-то не ввели");
                                    return;
                                }
                                else
                                {
                                    Heroes appeal = new Heroes
                                    {
                                        NameHero = Hero1.Heroes.NameHero,
                                        ImageHero = Hero1.Heroes.ImageHero,
                                        ImageHeroIcon = Hero1.Heroes.ImageHeroIcon
                                    };
                                    tRPO.Entry(appeal).State = EntityState.Added;
                                    tRPO.SaveChanges();
                                    Heroes.Add(appeal);
                                    CurrentControl2 = _heroesTabControl;
                                    //RemoveTovar(selectedAppeal.Id);
                                }
                            }
                            catch
                            {
                                MessageBox.Show("Вы что-то не ввели");
                            }
                        }
                    }
                }));
            }
        }
        public RelayCommand _HeroesDelete;

        public RelayCommand HeroesDelete
        {
            get
            {
                return _HeroesDelete ?? (_HeroesDelete = new RelayCommand(obj =>
                {
                    HeroesTabVM Hero1 = obj as HeroesTabVM;
                    
                        using (LOLPROJECTEntities tRPO = new LOLPROJECTEntities())
                        {
                            try
                            {
                                Heroes appeal = new Heroes
                                {
                                    NameHero = Hero1.Heroes.NameHero,
                                    ImageHero = Hero1.Heroes.ImageHero,
                                    ImageHeroIcon = Hero1.Heroes.ImageHeroIcon
                                };
                                tRPO.Entry(appeal).State = EntityState.Deleted;
                                tRPO.SaveChanges();
                                RemoveHero(Hero1.Heroes.NameHero);
                                CurrentControl2 = _heroesTabControl;
                                
                            }
                            catch
                            {
                                MessageBox.Show("Сначала удалите связанные данные");
                            }
                        }
                   
                }));
            }
        }
        public void RemoveHero(string hero)
        {
            Heroes item = null;
            foreach (Heroes hero1 in Heroes)
            {
                if (hero1.NameHero == hero)
                {
                    item = hero1;
                    break;
                }
            }
            if (item != null)
            {
                Heroes.Remove(item);
            }
        }
        #endregion
        #region SkillHeroTabEdit
        public RelayCommand _BackToTableSkillHero;

        public RelayCommand BackToTableSkillHero
        {
            get
            {
                return _BackToTableSkillHero ?? (_BackToTableSkillHero = new RelayCommand(obj =>
                {
                    _skillsHeroTabUserControl = new SkillHeroTabUserControl();
                    CurrentControlSkillHero = _skillsHeroTabUserControl;
                }));
            }
        }
        public RelayCommand _SkillHeroAddEdit;

        public RelayCommand SkillHeroAddEdit
        {
            get
            {
                return _SkillHeroAddEdit ?? (_SkillHeroAddEdit = new RelayCommand(obj =>
                {
                    SkillHeroTabVM SkillHero1 = obj as SkillHeroTabVM;
                    if (SkillHero1.SkillsHero.Id != 0)
                    {
                        using (LOLPROJECTEntities tRPO = new LOLPROJECTEntities())
                        {
                            try
                            {
                                if(string.IsNullOrWhiteSpace(SkillHero1.SkillsHero.NameHero) || string.IsNullOrEmpty(SkillHero1.SkillsHero.Nameskill))
                                {
                                    MessageBox.Show("Вы что-то не ввели");
                                    return;
                                }
                                Skill_Hero skillhero = new Skill_Hero
                                {
                                    Id = SkillHero1.SkillsHero.Id,
                                    Nameskill = SkillHero1.SkillsHero.Nameskill,
                                    NameHero = SkillHero1.SkillsHero.NameHero
                                };
                                tRPO.Entry(skillhero).State = EntityState.Modified;
                                tRPO.SaveChanges();

                                CurrentControlSkillHero = _skillsHeroTabUserControl;
                                //RemoveTovar(selectedAppeal.Id);
                            }
                            catch
                            {
                                MessageBox.Show("Вы что-то не ввели");
                            }
                        }
                    }
                    else
                    {
                        using (LOLPROJECTEntities tRPO = new LOLPROJECTEntities())
                        {
                            try
                            {
                                if (string.IsNullOrWhiteSpace(SkillHero1.SkillsHero.NameHero) || string.IsNullOrEmpty(SkillHero1.SkillsHero.Nameskill))
                                {
                                    MessageBox.Show("Вы что-то не ввели");
                                    return;
                                }
                                else
                                {
                                    Skill_Hero skillhero = new Skill_Hero
                                    {
                                        Id = SkillHero1.SkillsHero.Id,
                                        Nameskill = SkillHero1.SkillsHero.Nameskill,
                                        NameHero = SkillHero1.SkillsHero.NameHero
                                    };
                                    tRPO.Entry(skillhero).State = EntityState.Added;
                                    tRPO.SaveChanges();
                                    SkillHeroes.Add(skillhero);
                                    CurrentControlSkillHero = _skillsHeroTabUserControl;
                                }
                            }
                            catch
                            {
                                MessageBox.Show("Вы что-то не ввели");
                            }
                        }
                    }
                }));
            }
        }
        public RelayCommand _SkillHeroDelete;

        public RelayCommand SkillHeroDelete
        {
            get
            {
                return _SkillHeroDelete ?? (_SkillHeroDelete = new RelayCommand(obj =>
                {
                    SkillHeroTabVM SkillHero1 = obj as SkillHeroTabVM;

                    using (LOLPROJECTEntities tRPO = new LOLPROJECTEntities())
                    {
                        try
                        {
                            Skill_Hero skillhero = new Skill_Hero
                            {
                                Id = SkillHero1.SkillsHero.Id,
                                Nameskill = SkillHero1.SkillsHero.Nameskill,
                                NameHero = SkillHero1.SkillsHero.NameHero
                            };
                            tRPO.Entry(skillhero).State = EntityState.Deleted;
                            tRPO.SaveChanges();
                            RemoveSkillHero(SkillHero1.SkillsHero.Id);
                            CurrentControlSkillHero = _skillsHeroTabUserControl;

                        }
                        catch
                        {
                            MessageBox.Show("Ошибка");
                        }
                    }

                }));
            }
        }
        public void RemoveSkillHero(int idskillhero)
        {
            Skill_Hero item = null;
            foreach (Skill_Hero skillhero in SkillHeroes)
            {
                if (skillhero.Id == idskillhero)
                {
                    item = skillhero;
                    break;
                }
            }
            if (item != null)
            {
                SkillHeroes.Remove(item);
            }
        }
        #endregion
        #region SkillTabEdit
        public RelayCommand _BackToTableSkill;

        public RelayCommand BackToTableSkill
        {
            get
            {
                return _BackToTableHero ?? (_BackToTableHero = new RelayCommand(obj =>
                {
                    _skillsTabControl = new SkillsTabUserControl();
                    CurrentControlSkills = _skillsTabControl;
                }));
            }
        }
        public RelayCommand _SkillAddEdit;

        public RelayCommand SkillAddEdit
        {
            get
            {
                return _SkillAddEdit ?? (_SkillAddEdit = new RelayCommand(obj =>
                {
                    SkillsTabVM Skill = obj as SkillsTabVM;
                    if (Skill.Skills.ID != 0)
                    {
                        using (LOLPROJECTEntities tRPO = new LOLPROJECTEntities())
                        {
                            try
                            {
                                if (string.IsNullOrWhiteSpace(Skill.Skills.NameSkills) || string.IsNullOrEmpty(Skill.Skills.Opisanie))
                                {
                                    MessageBox.Show("Вы что-то не ввели");
                                    return;
                                }
                                else
                                {
                                    Skills skill = new Skills
                                    {
                                        ID = Skill.Skills.ID,
                                        NameSkills = Skill.Skills.NameSkills,
                                        Opisanie = Skill.Skills.Opisanie,
                                        ImageSkill = Skill.Skills.ImageSkill
                                    };
                                    tRPO.Entry(skill).State = EntityState.Modified;
                                    tRPO.SaveChanges();

                                    CurrentControlSkills = _skillsTabControl;
                                }
                                //RemoveTovar(selectedAppeal.Id);
                            }
                            catch
                            {
                                MessageBox.Show("Вы что-то не ввели");
                            }
                        }
                    }
                    else
                    {
                        using (LOLPROJECTEntities tRPO = new LOLPROJECTEntities())
                        {
                            try
                            {
                                if (string.IsNullOrWhiteSpace(Skill.Skills.NameSkills) || string.IsNullOrEmpty(Skill.Skills.Opisanie))
                                {
                                    MessageBox.Show("Вы что-то не ввели");
                                    return;
                                }
                                else
                                {
                                    Skills skill = new Skills
                                    {
                                        ID = Skill.Skills.ID,
                                        NameSkills = Skill.Skills.NameSkills,
                                        Opisanie = Skill.Skills.Opisanie,
                                        ImageSkill = Skill.Skills.ImageSkill
                                    };
                                    tRPO.Entry(skill).State = EntityState.Added;
                                    tRPO.SaveChanges();
                                    Skills.Add(skill);
                                    CurrentControlSkills = _skillsTabControl;
                                }
                            }
                            catch
                            {
                                MessageBox.Show("Вы что-то не ввели");
                            }
                        }
                    }
                }));
            }
        }
        public RelayCommand _SkillDelete;

        public RelayCommand SkillDelete
        {
            get
            {
                return _SkillDelete ?? (_SkillDelete = new RelayCommand(obj =>
                {
                    SkillsTabVM Skill = obj as SkillsTabVM;

                    using (LOLPROJECTEntities tRPO = new LOLPROJECTEntities())
                    {
                        try
                        {
                            Skills skill = new Skills
                            {
                                ID = Skill.Skills.ID,
                                NameSkills = Skill.Skills.NameSkills,
                                Opisanie = Skill.Skills.Opisanie,
                                ImageSkill = Skill.Skills.ImageSkill
                            };
                            tRPO.Entry(skill).State = EntityState.Deleted;
                            tRPO.SaveChanges();
                            RemoveSkill(Skill.Skills.ID);
                            CurrentControlSkills = _skillsTabControl;

                        }
                        catch
                        {
                            MessageBox.Show("Ошибка");
                        }
                    }

                }));
            }
        }
        public void RemoveSkill(int idskill)
        {
            Skills item = null;
            foreach (Skills skill in Skills)
            {
                if (skill.ID == idskill)
                {
                    item = skill;
                    break;
                }
            }
            if (item != null)
            {
                Skills.Remove(item);
            }
        }
        #endregion
        public RelayCommand _ShowHeroesAdd;

        public RelayCommand ShowHeroesAdd
        {
            get
            {
                return _ShowHeroesAdd ?? (_ShowHeroesAdd = new RelayCommand(obj =>
                {
                    _heroesEditTabControl = new HeroesEditTabUserControl(new HeroesTabVM() { HeroesTabVMList = this });
                    CurrentControl2 = _heroesEditTabControl;
                }));
            }
        }
        public RelayCommand _ShowSkillHeroAdd;

        public RelayCommand ShowSkillHeroAdd
        {
            get
            {
                return _ShowSkillHeroAdd ?? (_ShowSkillHeroAdd = new RelayCommand(obj =>
                {
                    _skillsHeroEditTabUserControl = new SkillHeroEditTabUserControl(new SkillHeroTabVM() { HeroesTabVMList = this });
                    CurrentControlSkillHero = _skillsHeroEditTabUserControl;
                }));
            }
        }
        public RelayCommand _ShowSkillAdd;

        public RelayCommand ShowSkillAdd
        {
            get
            {
                return _ShowSkillAdd ?? (_ShowSkillAdd = new RelayCommand(obj =>
                {
                    _skillsEditTabControl = new SkillsEditTabUserControl(new SkillsTabVM() { HeroesTabVMList = this });
                    CurrentControlSkills = _skillsEditTabControl;
                }));
            }
        }
        public HeroesTabVMList()
        {
            _heroesTabControl = new HeroesTabUserControl();
            _skillsTabControl = new SkillsTabUserControl();
            _skillsHeroTabUserControl=new SkillHeroTabUserControl();
            using(LOLPROJECTEntities lOLPROJECTEntities=new LOLPROJECTEntities())
            {
                Heroes = new List<Heroes>(lOLPROJECTEntities.Heroes);
                Skills=new List<Skills>(lOLPROJECTEntities.Skills);
                SkillHeroes = new List<Skill_Hero>(lOLPROJECTEntities.Skill_Hero);
            }
            
            CurrentControl2 = _heroesTabControl;
            CurrentControlSkills = _skillsTabControl;
            CurrentControlSkillHero = _skillsHeroTabUserControl;
        }
    }
}
