using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvvm.Model
{
    internal class Number
    {
        public Number(string num)
        {
            Num = num;
        }
        public string Num {  get; set; }
    }
}
