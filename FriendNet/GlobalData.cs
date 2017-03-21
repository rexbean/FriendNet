using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Threading;


namespace FriendNet
{
    class GlobalData
    {
        public static CookieContainer cc;
        public static string cookiesstr;
        public static string requestToken;
        public static string _rtk;
        public static List<List<string>> AllFriendIDListList=new List<List<string>>();
        public static List<string> AllFriendIDList = new List<string>();
        public static AddFriendForm addFriendForm;
        public static int count;
        public static Thread addFriendThread;
        public static int index;
        public static Friend rootFriend;
        public static int currentID1;
        public static int currentID2;
        public static BalancedSearchTree T=new BalancedSearchTree(new int[]{int.MinValue,0,0}) ;
        //public struct AddStatue 
        //{
        //    int ParentID;
        //    string ParentName;
        //    int ID;
        //    int Name;
        //    string Statue;
        //    int times;
            
        //};
        //public static AddStatue[,] addStatue=new AddStatue[9,10];

    }
}
