using Bll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Person_Bll person_Bll = new Person_Bll();
            person_Bll.GetSQL();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Person> person = new List<Person>();

            Person_Bll person_Bll = new Person_Bll();
            person = person_Bll.GetPerson();


            var pp = person.SelectMany(
                p => p.subject.Select(
                    s => new { no = p.person_no, name = p.person_name, s_no = s.subject_no, s_name = s.subject_name }
                    )
                ).ToList() ;

        }
    }
}
