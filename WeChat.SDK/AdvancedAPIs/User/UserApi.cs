using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using WeChat.SDK.AdvancedAPIs.User.UserJson;
using WeChat.SDK.Entities;
using WeChat.SDK.Utilities;

namespace WeChat.SDK.AdvancedAPIs.User
{
    /// <summary>
    /// 用户接口
    /// </summary>
    public static class UserApi
    {
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="accessToken">调用接口凭证</param>
        /// <param name="openId">普通用户的标识，对当前公众号唯一</param>
        /// <param name="lang">返回国家地区语言版本，zh_CN 简体，zh_TW 繁体，en 英语</param>
        /// <returns></returns>
        public static UserInfoJson GetUserInfo(string accessToken, string openId, Language lang = Language.zh_CN)
        {

            string url = string.Format("https://api.weixin.qq.com/cgi-bin/user/info?access_token={0}&openid={1}&lang={2}",
accessToken, openId, lang);
            return HttpUtility.GetJson<UserInfoJson>(url);
            //错误时微信会返回错误码等信息，JSON数据包示例如下（该示例为AppID无效错误）:
            //{"errcode":40013,"errmsg":"invalid appid"}
        }

        /// <summary>
        /// 批量获取关注用户OpenId
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="nextOpenId"></param>
        /// <returns></returns>
        public static OpenIdResultJson BatchGetUserOpenId(string accessToken, string nextOpenId)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/user/get?access_token={0}", accessToken);
            if (!string.IsNullOrEmpty(nextOpenId))
            {
                url += "&next_openid=" + nextOpenId;
            }
            return HttpUtility.GetJson<OpenIdResultJson>(url);
        }

        /// <summary>
        /// 修改关注者备注信息
        /// </summary>
        /// <param name="accessToken">调用接口凭证</param>
        /// <param name="openId">普通用户的标识，对当前公众号唯一</param>
        /// <param name="remark">新的备注名，长度必须小于30字符</param>
        /// <returns></returns>
        public static WxJsonResult UpdateUserRemark(string accessToken, string openId, string remark)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/user/info/updateremark?access_token={0}", accessToken);
            var data = new
            {
                openid = openId,
                remark = remark
            };
            JavaScriptSerializer js = new JavaScriptSerializer();
            string jsonData = js.Serialize(data);
            return HttpUtility.PostJson<WxJsonResult>(url, jsonData);
        }

        /// <summary>
        /// 批量获取用户基本信息
        /// </summary>
        /// <param name="accessTokenOrAppId"></param>
        /// <param name="userList"></param>
        /// <returns></returns>
        public static BatchGetUserInfoJson BatchGetUserInfo(string accessToken, List<BatchGetUserInfoData> userList)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/user/info/batchget?access_token={0}", accessToken);
            var data = new
            {
                user_list = userList,
            };
            JavaScriptSerializer js = new JavaScriptSerializer();
            string jsonData = js.Serialize(data);
            return HttpUtility.PostJson<BatchGetUserInfoJson>(url, jsonData);
        }
    }
}
