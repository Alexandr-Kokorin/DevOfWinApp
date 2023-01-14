using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4CS
{
    internal class Func4: IFunction
    {
        public float calc(float x, float y)
        {
            return (100*(y-x*x)* (y - x * x)+(1-x)* (1 - x))/2000;
        }
    }
}
