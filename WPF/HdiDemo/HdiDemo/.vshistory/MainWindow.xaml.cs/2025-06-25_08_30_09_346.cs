using System;
using System.Collections.Generic;
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
using System.ComponentModel;

namespace HdiDemo
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
  /*  public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

    }*/

    // 盲埋孔數據模型
public class BlindVia : INotifyPropertyChanged
{
    private string _name;
    private int _startLayer;
    private int _endLayer;
    private double _diameter;
    private string _drillType;

    public string Name
    {
        get => _name;
        set { _name = value; OnPropertyChanged(nameof(Name)); }
    }

    public int StartLayer
    {
        get => _startLayer;
        set { _startLayer = value; OnPropertyChanged(nameof(StartLayer)); }
    }

    public int EndLayer
    {
        get => _endLayer;
        set { _endLayer = value; OnPropertyChanged(nameof(EndLayer)); }
    }

    public double Diameter
    {
        get => _diameter;
        set { _diameter = value; OnPropertyChanged(nameof(Diameter)); }
    }

    public string DrillType
    {
        get => _drillType;
        set { _drillType = value; OnPropertyChanged(nameof(DrillType)); }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

// 壓合參數數據模型
public class LaminationParameter : INotifyPropertyChanged
{
    private string _processStep;
    private double _temperature;
    private double _pressure;
    private int _time;
    private double _vacuumLevel;
    private string _associatedVia;

    public string ProcessStep
    {
        get => _processStep;
        set { _processStep = value; OnPropertyChanged(nameof(ProcessStep)); }
    }

    public double Temperature
    {
        get => _temperature;
        set { _temperature = value; OnPropertyChanged(nameof(Temperature)); }
    }

    public double Pressure
    {
        get => _pressure;
        set { _pressure = value; OnPropertyChanged(nameof(Pressure)); }
    }

    public int Time
    {
        get => _time;
        set { _time = value; OnPropertyChanged(nameof(Time)); }
    }

    public double VacuumLevel
    {
        get => _vacuumLevel;
        set { _vacuumLevel = value; OnPropertyChanged(nameof(VacuumLevel)); }
    }

    public string AssociatedVia
    {
        get => _associatedVia;
        set { _associatedVia = value; OnPropertyChanged(nameof(AssociatedVia)); }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

// 2. ViewModel
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
            UpdateAssociation();
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
        InitializeData();
    }

    private void InitializeData()
    {
        // 初始化盲埋孔數據
        BlindVias.Add(new BlindVia 
        { 
            Name = "Via_1-2", 
            StartLayer = 1, 
            EndLayer = 2, 
            Diameter = 0.1, 
            DrillType = "Laser" 
        });
        BlindVias.Add(new BlindVia 
        { 
            Name = "Via_2-3", 
            StartLayer = 2, 
            EndLayer = 3, 
            Diameter = 0.15, 
            DrillType = "Mechanical" 
        });

        // 初始化壓合參數
        LaminationParameters.Add(new LaminationParameter 
        { 
            ProcessStep = "第一次壓合", 
            Temperature = 180, 
            Pressure = 25, 
            Time = 90, 
            VacuumLevel = 0.8 
        });
        LaminationParameters.Add(new LaminationParameter 
        { 
            ProcessStep = "第二次壓合", 
            Temperature = 175, 
            Pressure = 20, 
            Time = 75, 
            VacuumLevel = 0.9 
        });
    }

    private void UpdateAssociation()
    {
        if (SelectedBlindVia != null && SelectedLaminationParameter != null)
        {
            SelectedLaminationParameter.AssociatedVia = SelectedBlindVia.Name;
        }
    }

    public void AddBlindVia()
    {
        BlindVias.Add(new BlindVia 
        { 
            Name = $"Via_{BlindVias.Count + 1}", 
            StartLayer = 1, 
            EndLayer = 2, 
            Diameter = 0.1, 
            DrillType = "Laser" 
        });
    }

    public void AddLaminationParameter()
    {
        LaminationParameters.Add(new LaminationParameter 
        { 
            ProcessStep = $"壓合步驟_{LaminationParameters.Count + 1}", 
            Temperature = 180, 
            Pressure = 25, 
            Time = 90, 
            VacuumLevel = 0.8 
        });
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

// 3. 主視窗控件
public partial class HDIControlWindow : Window
{
    private HDIControlViewModel _viewModel;

    public HDIControlWindow()
    {
        InitializeComponent();
        _viewModel = new HDIControlViewModel();
        DataContext = _viewModel;
    }

    private void AddBlindVia_Click(object sender, RoutedEventArgs e)
    {
        _viewModel.AddBlindVia();
    }

    private void AddLaminationParameter_Click(object sender, RoutedEventArgs e)
    {
        _viewModel.AddLaminationParameter();
    }

    private void CreateAssociation_Click(object sender, RoutedEventArgs e)
    {
        if (_viewModel.SelectedBlindVia != null && _viewModel.SelectedLaminationParameter != null)
        {
            _viewModel.SelectedLaminationParameter.AssociatedVia = _viewModel.SelectedBlindVia.Name;
            MessageBox.Show($"已建立關聯：{_viewModel.SelectedBlindVia.Name} ↔ {_viewModel.SelectedLaminationParameter.ProcessStep}");
        }
        else
        {
            MessageBox.Show("請選擇盲埋孔和壓合參數");
        }
    }
}
}
