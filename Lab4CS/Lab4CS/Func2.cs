using System;

namespace Lab4CS
{
    internal class Func2 : IFunction
    {
        public float calc(float x, float y) {
            return 4*((float)Math.Sin(x * x + y * y)/(x*x + y*y));
        }
    }
}
