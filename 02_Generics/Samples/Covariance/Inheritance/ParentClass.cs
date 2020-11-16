using System;
using System.Collections.Generic;
using System.Text;

namespace _02_Generics.Samples.Covariance.Inheritance
{
    public class ParentClass : IParentClass
    {
        public string ParentField { get; set; }
    }
}
