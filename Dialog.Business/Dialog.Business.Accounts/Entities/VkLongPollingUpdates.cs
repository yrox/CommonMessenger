using System.Collections.Generic;

namespace Dialog.Business.Accounts.Entities
{
    public class VkLongPollingUpdates
    {
        public ulong Ts { get; set; }
        public IEnumerable<IEnumerable<string>> Updates { get; set; }
    }
}
