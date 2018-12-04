using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using MimeKit;

namespace IMAP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            ImapClient client = new ImapClient();
            string account = "yuqing_zhou@highrock.com.cn";
            string passWord = "SGgMEmJzWq5fnbHT";


            client.Connect("imap.qiye.163.com", 993, true);
            //client.Authenticate("HRRDS@highrock.com.cn", "TNL7EtuUVJ5mRNcw");

            client.Authenticate(account, passWord);

            IMailFolder inbox = client.Inbox;
            inbox.Open(FolderAccess.ReadWrite);


            IList<UniqueId> mail_list = inbox.Search(SearchQuery.New);

            foreach (UniqueId item in mail_list)
            {
                //得到邮件的内容
                MimeMessage message = inbox.GetMessage(item);

                foreach (MimeEntity attachment in message.Attachments)
                {
                    MimePart mime = (MimePart)attachment;

                    Console.WriteLine(mime.FileName);
                    string fileName = mime.FileName;
                    if (mime.FileName.Contains(".xls"))
                    {
                        try
                        {
                            using (FileStream stream = File.Create(fileName))
                            {
                                
                                mime.Content.DecodeTo(stream);
                            }
                        }
                        catch
                        {
                            continue;
                        }

                    }

                    // client.Inbox.SetFlags(item, MessageFlags.Seen,false);
                }
            }
            
        }
    }
}
