using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;

namespace FriendNet
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string username;
            string password;
            
            username = UserNameTextBox.Text.ToString();
            password = PasswordTextBox.Text.ToString();
            //if (username != "" || password != "")
            //{
            NetWorkOperation.Login(username, password);
            //}
            //else
            //{
            //    MessageBox.Show("用户名或密码不能为空！");
            //}
        }

        private void button1_Click(object sender, EventArgs e)
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
            //Boolean a=tree.Search(tree, 6);
            int id = 73915;
            String url = "";
            int end = 0;
            int start = 0;
            for (int i = id; i < 75001; i+=2)
            {
                end = 0;
                start = 0;
                try
                {
                    url = "http://www.fmdisk.com/file-" + i + ".html";
                    string str = "";
                    str = NetWorkOperation.GetHtmlMetheod(url);
                    start = str.IndexOf("keywords", end);
                    start += 19;
                    end = str.IndexOf(".", start);
                    string name = str.Substring(start, end - start);
                    Console.WriteLine(i+"-"+name);
                    if (name.Equals("S1492539 DZ"))
                    {
                        MessageBox.Show("That's it!");
                    }
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine("error" + i);
                    continue;
                }
                
            }
            MessageBox.Show("ALL over!");
        }
        
        
       
    }
}
