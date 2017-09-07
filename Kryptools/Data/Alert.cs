using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kryptools.Data
{
    public class Alert
    {
        public int ID { get; set; }
        public decimal BaseValue { get; set; }
        public decimal Difference { get; set; }
        public DateTime DateSet { get; set; }
        public DateTime DateUpdated { get; set; }
        public decimal NewValue { get; set; }
        public string Image { get; set; }
        public string AlertBColor { get; set; }



    }
}
