using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using WeChat.SDK.Entities;

namespace WeChat.SDK.Utilities
{
    public class HttpUtility
    {
        /// <summary>
        /// GET方式请求URL，并返回T类型
        /// </summary>
        /// <typeparam name="T">接收JSON的数据类型</typeparam>
        /// <param name="url"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static T GetJson<T>(string url, Encoding encoding = null)
        {
            string returnText = HttpGet(url, encoding);
            JavaScriptSerializer js = new JavaScriptSerializer();
            // 对返回结果进行分析
            //if (returnText.Contains("errcode"))
            //{
            //    //可能发生错误
            //    WxJsonResult errorResult = js.Deserialize<WxJsonResult>(returnText);
            //    if (errorResult.errcode != "0")
            //    {

            //    }
            //}
            T result = js.Deserialize<T>(returnText);

            return result;
        }
        /// <summary>
        /// 使用Get方法获取字符串结果（没有加入Cookie）
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string HttpGet(string url, Encoding encoding = null)
        {
            WebClient wc = new WebClient();
            wc.Encoding = encoding ?? Encoding.UTF8;

            return wc.DownloadString(url);
        }

        /// <summary>
        /// GET方式请求URL，并返回T类型
        /// </summary>
        /// <typeparam name="T">接收JSON的数据类型</typeparam>
        /// <param name="url"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static T PostJson<T>(string url, string postData)
        {
            string returnText = HttpPost(url, postData);
            JavaScriptSerializer js = new JavaScriptSerializer();
            // 对返回结果进行分析
            //if (returnText.Contains("errcode"))
            //{
            //    //可能发生错误
            //    WxJsonResult errorResult = js.Deserialize<WxJsonResult>(returnText);
            //    if (errorResult.errcode != "0")
            //    {

            //    }
            //}
            T result = js.Deserialize<T>(returnText);

            return result;
        }
        /// <summary>
        /// 使用Post方法获取字符串结果
        /// </summary>
        /// <param name="url"></param>
        /// <param name="cookieContainer"></param>
        /// <param name="postStream"></param>
        /// <param name="fileDictionary">需要上传的文件，Key：对应要上传的Name，Value：本地文件名</param>
        /// <param name="encoding"></param>
        /// <param name="timeOut"></param>
        /// <param name="checkValidationResult">验证服务器证书回调自动验证</param>
        /// <param name="refererUrl"></param>
        /// <returns></returns>
        public static string HttpPost(string url, string postData)
        {
            Uri URI = new Uri(url);
            byte[] byteArr = Encoding.UTF8.GetBytes(postData);
            HttpWebRequest request = WebRequest.Create(URI) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArr.Length;
            Stream st = request.GetRequestStream();
            st.Write(byteArr, 0, byteArr.Length);
            st.Close();
            WebResponse response = request.GetResponse() as WebResponse;
            System.IO.Stream responseStream = response.GetResponseStream();
            System.IO.StreamReader reader = new System.IO.StreamReader(responseStream, Encoding.UTF8);
            string srcString = reader.ReadToEnd();
            responseStream.Dispose();
            reader.Dispose();
            return srcString;
        }
    }
}
