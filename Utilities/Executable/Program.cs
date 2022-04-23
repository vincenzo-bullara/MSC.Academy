using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Utilities
{
    public class Program
    {
        static void Main(string[] args)
        {
            Utilities.Util test = new Utilities.Util();
            List<int> list = new List<int>() { 3,2,1,0};
            test.ValueSelect(list);
        }
    }
}
