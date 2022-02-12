using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
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
using ReactiveGUIService;

namespace ReactiveGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<CustomerData> UserData;
        private ReactiveGUIService.ReactiveService _service;
        public MainWindow()
        {
            InitializeComponent();
            _service = new ReactiveService();
            Init();

            var textChangedObservable = Observable.FromEventPattern(txtUserName, "TextChanged")
                .Select(p => ((TextBox)p.Sender).Text)
                .Where(p => p.Length >= 3)
                .Throttle(TimeSpan.FromMilliseconds(300))
                .DistinctUntilChanged();

            var results = textChangedObservable.Select(p => _service.QueryCustomerData(p)).ObserveOn(SynchronizationContext.Current);

            results.Subscribe(p => {
                BindGrid(p);
                });
        }
        private void Init()
        {
            UserData = new ObservableCollection<CustomerData>(_service.LoadCustomerData());
            dgUserDetails.ItemsSource = UserData;
        }

        private void BindGrid(IList<CustomerData> customers)
        {
            dgUserDetails.ItemsSource = null;
            dgUserDetails.ItemsSource = customers;
        }
    }
}
