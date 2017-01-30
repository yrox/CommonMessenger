using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Services;
using Data.Entities;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var c = new ContactsService();
            var s = c.NewContactAdded(new Contact {Name = "1111"}).Result;
        }
    }
}
