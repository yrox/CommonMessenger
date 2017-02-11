using System.Collections.Generic;

namespace Dialog.AccountsHandling.Entities
{
    public class VkLongPollingUpdates
    {
        public ulong Ts { get; set; }
        public IEnumerable<IEnumerable<string>> Updates { get; set; }
    }
}
