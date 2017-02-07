using System.Collections.Generic;

namespace Business.Models
{
    public class VkLongPollingUpdates
    {
        public ulong Ts { get; set; }
        public IEnumerable<IEnumerable<string>> Updates { get; set; }
    }
}
