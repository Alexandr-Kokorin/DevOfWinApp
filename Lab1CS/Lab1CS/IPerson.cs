using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1CS
{
    public interface IPerson {
        int CardNumber { get; set; }
        string Name { get; set; }
        DateTime Bithday { get; set; }
        int calcAge(DateTime date);
    }

}
