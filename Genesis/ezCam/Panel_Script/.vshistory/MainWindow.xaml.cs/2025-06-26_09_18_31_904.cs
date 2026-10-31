using GenesisLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace Panel_Script
{
// Layer 資料模型
    public class LayerInfo
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string Category { get; set; } // 新增分類屬性
    }


    // 盲埋孔數據模型
    public class BlindVia : INotifyPropertyChanged
    {
        private string _name;
        private int _startLayer;
        private int _endLayer;
        private string _drillType;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public int StartLayer
        {
            get => _startLayer;
            set
            {
                _startLayer = value;
                OnPropertyChanged(nameof(StartLayer));
            }
        }

        public int EndLayer
        {
            get => _endLayer;
            set
            {
                _endLayer = value;
                OnPropertyChanged(nameof(EndLayer));
            }
        }

        public string DrillType
        {
            get => _drillType;
            set
            {
                _drillType = value;
                OnPropertyChanged(nameof(DrillType));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    // 壓合參數數據模型
    public class LaminationParameter : INotifyPropertyChanged
    {
        private string _processStep;
        private string _laminationStartLayer;
        private string _laminationEndLayer;
        private string _associatedVia;

        public string ProcessStep
        {
            get => _processStep;
            set
            {
                _processStep = value;
                OnPropertyChanged(nameof(ProcessStep));
            }
        }

        public string LaminationStartLayer
        {
            get => _laminationStartLayer;
            set
            {
                _laminationStartLayer = value;
                OnPropertyChanged(nameof(LaminationStartLayer));
            }
        }

        public string LaminationEndLayer
        {
            get => _laminationEndLayer;
            set
            {
                _laminationEndLayer = value;
                OnPropertyChanged(nameof(LaminationEndLayer));
            }
        }

        public string AssociatedVia
        {
            get => _associatedVia;
            set
            {
                _associatedVia = value;
                OnPropertyChanged(nameof(AssociatedVia));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    // HDI控制ViewModel
    public class HDIControlViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<BlindVia> BlindVias { get; set; }
        public ObservableCollection<LaminationParameter> LaminationParameters { get; set; }

        private BlindVia _selectedBlindVia;
        private LaminationParameter _selectedLaminationParameter;

        public BlindVia SelectedBlindVia
        {
            get => _selectedBlindVia;
            set
            {
                _selectedBlindVia = value;
                OnPropertyChanged(nameof(SelectedBlindVia));
            }
        }

        public LaminationParameter SelectedLaminationParameter
        {
            get => _selectedLaminationParameter;
            set
            {
                _selectedLaminationParameter = value;
                OnPropertyChanged(nameof(SelectedLaminationParameter));
            }
        }

        public HDIControlViewModel()
        {
            BlindVias = new ObservableCollection<BlindVia>();
            LaminationParameters = new ObservableCollection<LaminationParameter>();
            InitializeHDIData();
        }

        private void InitializeHDIData()
        {
            // 初始化盲埋孔數據
            BlindVias.Add(new BlindVia
            {
                Name = "Via_1-2",
                StartLayer = 1,
                EndLayer = 2,
                DrillType = "Laser"
            });
            BlindVias.Add(new BlindVia
            {
                Name = "Via_2-3",
                StartLayer = 2,
                EndLayer = 3,
                DrillType = "Mechanical"
            });

            // 初始化壓合參數
            LaminationParameters.Add(new LaminationParameter
            {
                ProcessStep = "第一次壓合",
                AssociatedVia = "Via_1-2"
            });
            LaminationParameters.Add(new LaminationParameter
            {
                ProcessStep = "第二次壓合",
                AssociatedVia = "Via_2-3"
            });
        }

        public void AddBlindVia()
        {
            BlindVias.Add(new BlindVia
            {
                Name = $"Via_{BlindVias.Count + 1}",
                StartLayer = 1,
                EndLayer = 2,
                DrillType = "Laser"
            });
        }

        public void AddLaminationParameter()
        {
            LaminationParameters.Add(new LaminationParameter
            {
                ProcessStep = $"第{LaminationParameters.Count + 1}次壓合",
                AssociatedVia = ""
            });
        }

        public void RemoveBlindVia(BlindVia via)
        {
            if (via != null)
            {
                BlindVias.Remove(via);
            }
        }

        public void RemoveLaminationParameter(LaminationParameter param)
        {
            if (param != null)
            {
                LaminationParameters.Remove(param);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public partial class MainWindow : Window
    {
        private static string job;
        private static string step;
        private static string lastUnit = "Inch"; //last selected unit, default is Inch

        private string OrigShipX = "1.0"; // 用於存儲成型尺寸原始的 X 坐標值
        private string OrigShipY = "1.0"; // 用於存儲成型尺寸原始的 X 坐標值
        private bool isInitialized = false;

        private ObservableCollection<LayerInfo> layerList = new ObservableCollection<LayerInfo>();

        // HDI功能相關屬性
        private HDIControlViewModel _hdiViewModel;

        public static string JOB
        {
            get
            {
                job = Gen.JOB;
                if (job == null)
                {
                    Gen.PAUSE("need select a job.");
                    throw new Exception("cant get job variable");
                }

                return job;
            }
        }

        public static string STEP
        {
            get
            {
                step = Gen.STEP;
                if (step == null)
                {
                    Gen.PAUSE("need select a step.");
                    throw new Exception("cant get step variable");
                }

                return step;
            }
        }


        public MainWindow()
        {
            InitializeComponent();

            // TextBox 初始化
            InitializeTextBoxes();

            // 綁定 ListView 的資料來源
            if (FindName("layerListView") is ListView lv)
                lv.ItemsSource = layerList;

            isInitialized = true; // 確保只初始化一次
        }


        private void InitializeTextBoxes()
        {
            // 所有 TextBox 初始化
            ((TextBox)FindName("six")).Text = "1.0";
            ((TextBox)FindName("siy")).Text = "1.0";
            ((TextBox)FindName("wix")).Text = "1.0";
            ((TextBox)FindName("wiy")).Text = "1.0";
            ((TextBox)FindName("xstep_num")).Text = "1";
            ((TextBox)FindName("ystep_num")).Text = "1";
            ((TextBox)FindName("xstep_spec")).Text = "0.0787";
            ((TextBox)FindName("ystep_spec")).Text = "0.0787";
            ((ComboBox)FindName("shipRotate")).ItemsSource = new List<string> { "0", "90" };
            ((ComboBox)FindName("shipRotate")).SelectedIndex = 0;
            ((ComboBox)FindName("unit_mminch")).ItemsSource = new List<string> { "Inch", "MM" };
            ((ComboBox)FindName("unit_mminch")).SelectedIndex = 0;
        }

        // 載入層別資料（可根據實際需求修改）
        private void LoadLayers(string _step)
        {
            layerList.Clear();

            var layers = GenTools.FindAllLayers(job, _step);
            // 檢查 layers 是否為 null
            if (layers == null)
            {
                MessageBox.Show("層別讀取失敗");
                Application.Current.Shutdown();
            }

            if (layers.Outer.Count > 0)
            {
                foreach (var name in layers.Outer)
                {
                    layerList.Add(new LayerInfo
                    {
                        Name = name,
                        Status = "Active",
                        Description = "Outer layer",
                        Category = "Copper"
                    });
                }
            }

            if (layers.Inner.Count > 0)
            {
                foreach (var name in layers.Inner)
                {
                    layerList.Add(new LayerInfo
                    {
                        Name = name,
                        Status = "Active",
                        Description = "Inner layer",
                        Category = "Copper"
                    });
                }
            }


            if (layers.Drill.Count > 0)
            {
                foreach (var name in layers.Drill)
                {
                    layerList.Add(new LayerInfo
                    {
                        Name = name,
                        Status = "Active",
                        Description = "Drill layer",
                        Category = "Drill"
                    });
                }
            }

            if (layers.BlindDrill.Count > 0)
            {
                foreach (var name in layers.BlindDrill)
                {
                    layerList.Add(new LayerInfo
                    {
                        Name = name,
                        Status = "Active",
                        Description = "Blind Drill layer",
                        Category = "Drill"
                    });
                }
            }


            if (layers.SolderMask.Count > 0)
            {
                foreach (var name in layers.SolderMask)
                {
                    layerList.Add(new LayerInfo
                    {
                        Name = name,
                        Status = "Active",
                        Description = "Solder Mask layer",
                        Category = "SolderMask"
                    });
                }
            }

            if (layers.SilkScreen.Count > 0)
            {
                foreach (var name in layers.SilkScreen)
                {
                    layerList.Add(new LayerInfo
                    {
                        Name = name,
                        Status = "Active",
                        Description = "Silk Screen layer",
                        Category = "SilkScreen"
                    });
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            #region get steps list

            Gen.INFO($" -t job -e {JOB} -m script -d STEPS_LIST");
            List<string> steps = new List<string>(Gen.GetInfo("gSTEPS_LIST"));

            stpSlect.ItemsSource = steps;

            LoadLayers(steps[0]);
            InitializeHDI();

            #endregion
        }

        // 添加HDI初始化
        private void InitializeHDI()
        {
            _hdiViewModel = new HDIControlViewModel();

            // 設置HDI相關控件的DataContext
            blindViasDataGrid.DataContext = _hdiViewModel;
            laminationParametersDataGrid.DataContext = _hdiViewModel;
            associatedViaComboBox.DataContext = _hdiViewModel;
        }

        // HDI相關事件處理方法
        private void AddBlindVia_Click(object sender, RoutedEventArgs e)
        {
            _hdiViewModel.AddBlindVia();
        }

        private void DeleteBlindVia_Click(object sender, RoutedEventArgs e)
        {
            if (_hdiViewModel.SelectedBlindVia != null)
            {
                var result = MessageBox.Show($"確定要刪除盲埋孔 '{_hdiViewModel.SelectedBlindVia.Name}' 嗎？",
                    "確認刪除", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    _hdiViewModel.RemoveBlindVia(_hdiViewModel.SelectedBlindVia);
                }
            }
            else
            {
                MessageBox.Show("請選擇要刪除的盲埋孔", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void AddLaminationParameter_Click(object sender, RoutedEventArgs e)
        {
            _hdiViewModel.AddLaminationParameter();
        }

        private void DeleteLaminationParameter_Click(object sender, RoutedEventArgs e)
        {
            if (_hdiViewModel.SelectedLaminationParameter != null)
            {
                var result = MessageBox.Show($"確定要刪除壓合參數 '{_hdiViewModel.SelectedLaminationParameter.ProcessStep}' 嗎？",
                    "確認刪除", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    _hdiViewModel.RemoveLaminationParameter(_hdiViewModel.SelectedLaminationParameter);
                }
            }
            else
            {
                MessageBox.Show("請選擇要刪除的壓合參數", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void CreateAssociation_Click(object sender, RoutedEventArgs e)
        {
            if (_hdiViewModel.SelectedBlindVia != null && _hdiViewModel.SelectedLaminationParameter != null)
            {
                _hdiViewModel.SelectedLaminationParameter.AssociatedVia = _hdiViewModel.SelectedBlindVia.Name;
                _hdiViewModel.SelectedLaminationParameter.LaminationStartLayer = _hdiViewModel.SelectedBlindVia.StartLayer.ToString();
                _hdiViewModel.SelectedLaminationParameter.LaminationEndLayer = _hdiViewModel.SelectedBlindVia.EndLayer.ToString();
                MessageBox.Show(
                    $"已建立關聯：{_hdiViewModel.SelectedBlindVia.Name} ↔ {_hdiViewModel.SelectedLaminationParameter.ProcessStep}",
                    "關聯成功", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("請同時選擇盲埋孔和壓合參數", "提示", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void ClearAssociation_Click(object sender, RoutedEventArgs e)
        {
            if (_hdiViewModel.SelectedLaminationParameter != null)
            {
                _hdiViewModel.SelectedLaminationParameter.AssociatedVia = "";
                MessageBox.Show("已清除關聯", "清除成功", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("請選擇要清除關聯的壓合參數", "提示", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void SaveHDISettings_Click(object sender, RoutedEventArgs e)
        {
            // 這裡可以添加儲存HDI設定的邏輯
            MessageBox.Show("HDI設定已儲存", "儲存成功", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// 下拉選擇STEP時，獲取成型尺寸並更新相關 TextBox。
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void stpSlect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string stp = stpSlect.SelectedItem as string;
            Gen.INFO($"-t step -e {JOB}/{stp} -m script -d PROF_LIMITS");
            double xmin = double.Parse(Gen.GetInfo("gPROF_LIMITSxmin")[0]);
            double ymin = double.Parse(Gen.GetInfo("gPROF_LIMITSymin")[0]);
            double xmax = double.Parse(Gen.GetInfo("gPROF_LIMITSxmax")[0]);
            double ymax = double.Parse(Gen.GetInfo("gPROF_LIMITSymax")[0]);
            string shipXSize = (xmax - xmin).ToString(); // 計算成型尺寸的 X 坐標值
            string shipYSize = (ymax - ymin).ToString(); // 計算成型尺寸的 y 坐標值
            six.Text = shipXSize; // 設置成型尺寸的 X 坐標值到對應的 TextBox
            siy.Text = shipYSize; // 設置成型尺寸的 y 坐標值到對應的 TextBox
            OrigShipX = shipXSize; // 用於存儲成型尺寸原始的 X 坐標值
            OrigShipY = shipYSize; // 用於存儲成型尺寸原始的 y 坐標值
            shipRotate.SelectedIndex = 0; // 重置旋轉選項為 0 度

            //如果work step,不自動排板,隱藏排板間距、排板數量;
            if (stp == "work")
            {
                //xtep_spec不可編輯，ytep_spec不可編輯
                xstep_num.IsReadOnly = true;
                ystep_num.IsReadOnly = true;
                shipRotate.IsReadOnly = true;
                //xstep_spec.IsReadOnly = true;
                //ystep_spec.IsReadOnly=true;
            }


            UpdateData();
        }

        /// <summary>
        /// 當選擇旋轉角度 ，更換ship angle。
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void shipRotate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!isInitialized) return;
            UpdateData();
        }

        private void UpdateData()
        {
            string angle = shipRotate.SelectedItem as string;

            if (unit_mminch.Text == "MM")
            {
                if (angle == "0")
                {
                    six.Text = (double.Parse(OrigShipX) * 25.4).ToString("F4");
                    siy.Text = (double.Parse(OrigShipY) * 25.4).ToString("F4");
                }
                else if (angle == "90")
                {
                    six.Text = (double.Parse(OrigShipY) * 25.4).ToString("F4");
                    siy.Text = (double.Parse(OrigShipX) * 25.4).ToString("F4");
                }
            }
            else if (unit_mminch.Text == "Inch")
            {
                if (angle == "0")
                {
                    six.Text = OrigShipX;
                    siy.Text = OrigShipY;
                }
                else if (angle == "90")
                {
                    six.Text = OrigShipY;
                    siy.Text = OrigShipX;
                }
            }
        }

        private void unit_mminch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!isInitialized) return;

            string angle = shipRotate.SelectedItem as string;


            string selectedUnit = unit_mminch.SelectedItem as string;


            if (selectedUnit == "MM" && lastUnit == "Inch")
            {
                if (angle == "0")
                {
                    six.Text = (double.Parse(OrigShipX) * 25.4).ToString("F4");
                    siy.Text = (double.Parse(OrigShipY) * 25.4).ToString("F4");
                }
                else if (angle == "90")
                {
                    six.Text = (double.Parse(OrigShipY) * 25.4).ToString("F4");
                    siy.Text = (double.Parse(OrigShipX) * 25.4).ToString("F4");
                }

                //inch to mm
                wix.Text = (double.Parse(wix.Text) * 25.4).ToString("F4");
                wiy.Text = (double.Parse(wiy.Text) * 25.4).ToString("F4");
                xstep_spec.Text = Math.Round((double.Parse(xstep_spec.Text) * 25.4), 2).ToString("F2");
                ystep_spec.Text = Math.Round((double.Parse(ystep_spec.Text) * 25.4), 2).ToString("F2");
                lastUnit = "MM";
            }
            else if (selectedUnit == "Inch" && lastUnit == "MM")
            {
                if (angle == "0")
                {
                    six.Text = OrigShipX;
                    siy.Text = OrigShipY;
                }
                else if (angle == "90")
                {
                    six.Text = OrigShipY;
                    siy.Text = OrigShipX;
                }

                //mm to inch
                wix.Text = (double.Parse(wix.Text) / 25.4).ToString("F4");
                wiy.Text = (double.Parse(wiy.Text) / 25.4).ToString("F4");
                xstep_spec.Text = (double.Parse(xstep_spec.Text) / 25.4).ToString("F4");
                ystep_spec.Text = (double.Parse(ystep_spec.Text) / 25.4).ToString("F4");
                lastUnit = "Inch";
            }
        }

        private void onclick_exit_btn(object sender, RoutedEventArgs e)
        {
            //exit the application
            Application.Current.Shutdown();
        }

        private void onclick_run_btn(object sender, RoutedEventArgs e)
        {
            //先簡單判斷輸入的值是否為0.0，如果是則彈出提示信息
            if (six.Text == "0.0" || siy.Text == "0.0")
            {
                //彈出提示信息，要求輸入成型尺寸
                Gen.PAUSE("Please input the ship size.");
                return;
            }

            if (wix.Text == "0.0" || wiy.Text == "0.0")
            {
                Gen.PAUSE("Please input the WPNL size.");
                return;
            }

            //Run the panel script
            try
            {
                MyPanelScript.RunPanelScript();
            }
            catch (Exception ex)
            {
                Gen.PAUSE($"Error: {ex.Message}");
            }
        }


        private void wix_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void wiy_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void six_TextChanged(object sender, TextChangedEventArgs e)
        {
            //OrigShipX = six.Text;
        }

        private void siy_TextChanged(object sender, TextChangedEventArgs e)
        {
            //OrigShipY = siy.Text;
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.SelectAll();
            }
        }

        public static class TextBoxBehavior
        {
            public static readonly DependencyProperty SelectAllOnFocusProperty =
                DependencyProperty.RegisterAttached(
                    "SelectAllOnFocus",
                    typeof(bool),
                    typeof(TextBoxBehavior),
                    new PropertyMetadata(false, OnSelectAllOnFocusChanged));

            public static bool GetSelectAllOnFocus(DependencyObject obj)
            {
                return (bool)obj.GetValue(SelectAllOnFocusProperty);
            }

            public static void SetSelectAllOnFocus(DependencyObject obj, bool value)
            {
                obj.SetValue(SelectAllOnFocusProperty, value);
            }

            private static void OnSelectAllOnFocusChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                if (d is TextBox textBox)
                {
                    if ((bool)e.NewValue)
                    {
                        textBox.GotKeyboardFocus += TextBox_GotKeyboardFocus;
                        textBox.PreviewMouseLeftButtonDown += TextBox_PreviewMouseLeftButtonDown;
                    }
                    else
                    {
                        textBox.GotKeyboardFocus -= TextBox_GotKeyboardFocus;
                        textBox.PreviewMouseLeftButtonDown -= TextBox_PreviewMouseLeftButtonDown;
                    }
                }
            }

            private static void TextBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
            {
                if (sender is TextBox textBox)
                {
                    textBox.SelectAll();
                }
            }

            private static void TextBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            {
                if (sender is TextBox textBox)
                {
                    if (!textBox.IsKeyboardFocusWithin)
                    {
                        textBox.Focus();
                        e.Handled = true;
                    }
                }
            }
        }
    }
}