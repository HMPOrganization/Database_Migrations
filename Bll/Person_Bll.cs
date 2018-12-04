using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Dal;
using System.Windows.Forms;
using System.Data;

namespace Bll
{
    public class Person_Bll : Base_Bll
    {
        private Person_Dal person_dal;

        public Person_Bll()
        {
            person_dal = new Person_Dal(base.base_dal);
            

        }

        /// <summary>
        /// 得到满足条件的Person对象
        /// </summary>
        /// <param name="person_no">人员编号</param>
        /// <returns>Person对象</returns>
        public Person GetPerson(string person_no)
        {
            //Person person = new Person();
            //person.person_no


            return person_dal.GetPerson(person_no);

            
            
        }


        /// <summary>
        /// 得到满足条件的Person集合对象
        /// </summary>
        /// <param name="person_no">人员编号</param>
        /// <returns>Person对象</returns>
        public List<Person> GetPerson()
        {
            //Person person = new Person();
            //person.person_no


            return person_dal.GetPerson();
        }

        /// <summary>
        /// 得到生成的SQL
        /// </summary>
        public void GetSQL()
        {
            person_dal.getSQL();
        }

        ///// <summary>
        ///// 更新对象
        ///// </summary>
        ///// <param name="person"></param>
        //public void AttachPerson(Person person)
        //{
        //    person_dal.AttachPerson(person,System.Data.Entity.EntityState.Modified);
        //}


        //public void AddPerson(Person person)
        //{
        //    person_dal.AttachPerson(person, System.Data.Entity.EntityState.Added);
        //}

        public void person_save(DataGridView Dgv)
        {


            DataTable dt1 = ((DataTable)Dgv.DataSource).GetChanges(DataRowState.Added);
            DataTable dt2 = ((DataTable)Dgv.DataSource).GetChanges(DataRowState.Modified);
            DataTable dt3 = ((DataTable)Dgv.DataSource).GetChanges(DataRowState.Deleted);

            List<Person> person_list = (from a in dt2.AsEnumerable()
                                        select new Person
                                        {
                                            class_no = a.Field<string>("class_no"),
                                            person_no = a.Field<string>("person_no"),
                                            person_name = a.Field<string>("person_name"),
                                            //Input_date1 = DateTime.Parse("2018-11-09"),
                                            //Input_date2= DateTime.Parse("2018-11-09"),
                                            //sex = Model.Enum.Enum.Sex.man
                                            Input_date1 =a.Field<DateTime>("Input_date1"),
                                            Input_date2 = a.Field<DateTime>("Input_date1"),
                                            sex = a.Field<Model.Enum.Enum.Sex>("Sex")
                                        }).ToList<Person>();

            base.Mod<Person>(person_list);

            person_dal.Dal_save();
        }


        public void person_save(DataGridView Dgv,params string [] proName)
        {


            DataTable dt1 = ((DataTable)Dgv.DataSource).GetChanges(DataRowState.Added);
            DataTable dt2 = ((DataTable)Dgv.DataSource).GetChanges(DataRowState.Modified);
            DataTable dt3 = ((DataTable)Dgv.DataSource).GetChanges(DataRowState.Deleted);

            List<Person> person_list = (from a in dt2.AsEnumerable()
                                        select new Person
                                        {
                                            class_no = a.Field<string>("class_no"),
                                            person_no = a.Field<string>("person_no"),
                                            person_name = a.Field<string>("person_name")
                                            //Input_date1 = DateTime.Parse("2018-11-09"),
                                            //Input_date2= DateTime.Parse("2018-11-09"),
                                            //sex = Model.Enum.Enum.Sex.man

                                        }).ToList<Person>();

            List<Grade> grade_list = (from b in dt2.AsEnumerable()
                                      select new Grade
                                      {
                                          class_no = b.Field<string>("class_no"),
                                          class_name = b.Field<string>("class_name")
                                      }).ToList<Grade>();

            //base.Mod<Person>(person_list);



             string[] aa = new[] { "class_name" };
            base.Modify<Person>(person_list[0],proName);
            base.Modify<Grade>(grade_list[0], aa);

            person_dal.Dal_save();
        }




    }
}



