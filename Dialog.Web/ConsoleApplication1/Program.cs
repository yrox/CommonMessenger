using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dialog.Data;
using Dialog.Data.Entities;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var u = new DialogUnitOfWork("Dialog");
            u.AccountsRepository.Insert(new Account {Password = "test", Login = "test"});
            u.SaveChanges();
        }
    }
}
