using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kryptools.Controls
{
    class CalculatorComboBoxItem
    {
        string display;
        string iD;
        string symbol;
        decimal valueBTC;
        string name;

        public CalculatorComboBoxItem(string d, string i, string s, decimal b, string n)
        {

            display = d;
            iD = i;
            symbol = s;
            valueBTC = b;
            name = n;

        }

        public string Display { get => display; set => display = value; }
        public string ID { get => iD; set => iD = value; }
        public string Symbol { get => symbol.ToString().ToUpper(); set => symbol = value; }
        public decimal ValueBTC { get => Convert.ToDecimal(valueBTC); set => valueBTC = Convert.ToDecimal(value); }
        public string Name { get => name; set => name = value; }

        public override string ToString()
        {
            return display;
        }
    }
}
