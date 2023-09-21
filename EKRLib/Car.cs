using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKRLib
{
    public class Car : Transport
    {
        public Car(string model, uint power) : base(model, power) { }
        
        public override string ToString()
        {
            return "Car. " + base.ToString();
        }
        /// <summary>
        /// Переопределенный метод StartEngine
        /// </summary>
        /// <returns></returns>
        public override string StartEngine()
        {
            return $"{Model}: Vroom";
        }


    }
}
