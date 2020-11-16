using System;
using System.Collections.Generic;
using System.Text;

namespace _02_Generics.Samples.Covariance.Inheritance
{
    public class ChildClass : ParentClass, IChild
    {
        public string ChildField { get; set; }
    }
}
