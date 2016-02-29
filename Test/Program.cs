using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeChat.SDK.AdvancedAPIs.Token;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var Token = TokenApi.GetAccessToken("wx98a0e4afc412cd23", "afd66cf094de6ec67ba3406d32c16b88");
            Console.WriteLine(Token.access_token);
            Console.WriteLine("2332");
        }
    }
}
