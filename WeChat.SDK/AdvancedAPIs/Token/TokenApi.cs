using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeChat.SDK.Utilities;

namespace WeChat.SDK
{
    public static class TokenApi
    {
        /// <summary>
        /// 获取AccessToken
        /// </summary>
        /// <param name="appId">微信开发appId</param>
        /// <param name="secret">微信开发secret</param>
        /// <returns></returns>
        public static AccessTokenJson GetAccessToken(string appId, string secret)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}", appId, secret);
            return HttpUtility.GetJson<AccessTokenJson>(url);
        }
    }
}
