using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroGuard.Core;

namespace AstroGuard.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set 
            { 
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand ImportViewCommand { get; set; }
        public RelayCommand SettingsViewCommand { get; set; }
        
        public HomeViewModel HomeVM { get; set; }
        public ImportViewModel ImportVM { get; set; }
        public SettingsViewModel SettingsVM { get; set; }


        public MainViewModel(HomeViewModel homeVM, ImportViewModel importVM, SettingsViewModel settingsVM)
        {
            HomeVM = homeVM;
            ImportVM = importVM;
            SettingsVM = settingsVM;
            
            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVM;
            });

            ImportViewCommand = new RelayCommand(o =>
            {
                CurrentView = ImportVM;
            });

            SettingsViewCommand = new RelayCommand(o =>
            {
                CurrentView = SettingsVM;
            });
        }
    }
}
