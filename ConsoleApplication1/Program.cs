using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.Entities;


namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var d = new Context();
            d.Contacts.Add(new Contact());
        }
    }
}
