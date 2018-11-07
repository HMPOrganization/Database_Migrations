﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Model;



namespace Database_Migrations
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Trim().ToString().Length != 0)
            {
                this.textBox1.Text = Helper.DEncrypt.Security.EncryptDES(this.textBox1.Text.Trim());
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Trim().ToString().Length != 0)
            {
                this.textBox1.Text = Helper.DEncrypt.Security.DecryptDES(this.textBox1.Text.Trim());
            }

            
        }

        private void button3_Click(object sender, EventArgs e)
        {

            //此工程仅用于升迁测试使用
            //迁升时使用另一个项目的连接来进行迁升（第一次建立文件时才使用）
            //Enable-Migrations -ContextProjectName Dal

            //生成迁升文件
            //add-Migration -name aa

            //执行数据库迁升
            //Update-Database  -Verbose


            //前面加get-help可以显示帮助
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
