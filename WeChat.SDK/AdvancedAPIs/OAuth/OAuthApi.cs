using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WeChat.SDK.Utilities;

namespace WeChat.SDK
{
    public static class OAuthApi
    {
        /// <summary>
        /// 获取AccessToken
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="secret"></param>
        /// <param name="code">code作为换取access_token的票据，每次用户授权带上的code将不一样，code只能使用一次，5分钟未被使用自动过期。</param>
        /// <param name="grantType"></param>
        /// <returns></returns>
        public static OAuthAccessToken GetAccessToken(string appId, string secret, string code, string grantType = "authorization_code")
        {
            var url = string.Format("https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type={3}", appId, secret, code, grantType);
            return HttpUtility.GetJson<OAuthAccessToken>(url);
        }

        /// <summary>
        /// 刷新access_token（如果需要）
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="refreshToken">填写通过access_token获取到的refresh_token参数</param>
        /// <param name="grantType"></param>
        /// <returns></returns>
        public static OAuthAccessToken RefreshToken(string appId, string refreshToken, string grantType = "refresh_token")
        {
            var url = string.Format("https://api.weixin.qq.com/sns/oauth2/refresh_token?appid={0}&grant_type={1}&refresh_token={2}", appId, grantType, refreshToken);
            return HttpUtility.GetJson<OAuthAccessToken>(url);
        }

        /// <summary>
        /// 获取用户基本信息
        /// </summary>
        /// <param name="accessToken">调用接口凭证</param>
        /// <param name="openId">普通用户的标识，对当前公众号唯一</param>
        /// <param name="lang">返回国家地区语言版本，zh_CN 简体，zh_TW 繁体，en 英语</param>
        /// <returns></returns>
        public static OAuthUserInfo GetUserInfo(string accessToken, string openId, Language lang = Language.zh_CN)
        {
            var url = string.Format("https://api.weixin.qq.com/sns/userinfo?access_token={0}&openid={1}&lang={2}", accessToken, openId, lang);
            return HttpUtility.GetJson<OAuthUserInfo>(url);
        }

        /// <summary>
		/// 检验授权凭证（access_token）是否有效
		/// </summary>
		/// <param name="accessToken"></param>
        /// <param name="openId">用户的唯一标识</param>
		/// <returns></returns>
		public static WxJsonResult Auth(string accessToken, string openId)
        {
            var url = string.Format("https://api.weixin.qq.com/sns/auth?access_token={0}&openid={1}", accessToken, openId);
            return HttpUtility.GetJson<WxJsonResult>(url);
        }
    }
}
