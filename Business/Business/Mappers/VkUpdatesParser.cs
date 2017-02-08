using System;
using System.Collections.Generic;
using System.Linq;
using Business.Models;
using Newtonsoft.Json;
using VkNet.Model;

namespace Business.Mappers
{
    public class VkUpdatesParser
    {
        public static VkLongPollingUpdates DeserializeUpdates(string updates)
        {
            return JsonConvert.DeserializeObject<VkLongPollingUpdates>(updates);
        }
        public static IEnumerable<VkNet.Model.Message> GetMessagesFromUpdate(VkLongPollingUpdates updates)
        {
            
            var newMessages = updates.Updates.Where(x => Convert.ToInt32(x.First()) == 4).ToList();
            return newMessages.Select(message => message as IList<string> ?? message.ToList()).Select(enumerable => new Message
            {
                Body = enumerable.ElementAt(6),
                Date = EntitiesMapper.ConvertFromUnixTimestamp(Convert.ToInt32(enumerable.ElementAt(4))),
                FromId = Convert.ToInt32(enumerable.ElementAt(3))
            }).ToList();
        }
    }
}
