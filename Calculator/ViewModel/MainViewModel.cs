using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.ViewModel
{
    class MainViewModel
    {
        private string _input;
        private string _storedValue;
        private string _message;
        public ParametrizedRelayCommand NumberButton { get; set; }
        public ParametrizedRelayCommand OperationButton { get; set; }
        public ParametrizedRelayCommand FunctionButton { get; set; }

        public RelayCommand Reset { get; set; }
        public RelayCommand Point { get; set; }
        public RelayCommand Sign { get; set; }
        public RelayCommand Result { get; set; }

        public MainViewModel()
        {

        }
    }
}
