using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP1
{
    public class Category
    {
        public int Id;
        public string Name;
        public void PrintInfo()
        {
            string msg = $" {Id} \t {Name}";
            Console.WriteLine(msg);
        }
    }
}
