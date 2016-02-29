using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeChat.SDK.Entities;

namespace WeChat.SDK.AdvancedAPIs.Token.TokenJson
{
    public class AccessTokenJson : WxJsonResult
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
    }
}
