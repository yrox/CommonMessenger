using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Data.Identity.Entities
{
    public class User : IdentityUser
    {
        public IEnumerable<Account> Accounts { get; set; }
    }
}
