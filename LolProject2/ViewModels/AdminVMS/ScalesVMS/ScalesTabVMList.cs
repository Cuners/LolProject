using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using LolProject2.View;
namespace LolProject2.ViewModels
{
    public class ScalesTabVMList:ViewModel
    {
        private UserControl _baseScalesTabControl;
        private UserControl _baseScalesEditTabControl;
        private UserControl _scalesTabControl;
        private UserControl _scalesEditTabControl;
        private UserControl _currentBaseScales;
        private UserControl _currentScales;
        public UserControl CurrentBaseScales
        {
            get { return _currentBaseScales; }
            set => Set(ref _currentBaseScales, value);
        }
        public UserControl CurrentScales
        {
            get { return _currentScales; }
            set => Set(ref _currentScales, value);
        }
        private List<BaseScales> _baseScales;
        public List<BaseScales> BaseScales
        {
            get { return _baseScales; }
            set => Set(ref _baseScales, value);
        }
        private List<Scales> _scales;
        public List<Scales> Scales
        {
            get { return _scales; }
            set => Set(ref _scales, value);
        }
        private BaseScales selectedBaseScales;
        public BaseScales SelectedBaseScales
        {
            get { return selectedBaseScales ; }
            set
            {
                selectedBaseScales = value;
                if (SelectedBaseScales != null)
                {
                    OnPropertyChanged("SelectedItem");
                    BaseScalesVM viewModel = new BaseScalesVM(selectedBaseScales) { ScalesTabVMList = this };
                    _baseScalesEditTabControl= new BaseScalesEditTabUserControl(viewModel);
                    CurrentBaseScales = _baseScalesEditTabControl;
                }
                else
                {
                    return;
                }

            }
        }
        private Scales selectedScales;
        public Scales SelectedScales
        {
            get { return selectedScales; }
            set
            {
                selectedScales = value;
                if (SelectedScales != null)
                {
                    OnPropertyChanged("SelectedItem");
                    ScalesVM viewModel = new ScalesVM(selectedScales) { ScalesTabVMList = this };
                    _scalesEditTabControl = new ScalesEditTabUserControl(viewModel);
                    CurrentScales = _scalesEditTabControl;
                }
                else
                {
                    return;
                }

            }
        }
        #region Scales
        public RelayCommand _BackToTableScale;

        public RelayCommand BackToTableScale
        {
            get
            {
                return _BackToTableScale ?? (_BackToTableScale = new RelayCommand(obj =>
                {
                    _scalesTabControl = new ScalesTabUserControl();
                    CurrentScales = _scalesTabControl;
                }));
            }
        }
        public RelayCommand _ScaleAddEdit;

