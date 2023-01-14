using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3CS
{
    public interface ICarBrand {
        string Brand { get; set; }
        string Model { get; set; }
        string Power { get; set; }
        string MaximumSpeed { get; set; }
    }
}
