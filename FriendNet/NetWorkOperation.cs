using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FriendNet
{
    class NetWorkOperation
    {
        static System.Text.Encoding encoding = System.Text.Encoding.GetEncoding("utf-8");

        public static void Login(string username, string password)
        {
            System.Net.ServicePointManager.DefaultConnectionLimit = 200;
            StreamWriter sw = new StreamWriter(@"d:\123.txt");
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            string accept = "image/gif,image/x-xbitmap,image/jpeg,image/pjpeg,application/x-shockwave-flash";
            System.Net.CookieContainer cc = new CookieContainer();
            string contentType = "application/x-www-form-urlencoded";
            System.Text.Encoding encoding = System.Text.Encoding.GetEncoding("utf-8");
            string userAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022)";
            string url = "http://www.renren.com/ajaxLogin/login?1=1&uniqueTimestamp=2014862254916";
            string Cookiesstr;
            //try
            //{
                System.GC.Collect();
                request = (HttpWebRequest)WebRequest.Create(url);
                request.CookieContainer = cc;
                request.Accept = accept;
                request.ContentType = contentType;
                request.UserAgent = userAgent;
                request.Referer = url;
                request.KeepAlive =false;
                request.Method = "POST";
                request.Proxy = null;
                string username1 = "jockis518@tom.com";
                string password1 = "tobemyself";
                //string postData = string.Format("email={0}&password={1}&origURL=http%3A%2F%2Fwww.renren.com%2FHome.do&domain=renren.com", username1, password1);
                string postData = string.Format("email={0}&icode=&origURL=http%3A%2F%2Fwww.renren.com%2Fhome&domain=renren.com&key_id=1&captcha_type=web_login&password={1}&rkey=94f16705a57a1307396afb1a8cc00ba7&f=http%253A%252F%252Fwww.renren.com%252F262065657", username1, password1);    
            //string postData = string.Format("email={0}&password={1}&origURL=http%3A%2F%2Fwww.renren.com%2FHome.do&domain=renren.com", username, password);
                if (!string.IsNullOrEmpty(postData))
                {
                    byte[] bytes = System.Text.Encoding.Default.GetBytes(postData);
                    request.ContentLength = bytes.Length;
                    Stream requestStream = request.GetRequestStream();
                    requestStream.Write(bytes, 0, bytes.Length);
                    requestStream.Close();
                }
                
                response = (HttpWebResponse)request.GetResponse();

                string strcrook = request.CookieContainer.GetCookieHeader(request.RequestUri);
                cc.Add(request.CookieContainer.GetCookies(request.RequestUri));
                Cookiesstr = strcrook;

                //get response
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream, encoding);
                string html = reader.ReadToEnd();
                sw.Write(html);
                sw.Close();
                reader.Close();
                responseStream.Close();
                response.Close();
                

                Regex r = new Regex("您的用户名和密码不匹配");
                Match m = r.Match(html);

                int startIndex_token = html.IndexOf("get_check:'");
                startIndex_token += "get_check:'".Length;
                int endIndex_token = html.IndexOf("',");
                string token = html.Substring(startIndex_token, endIndex_token - startIndex_token);


                int startIndex_rtk = html.IndexOf("get_check_x:'");
                startIndex_rtk += "get_check_x:'".Length;
                int endIndex_rtk = html.IndexOf("',env");
                string _rtk = html.Substring(startIndex_rtk, endIndex_rtk - startIndex_rtk);

                int startIndex_Id = html.IndexOf("id':'");
                startIndex_Id += "id':'".Length;
                int endIndex_Id = html.IndexOf("',", startIndex_Id);
                string id = html.Substring(startIndex_Id, endIndex_Id - startIndex_Id);

                GlobalData.rootFriend = new Friend(id);

                if (m.Success)
                {
                    Console.WriteLine("登陆失败");
                }
                else
                {
                    Console.WriteLine("登录成功");
                    AddFriendForm aff = new AddFriendForm(Cookiesstr, cc, _rtk, token);
                    aff.Show();
                    GlobalData.addFriendForm = aff;
                    GlobalData._rtk = _rtk;
                    GlobalData.requestToken = token;
                    GlobalData.cc = cc;
                    GlobalData.cookiesstr = Cookiesstr;
                }
            //}
            //catch (Exception Ex)
            //{
            //    MessageBox.Show(Ex.Message.ToString());

            //    //Login(username, password);

            //}

        }

        public static string GetHtmlMetheod(string url)
        {
            
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.Headers.Add("Cookie:" + GlobalData.cookiesstr);
            request.CookieContainer = GlobalData.cc;
            request.AllowAutoRedirect = false;
            response = (HttpWebResponse)request.GetResponse();
            //Cookiesstr = request.CookieContainer.GetCookieHeader(request.RequestUri);
            StreamReader sr = new StreamReader(response.GetResponseStream(), encoding);
            string str = sr.ReadToEnd();
            request.Abort();
            sr.Close();
            response.Close();
            return str;
        }

        public static void AddAllFriends()
        {
            int index = 0;
            while (GlobalData.index <= GlobalData.AllFriendIDList.Count && GlobalData.index < GlobalData.count)
            {
                GlobalData.currentID1 = index;
                Friend f = new Friend(GlobalData.AllFriendIDList[index]);
                f.GetFriendID();
                index++;
            }

        }
    }
}
