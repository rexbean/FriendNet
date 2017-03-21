using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.IO.Compression;
using System.Threading;
using Microsoft.Win32;
using System.Diagnostics;

namespace FriendNet
{
    public partial class AddFriendForm : Form
    {
        public delegate void AddListItem(String myString);
        public delegate void SetLabel(String count);
        public SetLabel SetLabelDelegate;
        public AddListItem AddFriendDelegate;
        public AddListItem FriendDelegate;

        private int[] addStatue = new int[2];
        //private string Cookiesstr;
        private CookieContainer cc;
        //private string _rtk;
        //private string token;
        public AddFriendForm(string Cookiesstr, CookieContainer cc,string _rtk,string token)
        {
            InitializeComponent();
            listView1.View = View.Details;
            AddFriendDelegate = new AddListItem(AddFriendListItemMethod);
            SetLabelDelegate = new SetLabel(SetFriendCountLabel);
            FriendDelegate = new AddListItem(FriendListItemMethod);
        }

        

        public void SetFriendCountLabel(string Count)
        {
            FriendCountLabel.Text = Count;
        }

        public void AddFriendListItemMethod(String myString)
        {
            //listView1.Items.Add(myString);
            string[] myStringArray = myString.Split('饕');
            ListViewItem lvt = new ListViewItem();
            lvt.Text = myStringArray[0];
            lvt.SubItems.Add(myStringArray[1]);
            lvt.SubItems.Add(myStringArray[2]);
            lvt.SubItems.Add(myStringArray[3]);
            lvt.SubItems.Add(myStringArray[4]);
            lvt.SubItems.Add(myStringArray[5]);
            this.listView1.Items.Add(lvt);
        }
        public void FriendListItemMethod(String myString)
        {
            //listView1.Items.Add(myString);
            string[] myStringArray = myString.Split('饕');
            ListViewItem lvt = new ListViewItem();
            lvt.Text = myStringArray[0];
            lvt.SubItems.Add(myStringArray[1]);
            this.listView2.Items.Add(lvt);
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            //string rootFriendID=RootFriendIDTextBox.Text.ToString();
            string childFriendID = ChildFriendIDTextBox.Text.ToString();
            int count=int.Parse(NewFriendCountTextBox.Text);
            GlobalData.count = count;
            //string childFriendID = "262065657";
            //string rootFriendID = "507565600";
            GlobalData.AllFriendIDList.Add(childFriendID);
            if (childFriendID != "")
            {

                //string statue;
                //GlobalData.rootFriend = new Friend(rootFriendID);
                
                //statue=GlobalData.rootFriend.AddFriend(childFriendID);
                
                GlobalData.addFriendThread = new Thread(new ThreadStart(NetWorkOperation.AddAllFriends));
                GlobalData.addFriendThread.Start();

            }
            else
            {
                MessageBox.Show("根好友ID不能为空");
            }
            
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            GlobalData.addFriendThread.Suspend();
            stopButton.Enabled = false;
            continueButton.Enabled = true;
        }

        private void continueButton_Click(object sender, EventArgs e)
        {
            GlobalData.addFriendThread.Resume();
            stopButton.Enabled = true;
            continueButton.Enabled = false;
        }



        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            string url = null;
            string selectedID=listView1.SelectedItems[0].SubItems[2].Text;
            //string selectedID = "262065657";
            url = "http://www.renren.com/" + selectedID + "/profile";
            ////Console.WriteLine(selectedNumber);
            RegistryKey key = Registry.ClassesRoot.OpenSubKey("http\\DefaultIcon", false);
            String path = key.GetValue("").ToString();
            if (path.Contains(","))
            {
                path = path.TrimStart('"');
                path = path.Substring(0, path.IndexOf(','));
            }
            key.Close();
            Process.Start(path, url);
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            GlobalData.rootFriend.GetMyFriendID();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //BalancedSearchTree tree = new BalancedSearchTree(int.MinValue);
            //tree.insertTree(tree, 10);
            //tree.insertTree(tree, 5);
            //tree.insertTree(tree, 13);
            //tree.insertTree(tree, 2);
            //tree.insertTree(tree, 7);
            //tree.insertTree(tree, 4);
            //tree.insertTree(tree, 6);
            //tree.insertTree(tree, 3);
            //tree.middle(tree);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string hostName = System.Reflection.Assembly.GetExecutingAssembly().Location;
            hostName = hostName.Substring(0 , hostName.LastIndexOf('\\') );
            StreamWriter sw = new StreamWriter(hostName+"\\friend.txt");
            GlobalData.T.middle(GlobalData.T, sw);
            sw.Close();
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            string[] FriendArray;
            
            string hostName = System.Reflection.Assembly.GetExecutingAssembly().Location;
            hostName = hostName.Substring(0, hostName.LastIndexOf('\\'));
            //StreamWriter sw = new StreamWriter(hostName + "\\friend.txt");
            FileStream fs = new FileStream(hostName + "\\friend.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs); 
            string sLine = sr.ReadLine();
            while (sLine != null)
            {
                int[] FriendStatue=new int[3];
                FriendArray = sLine.Split('饕');
                FriendStatue[0] = int.Parse(FriendArray[0]);
                FriendStatue[1] = int.Parse(FriendArray[1]);
                FriendStatue[2] = int.Parse(FriendArray[2]);
                GlobalData.T.insertTree(GlobalData.T, FriendStatue);
                sLine = sr.ReadLine();
            }
            fs.Close();
            int[] state = GlobalData.T.Search(GlobalData.T, 221665698);
            
                       
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 1; i++)
            {
                GlobalData.rootFriend.AddFriend("262065657");
            }
        }

        private void goonButton_Click(object sender, EventArgs e)
        {
            
        }
    }
}
