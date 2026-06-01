using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaProject.Patterns.Prototype
{
    interface IPrototype<T>
    {
        T DeepClone();
        T ShallowClone();
    }
}
