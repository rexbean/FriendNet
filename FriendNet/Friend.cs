using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.IO.Compression;
using System.Text.RegularExpressions;


namespace FriendNet
{
    class Friend
    {
        int indexxxxx = 0;
        public string ID;
        public string name="0";
        public string url;
        //public string sourceCode;
        public Friend parent;
        public List<string> friendList = new List<string>();
        public List<string> friendNameList = new List<string>();
        
        public Friend(string ID)
        {
            this.ID = ID;
            url = "http://www.renren.com/" + ID+"/profile";
            //GetHtml getRootHtml = new GetHtml(url, GlobalData.cookiesstr, GlobalData.cc);
            //sourceCode= getRootHtml.GetHtmlMetheod();
            //sourceCode = NetWorkOperation.GetHtmlMetheod(url);
            //GetName();
        }
        
        public string AddFriend(string childFriendID)
        {
            //rootFriendID = RootFriendIDTextBox.Text.ToString();
            //childFriendID = ChileFriendIDTextBox.Text.ToString();
            //childFriendID = "262065657";
            StreamWriter sw =  File.AppendText("D:\\123456.txt");
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            string accept = "image/gif,image/x-xbitmap,image/jpeg,image/pjpeg,application/x-shockwave-flash";
            string contentType = "application/x-www-form-urlencoded";
            System.Text.Encoding encoding = System.Text.Encoding.GetEncoding("utf-8");
            string userAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022)";
            string url = "http://friend.renren.com/ajax_request_friend.do?from=www.renren.com/"+childFriendID+"/profile&";
            try
            {
                request = (HttpWebRequest)WebRequest.Create(url);
                request.CookieContainer = GlobalData.cc;
                request.Accept = accept;
                request.ContentType = contentType;
                request.UserAgent = userAgent;
                request.Referer = url;
                request.KeepAlive = true;
                request.Method = "POST";
                // string username1 = "1933747421@qq.com";
                // string password1 = "123456abc";


                string postData = string.Format("id={0}&why=你好&codeFlag=0&code=&requestToken={1}&_rtk={2}", childFriendID, GlobalData.requestToken, GlobalData._rtk);
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
                GlobalData.cc.Add(request.CookieContainer.GetCookies(request.RequestUri));
                GlobalData.cookiesstr = strcrook;
                //string encode = null;
                //get response
                //if (response.CharacterSet == "ISO-8859-1")
                //    encode = "gb2312";
                //else
                //    encode = response.CharacterSet;
                //Stream responseStream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
                //StreamReader reader =new StreamReader(responseStream, Encoding.GetEncoding("gzip"));
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream, encoding);
                string html = reader.ReadToEnd();
                sw.WriteLine(html);
                Console.WriteLine(indexxxxx++);
                reader.Close();
                responseStream.Close();
                response.Close();
                sw.Close();
                    return "1";
            }
            catch(Exception Ex)
            {
                return "0";
                //Login(username, password);
                throw Ex;
            }
        }
        public void GetMyFriendID()
        {
            int start;
            int end = 0;
            //int nameStart = 0;
            int nameEnd = 0;
            int countStart = 0;
            int countEnd = 0;
            int start1;
            int end1 = 0;
            int page = 0;
            int finalpage = 1;
            int renshu = 0;
            int friendcount;

            do
            {
                start = 0;
                end = 0;
                //nameStart = 0;
                nameEnd = 0;
                try
                {
                    string childUrl = "http://friend.renren.com/GetFriendList.do?curpage=" + page + "&id=" + this.ID;
                    string str = "";

                    #region get html source code
                    //GetHtml getChildHtml = new GetHtml(childUrl, GlobalData.cookiesstr, GlobalData.cc);
                    //str = getChildHtml.GetHtmlMetheod(childUrl);
                    str = NetWorkOperation.GetHtmlMetheod(childUrl);
                    //Console.Write(str);
                    //sw1.Write(str);
                    //sw1.Close();
                    #endregion

                    while (str != null)
                    {
                        countStart = str.IndexOf("\"count\">", end1);
                        countStart += "\"count\"".Length;
                        countEnd = str.IndexOf("</", countStart);
                        friendcount =int.Parse(str.Substring(countStart+1, countEnd - countStart-1));
                        GlobalData.addFriendForm.Invoke(GlobalData.addFriendForm.SetLabelDelegate, new object[] { friendcount.ToString() });
                        #region get the number of total pages
                        start1 = str.IndexOf("最后页", countEnd);
                        if (page == 0 && start1 != -1)
                        {
                            end1 = str.IndexOf('&', start1);
                            if (end1 - start1 - 37 < 0)
                            {
                                page++;
                                continue;

                            }
                            string number = str.Substring(start1 + 37, (end1 - start1 - 37));
                            finalpage = int.Parse(number);
                        }
                        #endregion
                        #region get the friend id
                        int a;
                        start = str.IndexOf("onclick=\"return doPoke(event,'", end);
                        if (start != -1)
                        {
                            end = str.IndexOf("','", start);
                            string number = str.Substring(start + 30, (end - start - 30));
                            try
                            {
                                
                                a = int.Parse(number);
                                int[] addstatue = { int.Parse(number), 1, 1 };
                                //nameStart = str.IndexOf("','", end);
                                int nameLength = number.Length;
                                nameEnd = str.IndexOf("')", end);
                                string childName = str.Substring(end + 3, nameEnd -end - 3);
                                GlobalData.T.insertTree(GlobalData.T, addstatue);
                                GlobalData.addFriendForm.Invoke(GlobalData.addFriendForm.FriendDelegate, new object[] { number + "饕" + childName + "饕" + "NO" });
                                
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.ToString());
                                continue;
                            }
                        }
                        else
                        {
                            break;
                        }
                        #endregion
                    }
                    page++;
                    #region print out the number of friends of each page
                    if (renshu == 0)
                    {
                        renshu = friendList.Count;
                        Console.WriteLine("this page has " + friendList.Count + "friends");
                    }
                    else
                    {
                        Console.WriteLine("this page has " + (friendList.Count - renshu).ToString() + "friends");
                        renshu = friendList.Count;

                    }
                    #endregion
                }
                catch (Exception Ex)
                {
                    Console.WriteLine(Ex.Message.ToString());
                    throw Ex;
                }
            } while (page != finalpage + 1);
 
        }

        public List<string> GetFriendID()
        {
            int index1=0;
            Boolean isEnough = false;
            //string statue;
            //friendId = FriendIDBox.Text.ToString();
            //StreamWriter sw1=new StreamWriter("d:\\456.txt");
            int start;
            int end = 0;
            int nameStart = 0;
            int nameEnd = 0;
            int start1;
            int end1 = 0;
            int page = 0;
            int finalpage = 1;
            int renshu = 0;

            do
            {
                start = 0;
                end = 0;
                nameStart = 0;
                nameEnd = 0;
                try
                {
                    string childUrl = "http://friend.renren.com/GetFriendList.do?curpage=" + page + "&id=" + this.ID;
                    string str = "";

                    #region get html source code
                    //GetHtml getChildHtml = new GetHtml(childUrl, GlobalData.cookiesstr, GlobalData.cc);
                    //str = getChildHtml.GetHtmlMetheod(childUrl);
                    str = NetWorkOperation.GetHtmlMetheod(childUrl);
                    //Console.Write(str);
                    //sw1.Write(str);
                    //sw1.Close();
                    #endregion

                    while (str != null)
                    {
                        #region get the number of total pages
                        start1 = str.IndexOf("最后页", end1);
                        if (page == 0 && start1 != -1)
                        {
                            end1 = str.IndexOf('&', start1);
                            if (end1 - start1 - 37 < 0)
                            {
                                page++;
                                continue;

                            }
                            string number = str.Substring(start1 + 37, (end1 - start1 - 37));
                            finalpage = int.Parse(number);
                        }
                        #endregion
                        #region get the friend id
                        int a;
                        start = str.IndexOf("onclick=\"return doPoke(event,'", end);
                        if (start != -1)
                        {
                            end = str.IndexOf("','", start);
                            string number = str.Substring(start + 30, (end - start - 30));
                            try
                            {
                                int[] addStatue;
                                a = int.Parse(number);
                                //nameStart = str.IndexOf(number.ToString() + "\',", end);
                                int nameLength = number.Length;
                                nameEnd = str.IndexOf("')", end);
                                string childName = str.Substring(end + 3, nameEnd - end - 3);
                                //findFriendInList(number);
                                friendList.Add(number);
                                
                                //检测原来是否添加过是否为好友
                                addStatue=GlobalData.T.Search(GlobalData.T, int.Parse(number));
                                if (addStatue[1] == 0)
                                {
                                    //int[] addStatue = { int.Parse(number), 0, 0 };
                                    GlobalData.AllFriendIDList.Add(number);
                                    GlobalData.index++;
                                    GlobalData.rootFriend.AddFriend(number);
                                    GlobalData.currentID2 = index1;
                                    index1++;
                                    GlobalData.addFriendForm.Invoke(GlobalData.addFriendForm.AddFriendDelegate, new object[] { ID + "饕" + name + "饕" + number + "饕" + childName + "饕" + addStatue[1] +"饕"+addStatue[2]});
                                    GlobalData.T.insertTree(GlobalData.T, addStatue);
                                }
                                else if(addStatue[1]==1)
                                {
                                    GlobalData.addFriendForm.Invoke(GlobalData.addFriendForm.AddFriendDelegate, new object[] { ID + "饕" + name + "饕" + number + "饕" + childName + "饕" + addStatue[1]+"饕"+addStatue[2]} );
                                }
                                    if (GlobalData.index >= GlobalData.count)
                                    {
                                        isEnough = true;
                                        break;
                                    }
                                
                               
                            }
                            catch(Exception e)
                            {
                                Console.WriteLine(e.ToString());
                                continue;
                            }
                        }
                        else
                        {
                            break;
                        }
                        #endregion
                    }

                    if (isEnough == true)
                    {
                        break;
                    }
                    page++;
                    #region print out the number of friends of each page
                    if (renshu == 0)
                    {
                        renshu = friendList.Count;
                        Console.WriteLine("this page has " + friendList.Count + "friends");
                    }
                    else
                    {
                        Console.WriteLine("this page has " + (friendList.Count - renshu).ToString() + "friends");
                        renshu = friendList.Count;

                    }
                    #endregion
                }
                catch (Exception Ex)
                {
                    Console.WriteLine(Ex.Message.ToString());
                    throw Ex;
                }
            } while (page != finalpage + 1);

            #region out put the friends id txt
            //string outPutPath = "D://inspiration//FriendNet//" + ID + "-Id.txt";
            //StreamWriter sw = new StreamWriter(outPutPath, true);
            //foreach (string id in friendList)
            //{
            //    //AllFriendIdBox.Text += id.ToString() + "\r\n";
            //    sw.WriteLine(id);
            //}
            //sw.Close();
            #endregion
            Console.WriteLine("Your friend has " + friendList.Count + " friends");
            return friendList;
 
        }
        public string findFriendInList(string number)
        {
            int i = 0;
            char[] numberArray=number.ToArray();

            while (i < numberArray.Length)
            {
 
            }
            return "1";
        }

    }
}
