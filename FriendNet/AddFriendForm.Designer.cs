namespace FriendNet
{
    partial class AddFriendForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.NewFriendCountLabel = new System.Windows.Forms.Label();
            this.NewFriendCountTextBox = new System.Windows.Forms.TextBox();
            this.OriginFriendIDLabel = new System.Windows.Forms.Label();
            this.AcceptButton = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.RootFriendID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RootFriendName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ChildFriendID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ChildFriendName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Statue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AddTimes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ChildFriendIDTextBox = new System.Windows.Forms.TextBox();
            this.stopButton = new System.Windows.Forms.Button();
            this.continueButton = new System.Windows.Forms.Button();
            this.goonButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.MyfriendTabPage = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.FriendCountLabel = new System.Windows.Forms.Label();
            this.refreshButton = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.listView2 = new System.Windows.Forms.ListView();
            this.FriendID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FriendName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AddFriendTabPage = new System.Windows.Forms.TabPage();
            this.saveButton = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.MyfriendTabPage.SuspendLayout();
            this.AddFriendTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // NewFriendCountLabel
            // 
            this.NewFriendCountLabel.AutoSize = true;
            this.NewFriendCountLabel.Location = new System.Drawing.Point(11, 14);
            this.NewFriendCountLabel.Name = "NewFriendCountLabel";
            this.NewFriendCountLabel.Size = new System.Drawing.Size(77, 12);
            this.NewFriendCountLabel.TabIndex = 0;
            this.NewFriendCountLabel.Text = "添加好友数量";
            // 
            // NewFriendCountTextBox
            // 
            this.NewFriendCountTextBox.Location = new System.Drawing.Point(92, 9);
            this.NewFriendCountTextBox.Name = "NewFriendCountTextBox";
            this.NewFriendCountTextBox.Size = new System.Drawing.Size(100, 21);
            this.NewFriendCountTextBox.TabIndex = 1;
            // 
            // OriginFriendIDLabel
            // 
            this.OriginFriendIDLabel.AutoSize = true;
            this.OriginFriendIDLabel.Location = new System.Drawing.Point(194, 14);
            this.OriginFriendIDLabel.Name = "OriginFriendIDLabel";
            this.OriginFriendIDLabel.Size = new System.Drawing.Size(53, 12);
            this.OriginFriendIDLabel.TabIndex = 4;
            this.OriginFriendIDLabel.Text = "根好友ID";
            // 
            // AcceptButton
            // 
            this.AcceptButton.Location = new System.Drawing.Point(354, 9);
            this.AcceptButton.Name = "AcceptButton";
            this.AcceptButton.Size = new System.Drawing.Size(75, 23);
            this.AcceptButton.TabIndex = 5;
            this.AcceptButton.Text = "确认";
            this.AcceptButton.UseVisualStyleBackColor = true;
            this.AcceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.RootFriendID,
            this.RootFriendName,
            this.ChildFriendID,
            this.ChildFriendName,
            this.Statue,
            this.AddTimes});
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(13, 93);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(562, 155);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // RootFriendID
            // 
            this.RootFriendID.Text = "根好友ID";
            this.RootFriendID.Width = 64;
            // 
            // RootFriendName
            // 
            this.RootFriendName.Text = "根好友姓名";
            this.RootFriendName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RootFriendName.Width = 78;
            // 
            // ChildFriendID
            // 
            this.ChildFriendID.Text = "子好友ID";
            this.ChildFriendID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ChildFriendID.Width = 69;
            // 
            // ChildFriendName
            // 
            this.ChildFriendName.Text = "子好友姓名";
            this.ChildFriendName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ChildFriendName.Width = 90;
            // 
            // Statue
            // 
            this.Statue.Text = "添加状态";
            this.Statue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Statue.Width = 83;
            // 
            // AddTimes
            // 
            this.AddTimes.Text = "添加次数";
            this.AddTimes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AddTimes.Width = 73;
            // 
            // ChildFriendIDTextBox
            // 
            this.ChildFriendIDTextBox.Location = new System.Drawing.Point(248, 11);
            this.ChildFriendIDTextBox.Name = "ChildFriendIDTextBox";
            this.ChildFriendIDTextBox.Size = new System.Drawing.Size(100, 21);
            this.ChildFriendIDTextBox.TabIndex = 7;
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(513, 9);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 8;
            this.stopButton.Text = "停止";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // continueButton
            // 
            this.continueButton.Location = new System.Drawing.Point(435, 9);
            this.continueButton.Name = "continueButton";
            this.continueButton.Size = new System.Drawing.Size(75, 23);
            this.continueButton.TabIndex = 9;
            this.continueButton.Text = "继续";
            this.continueButton.UseVisualStyleBackColor = true;
            this.continueButton.Click += new System.EventHandler(this.continueButton_Click);
            // 
            // goonButton
            // 
            this.goonButton.Location = new System.Drawing.Point(435, 38);
            this.goonButton.Name = "goonButton";
            this.goonButton.Size = new System.Drawing.Size(75, 23);
            this.goonButton.TabIndex = 10;
            this.goonButton.Text = "继续上次";
            this.goonButton.UseVisualStyleBackColor = true;
            this.goonButton.Click += new System.EventHandler(this.goonButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.MyfriendTabPage);
            this.tabControl1.Controls.Add(this.AddFriendTabPage);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(599, 343);
            this.tabControl1.TabIndex = 11;
            // 
            // MyfriendTabPage
            // 
            this.MyfriendTabPage.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.MyfriendTabPage.Controls.Add(this.button1);
            this.MyfriendTabPage.Controls.Add(this.LoadButton);
            this.MyfriendTabPage.Controls.Add(this.FriendCountLabel);
            this.MyfriendTabPage.Controls.Add(this.refreshButton);
            this.MyfriendTabPage.Controls.Add(this.progressBar1);
            this.MyfriendTabPage.Controls.Add(this.listView2);
            this.MyfriendTabPage.Location = new System.Drawing.Point(4, 22);
            this.MyfriendTabPage.Name = "MyfriendTabPage";
            this.MyfriendTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.MyfriendTabPage.Size = new System.Drawing.Size(591, 317);
            this.MyfriendTabPage.TabIndex = 0;
            this.MyfriendTabPage.Text = "已有好友";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(474, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(267, 15);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(75, 23);
            this.LoadButton.TabIndex = 4;
            this.LoadButton.Text = "载入";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // FriendCountLabel
            // 
            this.FriendCountLabel.AutoSize = true;
            this.FriendCountLabel.Location = new System.Drawing.Point(35, 15);
            this.FriendCountLabel.Name = "FriendCountLabel";
            this.FriendCountLabel.Size = new System.Drawing.Size(41, 12);
            this.FriendCountLabel.TabIndex = 3;
            this.FriendCountLabel.Text = "label1";
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(370, 15);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(75, 23);
            this.refreshButton.TabIndex = 2;
            this.refreshButton.Text = "刷新";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(6, 288);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(579, 23);
            this.progressBar1.TabIndex = 1;
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FriendID,
            this.FriendName});
            this.listView2.Location = new System.Drawing.Point(3, 44);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(582, 235);
            this.listView2.TabIndex = 0;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // FriendID
            // 
            this.FriendID.Text = "好友ID";
            this.FriendID.Width = 91;
            // 
            // FriendName
            // 
            this.FriendName.Text = "好友姓名";
            this.FriendName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.FriendName.Width = 103;
            // 
            // AddFriendTabPage
            // 
            this.AddFriendTabPage.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.AddFriendTabPage.Controls.Add(this.saveButton);
            this.AddFriendTabPage.Controls.Add(this.listView1);
            this.AddFriendTabPage.Controls.Add(this.ChildFriendIDTextBox);
            this.AddFriendTabPage.Controls.Add(this.goonButton);
            this.AddFriendTabPage.Controls.Add(this.NewFriendCountLabel);
            this.AddFriendTabPage.Controls.Add(this.continueButton);
            this.AddFriendTabPage.Controls.Add(this.NewFriendCountTextBox);
            this.AddFriendTabPage.Controls.Add(this.stopButton);
            this.AddFriendTabPage.Controls.Add(this.OriginFriendIDLabel);
            this.AddFriendTabPage.Controls.Add(this.AcceptButton);
            this.AddFriendTabPage.Location = new System.Drawing.Point(4, 22);
            this.AddFriendTabPage.Name = "AddFriendTabPage";
            this.AddFriendTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.AddFriendTabPage.Size = new System.Drawing.Size(591, 317);
            this.AddFriendTabPage.TabIndex = 1;
            this.AddFriendTabPage.Text = "添加好友";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(354, 38);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 11;
            this.saveButton.Text = "保存";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // AddFriendForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 367);
            this.Controls.Add(this.tabControl1);
            this.Name = "AddFriendForm";
            this.Text = "添加好友";
            this.tabControl1.ResumeLayout(false);
            this.MyfriendTabPage.ResumeLayout(false);
            this.MyfriendTabPage.PerformLayout();
            this.AddFriendTabPage.ResumeLayout(false);
            this.AddFriendTabPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label NewFriendCountLabel;
        private System.Windows.Forms.TextBox NewFriendCountTextBox;
        private System.Windows.Forms.Label OriginFriendIDLabel;
        private System.Windows.Forms.Button AcceptButton;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader RootFriendID;
        private System.Windows.Forms.ColumnHeader RootFriendName;
        private System.Windows.Forms.ColumnHeader ChildFriendID;
        private System.Windows.Forms.ColumnHeader ChildFriendName;
        private System.Windows.Forms.ColumnHeader Statue;
        private System.Windows.Forms.TextBox ChildFriendIDTextBox;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button continueButton;
        private System.Windows.Forms.Button goonButton;
        private System.Windows.Forms.ColumnHeader AddTimes;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage MyfriendTabPage;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader FriendID;
        private System.Windows.Forms.ColumnHeader FriendName;
        private System.Windows.Forms.TabPage AddFriendTabPage;
        private System.Windows.Forms.Label FriendCountLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.Button button1;
    }
}