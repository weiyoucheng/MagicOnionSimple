
using System;
using System.Collections.ObjectModel;

namespace MagicOnionSimple {
    public class MainWindowViewModel:ViewModelBase {
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Name { get; set; }

        public ObservableCollection<Dto.Employee> Employees {
            get { return _Employees; }
            set { SetProperty(ref _Employees, value); }
        }
        private ObservableCollection<Dto.Employee> _Employees;

        public MainWindowViewModel()
        {
            StartTime = new DateTime(2023,5,2);
            EndTime = StartTime.AddDays(3).Add(new TimeSpan(23,59,59));
            Name = "Lady";
            _Employees = new ObservableCollection<Dto.Employee>();
        }

    }
}
