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
        private string _input;
        private string _storedValue;
        private string _message;
        private int _function;
        public ParametrizedRelayCommand NumberButton{ get; set; } //DONE
        public ParametrizedRelayCommand OperationButton { get; set; }
        public ParametrizedRelayCommand FunctionButton { get; set; }

        public RelayCommand Reset { get; set; }
        public RelayCommand Point { get; set; } //DONE
        public RelayCommand Sign { get; set; } //DONE
        public RelayCommand Result { get; set; }

        

        public MainViewModel()
        {
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
            Result = new RelayCommand(
                () =>
                {
                    if (_function == 1)
                    {
                        TextMessage = Convert.ToString(Convert.ToDouble(_storedValue) + Convert.ToDouble(TextMessage));
                    }
                    if (_function == 2)
                    {
                        TextMessage = Convert.ToString(Convert.ToDouble(_storedValue) - Convert.ToDouble(TextMessage));
                    }
                    if (_function == 3)
                    {
                        TextMessage = Convert.ToString(Convert.ToDouble(_storedValue) * Convert.ToDouble(TextMessage));
                    }
                    if (_function == 4)
                    {
                        TextMessage = Convert.ToString(Convert.ToDouble(_storedValue) / Convert.ToDouble(TextMessage));
                    }
                },
                () => { return true; }
            );
            OperationButton = new ParametrizedRelayCommand(
                (param) =>
                {
                    _storedValue = TextMessage;
                    TextMessage = "";
                   if(Convert.ToString(param) == "+")
                    {
                        _function = 1;
                    }
                   if(Convert.ToString(param) == "-")
                    {
                        _function = 2;
                    }
                   if(Convert.ToString(param) == "*")
                    {
                        _function = 3;
                    }
                   else if(Convert.ToString(param) == "/")
                    {
                        _function = 4;
                    }
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