        public RelayCommand ScaleAddEdit
        {
            get
            {
                return _ScaleAddEdit ?? (_ScaleAddEdit = new RelayCommand(obj =>
                {
                    ScalesVM Scale = obj as ScalesVM;
                    if (Scale.Scales.Id != 0)
                    {
                        using (LOLPROJECTEntities tRPO = new LOLPROJECTEntities())
                        {
                            try
                            {
                                if (string.IsNullOrWhiteSpace(Scale.Scales.NameHero))
                                {
                                    MessageBox.Show("Вы что-то не ввели");
                                    return;
                                }
                                else
                                {
                                    Scales scale = new Scales
                                    {
                                        Id = Scale.Scales.Id,
                                        NameHero = Scale.Scales.NameHero,
                                        Damage = Scale.Scales.Damage,
                                        Armor = Scale.Scales.Armor,
                                        Health = Scale.Scales.Health,
                                        Mana = Scale.Scales.Mana,
                                        ResistMagic = Scale.Scales.ResistMagic
                                    };
                                    tRPO.Entry(scale).State = EntityState.Modified;
                                    tRPO.SaveChanges();

                                    CurrentScales = _scalesTabControl;
                                }
                                
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
                                if (string.IsNullOrWhiteSpace(Scale.Scales.NameHero))
                                {
                                    MessageBox.Show("Вы что-то не ввели");
                                    return;
                                }
                                else
                                {
                                    Scales scale = new Scales
                                    {
                                        Id = Scale.Scales.Id,
                                        NameHero = Scale.Scales.NameHero,
                                        Damage = Scale.Scales.Damage,
                                        Armor = Scale.Scales.Armor,
                                        Health = Scale.Scales.Health,
                                        Mana = Scale.Scales.Mana,
                                        ResistMagic = Scale.Scales.ResistMagic
                                    };
                                    tRPO.Entry(scale).State = EntityState.Added;
                                    tRPO.SaveChanges();
                                    Scales.Add(scale);
                                    CurrentScales = _scalesTabControl;
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
        public RelayCommand _ScaleDelete;

        public RelayCommand ScaleDelete
        {
            get
            {
                return _ScaleDelete ?? (_ScaleDelete = new RelayCommand(obj =>
                {
                    ScalesVM Scale = obj as ScalesVM;

                    using (LOLPROJECTEntities tRPO = new LOLPROJECTEntities())
                    {
                        try
                        {

                            Scales scale = new Scales
                            {
                                Id = Scale.Scales.Id,
                                NameHero = Scale.Scales.NameHero,
                                Damage = Scale.Scales.Damage,
                                Armor = Scale.Scales.Armor,
                                Health = Scale.Scales.Health,
                                Mana = Scale.Scales.Mana,
                                ResistMagic = Scale.Scales.ResistMagic
                            };
                            tRPO.Entry(scale).State = EntityState.Deleted;
                            tRPO.SaveChanges();
                            RemoveScale(Scale.Scales.Id);
                            CurrentScales = _scalesTabControl;

                        }
                        catch
                        {
                            MessageBox.Show("Ошибка");
                        }
                    }

                }));
            }
        }
        public void RemoveScale(int idscale)
        {
            Scales item = null;
            foreach (Scales scale in Scales)
            {
                if (scale.Id == idscale)
                {
                    item = scale;
                    break;
                }
            }
            if (item != null)
            {
                Scales.Remove(item);
            }
        }
        #endregion
        #region BaseScales
        public RelayCommand _BackToTableBaseScale;

        public RelayCommand BackToTableBaseScale
        {
            get
            {
                return _BackToTableBaseScale ?? (_BackToTableScale = new RelayCommand(obj =>
                {
                    _baseScalesTabControl = new BaseScalesTabUserControl();
                    CurrentBaseScales = _baseScalesTabControl;
                }));
            }
        }
        public RelayCommand _BaseScaleAddEdit;

        public RelayCommand BaseAddEdit
        {
            get
            {
                return _BaseScaleAddEdit ?? (_BaseScaleAddEdit = new RelayCommand(obj =>
                {
                    BaseScalesVM BaseScale = obj as BaseScalesVM;
                    if (BaseScale.BaseScales.ID != 0)
                    {
                        using (LOLPROJECTEntities tRPO = new LOLPROJECTEntities())
                        {
                            try
                            {
                                if (string.IsNullOrWhiteSpace(BaseScale.BaseScales.NameHero))
                                {
                                    MessageBox.Show("Вы что-то не ввели");
                                    return;
                                }
                                else
                                {
                                    BaseScales basescale = new BaseScales
                                    {
                                        ID = BaseScale.BaseScales.ID,
                                        NameHero = BaseScale.BaseScales.NameHero,
                                        Health = BaseScale.BaseScales.Health,
                                        Armor = BaseScale.BaseScales.Armor,
                                        Mana = BaseScale.BaseScales.Mana,
                                        AD = BaseScale.BaseScales.AD,

                                        ResistMagic = BaseScale.BaseScales.ResistMagic,
                                        Crit = BaseScale.BaseScales.Crit,
                                        MoveSpeed = BaseScale.BaseScales.MoveSpeed,
                                        Speed_Attack = BaseScale.BaseScales.Speed_Attack
                                    };
                                    tRPO.Entry(basescale).State = EntityState.Modified;
                                    tRPO.SaveChanges();

                                    CurrentBaseScales = _baseScalesTabControl;
                                }

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
                                if (string.IsNullOrWhiteSpace(BaseScale.BaseScales.NameHero))
                                {
                                    MessageBox.Show("Вы что-то не ввели");
                                    return;
                                }
                                else
                                {
                                    BaseScales basescale = new BaseScales
                                    {
                                        ID = BaseScale.BaseScales.ID,
                                        NameHero = BaseScale.BaseScales.NameHero,
                                        Health = BaseScale.BaseScales.Health,
                                        Armor = BaseScale.BaseScales.Armor,
                                        Mana = BaseScale.BaseScales.Mana,
                                        AD = BaseScale.BaseScales.AD,

                                        ResistMagic = BaseScale.BaseScales.ResistMagic,
                                        Crit = BaseScale.BaseScales.Crit,
                                        MoveSpeed = BaseScale.BaseScales.MoveSpeed,
                                        Speed_Attack = BaseScale.BaseScales.Speed_Attack
                                    };
                                    tRPO.Entry(basescale).State = EntityState.Added;
                                    tRPO.SaveChanges();
                                    BaseScales.Add(basescale);
                                    CurrentBaseScales = _baseScalesTabControl;
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
        public RelayCommand _BaseScaleDelete;

        public RelayCommand BaseScaleDelete
        {
            get
            {
                return _BaseScaleDelete ?? (_BaseScaleDelete = new RelayCommand(obj =>
                {
                    BaseScalesVM BaseScale = obj as BaseScalesVM;

                    using (LOLPROJECTEntities tRPO = new LOLPROJECTEntities())
                    {
                        try
                        {
                            BaseScales basescale = new BaseScales
                            {
                                ID = BaseScale.BaseScales.ID,
                                NameHero = BaseScale.BaseScales.NameHero,
                                Health = BaseScale.BaseScales.Health,
                                Armor = BaseScale.BaseScales.Armor,
                                Mana = BaseScale.BaseScales.Mana,
                                AD = BaseScale.BaseScales.AD,

                                ResistMagic = BaseScale.BaseScales.ResistMagic,
                                Crit = BaseScale.BaseScales.Crit,
                                MoveSpeed = BaseScale.BaseScales.MoveSpeed,
                                Speed_Attack = BaseScale.BaseScales.Speed_Attack
                            };
                            tRPO.Entry(basescale).State = EntityState.Deleted;
                            tRPO.SaveChanges();
                            RemoveBaseScale(BaseScale.BaseScales.ID);
                            CurrentBaseScales = _baseScalesTabControl;

                        }
                        catch
                        {
                            MessageBox.Show("Ошибка");
                        }
                    }

                }));
            }
        }
        public void RemoveBaseScale(int idbasescale)
        {
            BaseScales item = null;
            foreach (BaseScales basescale in BaseScales)
            {
                if (basescale.ID== idbasescale)
                {
                    item = basescale;
                    break;
                }
            }
            if (item != null)
            {
                BaseScales.Remove(item);
            }
        }
        #endregion
        public RelayCommand _ShowScalesAdd;

        public RelayCommand ShowScalesAdd
        {
            get
            {
                return _ShowScalesAdd ?? (_ShowScalesAdd = new RelayCommand(obj =>
                {
                    _scalesEditTabControl = new ScalesEditTabUserControl(new ScalesVM() { ScalesTabVMList = this });
                    CurrentScales = _scalesEditTabControl;
                }));
            }
        }
        public RelayCommand _ShowBaseScalesAdd;

        public RelayCommand ShowBaseScalesAdd
        {
            get
            {
                return _ShowBaseScalesAdd ?? (_ShowBaseScalesAdd = new RelayCommand(obj =>
                {
                    _baseScalesEditTabControl = new BaseScalesEditTabUserControl(new BaseScalesVM() { ScalesTabVMList = this });
                    CurrentBaseScales = _baseScalesEditTabControl;
                }));
            }
        }

        public ScalesTabVMList()
        {
            _baseScalesTabControl=new BaseScalesTabUserControl();
            _scalesTabControl=new ScalesTabUserControl();
            using(LOLPROJECTEntities lOLPROJECTEntities=new LOLPROJECTEntities())
            {
                BaseScales = new List<BaseScales>(lOLPROJECTEntities.BaseScales);
                Scales=new List<Scales>(lOLPROJECTEntities.Scales);
            }
            CurrentBaseScales = _baseScalesTabControl;
            CurrentScales = _scalesTabControl;
        }
    }
}
