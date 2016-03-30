using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

using WeChat.SDK.Utilities;

namespace WeChat.SDK.AdvancedAPIs.TemplateMessage
{
    public class TemplateApi
    {
        /// <summary>
        /// 模板消息接口
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="openId"></param>
        /// <param name="templateId"></param>
        /// <param name="topcolor"></param>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static SendTemplateMessageResult SendTemplateMessage(string accessToken, string openId, string templateId, string topcolor, string url, object data)
        {
            string urlFormat = string.Format("https://api.weixin.qq.com/cgi-bin/message/template/send?access_token={0}", accessToken);
            var msgData = new TempleteModel()
            {
                touser = openId,
                template_id = templateId,
                topcolor = topcolor,
                url = url,
                data = data
            };
            JavaScriptSerializer js = new JavaScriptSerializer();
            string jsonData = js.Serialize(msgData);
            return HttpUtility.PostJson<SendTemplateMessageResult>(urlFormat, jsonData);
        }
    }
}