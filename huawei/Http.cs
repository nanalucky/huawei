using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.IO;

namespace huawei
{
    class Http
    {
        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true; //总是接受  
        }

        public static string Timestamp()
        {
            TimeSpan span = (DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime());
            return ((ulong)span.TotalMilliseconds).ToString();
        }
       

        public static void login()
        { 
            HttpWebRequest request=null;
            CookieContainer myCookieContainer = new CookieContainer();

            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
            request = WebRequest.Create(@"https://secure.damai.cn/login.aspx?ru=https://www.damai.cn/") as HttpWebRequest;  
            request.ProtocolVersion=HttpVersion.Version10;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/52.0.2743.116 Safari/537.36 Edge/15.15063";
            request.CookieContainer = myCookieContainer;

            string timestamp = Timestamp();
            StringBuilder buffer = new StringBuilder();
            buffer.AppendFormat("{0}={1}", "token", timestamp);
            buffer.AppendFormat("&{0}={1}", "nationPerfix", "86");
            buffer.AppendFormat("&{0}={1}", "login_email", "18621076121");
            buffer.AppendFormat("&{0}={1}", "login_pwd", "123456");
            buffer.AppendFormat("&{0}=", "csessionid1");
            buffer.AppendFormat("&{0}=", "sig1");
            buffer.AppendFormat("&{0}=", "alitoken1");
            buffer.AppendFormat("&{0}=", "scene1");
            Encoding requestEncoding = Encoding.GetEncoding("utf-8"); 
            byte[] data = requestEncoding.GetBytes(buffer.ToString());
            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }  
            
            WebResponse response = request.GetResponse();
            string cookieString = response.Headers["Set-Cookie"];
            Console.WriteLine(string.Format("2:{0}", cookieString));


            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
            request = WebRequest.Create(@"https://secure.damai.cn/login.aspx?ru=https://www.damai.cn/") as HttpWebRequest;
            request.ProtocolVersion = HttpVersion.Version10;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/52.0.2743.116 Safari/537.36 Edge/15.15063";
            request.CookieContainer = myCookieContainer;

            buffer = new StringBuilder();
            buffer.AppendFormat("{0}={1}", "token", timestamp);
            buffer.AppendFormat("&{0}={1}", "nationPerfix", "86");
            buffer.AppendFormat("&{0}={1}", "login_email", "18621076121");
            buffer.AppendFormat("&{0}={1}", "login_pwd", "123456");
            buffer.AppendFormat("&{0}=", "csessionid1");
            buffer.AppendFormat("&{0}=", "sig1");
            buffer.AppendFormat("&{0}=", "alitoken1");
            buffer.AppendFormat("&{0}=", "scene1");
            requestEncoding = Encoding.GetEncoding("utf-8");
            data = requestEncoding.GetBytes(buffer.ToString());
            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            response = request.GetResponse();
            cookieString = response.Headers["Set-Cookie"];
            Console.WriteLine(string.Format("2:{0}", cookieString));

            CookieContainer myCookieContainer1 = new CookieContainer();
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
            request = WebRequest.Create(@"https://log.mmstat.com/eg.js") as HttpWebRequest;
            request.ProtocolVersion = HttpVersion.Version10;
            request.Method = "GET";
            request.Accept = "application/javascript, */*;q=0.8";
            request.Referer = "https://www.damai.cn/";
            request.ContentType = "application/x-www-form-urlencoded";
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/52.0.2743.116 Safari/537.36 Edge/15.15063";
            request.CookieContainer = myCookieContainer1;

            response = request.GetResponse();
            cookieString = response.Headers["Set-Cookie"];
            Console.WriteLine(string.Format("3:{0}", cookieString));        
        }
    }
}
