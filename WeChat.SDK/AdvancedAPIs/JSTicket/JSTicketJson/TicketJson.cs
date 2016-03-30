using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace WeChat.SDK
{
    public class TicketJson : WxJsonResult
    {
        public string ticket { get; set; }
        public int expires_in { get; set; }
    }
}
