using System;

namespace Lab4CS
{
    internal class Func3 : IFunction
    {
        public float calc(float x, float y) {
            return (float)(x * Math.Sin(y) + Math.Sin(x) * y);
        }
    }
}
