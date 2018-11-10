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
            Person_Bll person_Bll = new Person_Bll();
            person_Bll.GetPerson();



        }

        private void button3_Click(object sender, EventArgs e)
        {
            Person_Bll person_Bll = new Person_Bll();
            Person person = new Person();

           person=person_Bll.GetPerson("002");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Grade_Bll grade_Bll = new Grade_Bll();

            var cp=grade_Bll.GetClass_Person();



            List<Grade> grade_list = new List<Grade>();
            grade_list=grade_Bll.GetGrade();

            var a=grade_list.SelectMany(
                g => g.person.Select(
                    p => new { g.class_no, g.class_name, p.person_no, p.person_name }
                )).ToList();
            

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Person_Bll person_Bll = new Person_Bll();
            List<Person> person_List = new List<Person>();

            person_List = person_Bll.GetPerson();

            this.dataGridView1.DataSource = person_List;
            this.dataGridView1.Columns.Clear();
            
            DataGridViewTextBoxColumn obj1 = new DataGridViewTextBoxColumn();

            
            obj1.DataPropertyName = "person_no";
            obj1.HeaderText = "人员编号";
            obj1.Name = "person_no";

            obj1.Width = 80;

             Func<string, int> A = x => x.Length;
            int kkk = A("fdsa");



            Func<int, int, bool> B = (a, b) => a > b;

            bool kkk2 = B(10, 20);

            Func<Person, bool> C = x => x.id > 10;

            person_List.Where(x => x.id > 10 || x.person_name.Length>5);




            this.dataGridView1.Columns.AddRange(obj1);



            DataGridViewComboBoxColumn obj2 = new DataGridViewComboBoxColumn();


            obj2.DataPropertyName = "sex";
            obj2.HeaderText = "性别";
            obj2.Name = "sex";

            obj2.Width = 80;

            //obj2.DataSource = System.Enum.GetNames(typeof(Model.Enum.Enum.Sex));
            obj2.DataSource = System.Enum.GetValues(typeof(Model.Enum.Enum.Sex));
          //  obj2.ValueType = typeof(Model.Enum.Enum.Sex);

            //obj2.DataSource=Model.Enum.Enum.Sex


            Console.WriteLine(Enum.GetName(typeof(Model.Enum.Enum.Sex), 100));

            
            var aa = System.Enum.GetNames(typeof(Model.Enum.Enum.Sex));
            var bb = System.Enum.GetValues(typeof(Model.Enum.Enum.Sex));
            this.dataGridView1.Columns.AddRange(obj2);



        }

        //private void button6_Click(object sender, EventArgs e)
        //{
        //    Console.WriteLine(this.dataGridView1.Rows[0].Cells["sex"].Value.ToString());
        //}
    }
}
