using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeChat.SDK.Utilities;

namespace WeChat.SDK
{
    public class JSTicketApi
    {
        /// <summary>
        /// 获取JsTicket
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static TicketJson GetJSTicket(string accessToken)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token={0}&type=jsapi", accessToken);
            return HttpUtility.GetJson<TicketJson>(url);
        }
    }
}
