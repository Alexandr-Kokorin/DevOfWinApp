﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2CS
{
    internal class Sin: IFunction {
        public float calc(float x) {
            return (float)Math.Sin(x);
        }
    }
}
