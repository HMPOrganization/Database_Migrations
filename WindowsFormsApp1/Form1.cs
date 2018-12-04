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

            //this.dataGridView1.DataSource = person_List.ConvertToDataTable();
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

        private void button6_Click(object sender, EventArgs e)
        {
            Person person = new Person();
            Person person1 = new Person();
            Person person2 = new Person();

            List<Person> person_list = new List<Person>();

            Person_Bll person_bll = new Person_Bll();

            try
            {





                person.person_name = "new name";
                person.person_no = "new id2";
                person.class_no = "1";
                person.Input_date1 = DateTime.Now;
                person.Input_date2 = DateTime.Now;
                person.sex = Model.Enum.Enum.Sex.man;



                person_list.Add(person);

                person1.person_name = "new name";
                person1.person_no = "new id1";
                person1.class_no = "1";
                person1.Input_date1 = DateTime.Now;
                person1.Input_date2 = DateTime.Now;
                person1.sex = Model.Enum.Enum.Sex.man;
                person_list.Add(person1);

                person_bll.Add(person_list);




                person2.person_name = "new name";
                person2.person_no = "new id";
                person2.class_no = "2";
                person2.Input_date1 = DateTime.Parse("2018-1-1");
                person2.Input_date2 = DateTime.Parse ("2018-1-1");
                person2.sex = Model.Enum.Enum.Sex.woman;
                person_bll.Mod(person2);




                //person_list = person_bll.GetPerson();

                //person_list.RemoveAt(2);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }






        }

        private void button7_Click(object sender, EventArgs e)
        {
            Person person = new Person();
            
            List<Person> person_list = new List<Person>();

            Person_Bll person_bll = new Person_Bll();


            person_list = person_bll.GetPerson();

            DataTable dt = (from pl in person_list
                       select new { pl.person_no, pl.person_name, pl.class_no, pl.grade.class_name }).ToList().ConvertToDataTable();


            this.exDataGridView1.DataSource = dt;
            this.exDataGridView1.Columns.Clear();
            this.exDataGridView1.AddColumn("class_no", "班级编号", IFReadOnly: false);
            this.exDataGridView1.AddColumn("class_name", "班级名称", IFReadOnly: false);
            this.exDataGridView1.AddColumn("person_no", "人员编号", IFReadOnly: false);
            this.exDataGridView1.AddColumn("person_name", "人员名称", IFReadOnly: false); 
            dt.AcceptChanges();
            
        }

        private void button8_Click(object sender, EventArgs e)
        {

            //Person_Bll person_bll = new Person_Bll();

            DataTable dt1 =((DataTable) this.exDataGridView1.DataSource).GetChanges(DataRowState.Added);
            DataTable dt2 = ((DataTable)this.exDataGridView1.DataSource).GetChanges(DataRowState.Modified);
            DataTable dt3 = ((DataTable)this.exDataGridView1.DataSource).GetChanges(DataRowState.Deleted);


            //List<Person> person_list = (from a in dt2.AsEnumerable()
            //                    select new Person { class_no = a.Field<string>("class_no"), person_no = a.Field<string>("person_no"),
            //                                person_name = a.Field<string>("person_name"),Input_date1=DateTime.Now,
            //                                sex= Model.Enum.Enum.Sex.man
            //                    }).ToList<Person>();

            //person_bll.Mod<Person>(person_list);
            
            

            DataView dv = new DataView(((DataTable)this.exDataGridView1.DataSource), "", "", DataViewRowState.Deleted);

            DataTable dt4 = dv.ToTable(true);

            //Console.WriteLine(dt3.Rows[0]["person_no", DataRowVersion.Original]);
                
            ((DataTable)this.exDataGridView1.DataSource).AcceptChanges();

           
            




            

            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
            DataTable dt = (DataTable)this.exDataGridView1.DataSource;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i].RowState== DataRowState.Modified)
                {
                    Console.WriteLine("modi");
                }
            }

            
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.exDataGridView1.Rows.RemoveAt(0);
        }

        private void 增加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
    

            DataRow newRow;
            newRow = ((DataTable)this.exDataGridView1.DataSource).NewRow();
            newRow["class_no"] = "1";
            newRow["class_name"] = "新班";
            newRow["person_no"] = "999";
            newRow["person_name"] = "新人";

            ((DataTable)this.exDataGridView1.DataSource).Rows.Add(newRow);


        }

        private void button10_Click(object sender, EventArgs e)
        {
            Person_Bll person_bll = new Person_Bll();

            string[] a = new[] { "person_name" };

            person_bll.person_save(this.exDataGridView1,a);

        }
    }
}
