using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeChat.SDK.Entities;

namespace WeChat.SDK.AdvancedAPIs.JSTicket.JSTicketJson
{
    public class TicketJson : WxJsonResult
    {
        public string ticket { get; set; }
        public int expires_in { get; set; }
    }
}
