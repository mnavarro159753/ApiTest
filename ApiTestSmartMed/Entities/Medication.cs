using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExchange
{
    public class Medication
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public int cantidade { get; set; }
        public DateTime dataCreacion { get; set; }
    }
}
