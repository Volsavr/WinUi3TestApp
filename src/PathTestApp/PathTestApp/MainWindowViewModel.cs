using Microsoft.UI;
using Microsoft.UI.Xaml.Media;
using System.ComponentModel;
using System.Windows.Input;

namespace PathTestApp
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        #region Fields
        private SolidColorBrush _redBrush = new SolidColorBrush(Colors.Red);
        private SolidColorBrush _blackBrush = new SolidColorBrush(Colors.Black);
        private SolidColorBrush _currentBrush;
        private bool _state = true;
        #endregion

        #region Constructor
        public MainWindowViewModel()
        {
            _currentBrush = _blackBrush;
            ChangeColorCommand = new RelayCommand((obj) =>
            {
                var brush = _state? _redBrush : _blackBrush;
                this.CurrentBrush = brush;
                _state = !_state;
            });
        }
        #endregion

        #region Properties
        public SolidColorBrush CurrentBrush
        {
            get
            {
                return _currentBrush;
            }
            set
            {
                _currentBrush = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentBrush)));
            }
        } 

        public ICommand ChangeColorCommand { get; private set; }
        #endregion


        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged; 
        #endregion
    }
}
