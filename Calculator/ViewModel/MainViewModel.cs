using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        //private string _input;
        //private string _storedValue;
        private string _message;
        public ParametrizedRelayCommand NumberButton{ get; set; } //DONE
        public ParametrizedRelayCommand OperationButton { get; set; }
        public ParametrizedRelayCommand FunctionButton { get; set; }

        public RelayCommand Reset { get; set; } //DONE
        public RelayCommand Point { get; set; } //DONE
        public RelayCommand Sign { get; set; } //DONE
        public RelayCommand Result { get; set; }

        

        public MainViewModel()
        {
            TextMessage = "";
            NumberButton = new ParametrizedRelayCommand(
                (param) =>
                {
                    TextMessage += param;
                },
                () => { return true; }
            );
            Sign = new RelayCommand(
                () =>
                {
                    if(TextMessage.Length > 0)
                    {
                        TextMessage = Convert.ToString((Convert.ToDouble(TextMessage) * (-1)));
                    }
                },
                () => { return true; }
            );
            Point = new RelayCommand(
                () =>
                {
                    if ((!TextMessage.Contains(".")) && TextMessage.Length > 0)
                    {
                        TextMessage += ".";
                    }
                },
                () => { return true; }
            );
            Reset = new RelayCommand(
                () =>
                {
                    TextMessage = "";
                },
                () => { return true; }
            );
        }

        public string TextMessage
        {
            get => _message;
            set
            {
                _message = value;
                NotifyPropertyChanged();
            }

        }
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
