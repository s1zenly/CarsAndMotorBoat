using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKRLib
{
    public class MotorBoat : Transport
    {
        public MotorBoat(string model, uint power) : base(model, power) { }

        public override string ToString()
        {
            return "MotorBoat. " + base.ToString();
        }
        /// <summary>
        /// Переопределенные метод StartEngine
        /// </summary>
        /// <returns></returns>
        public override string StartEngine()
        {
            return $"{Model}: Brrrbrr";
        }
    }
}
