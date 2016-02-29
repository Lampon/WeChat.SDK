using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeChat.SDK.Entities
{
    /// <summary>
    /// 公众号JSON返回结果（用于菜单接口等）
    /// </summary>
    [Serializable]
    public class WxJsonResult
    {
        public WxJsonResult()
        {
            errcode = "0";
        }
        public string errcode { get; set; }
        public string errmsg { get; set; }
        //public string errmsg_zh { get; set; }
    }
}
