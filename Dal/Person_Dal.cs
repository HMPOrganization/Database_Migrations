﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Dal
{
   public class Person_Dal: Base_Dal
    {
        public Person_Dal(Base_Dal BD) : base(BD)
        {
        }


        /// <summary>
        /// 得到满足条件的Person对象
        /// </summary>
        ///<param name="person_no">人员编号</param>
        /// <returns>Person对象</returns>
        public Person GetPerson(string person_no)
        {
            List<Person> person_list = new List<Person>();


            //person_list = db.person.Where(a => a.person_no==person_no).Select(a => a).ToList();

            //if (person_list.Count > 0)
            //{
            //    return person_list[0];
            //}
            //else
            //{
            //    return null;
            //}
            SqlParameter P0 = new SqlParameter("person_no", person_no);
            return db.person.SqlQuery("select * from person where person_no=@person_no", P0).First();

        }


        /// <summary>
        /// 得到所有Person对象集合
        /// </summary>
        /// <returns>Person对象的list</returns>
        public List<Person> GetPerson()
        {



            List<Person> person_list = new List<Person>();


            person_list = db.person.ToList();

            if (person_list.Count > 0)
            {
                return person_list;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到生成的SQL
        /// </summary>
        public void getSQL()
        {
            var person_List = from p in db.person
                            where p.id <= 100
                            select new { p.id,p.class_no,p.person_name};

            IEnumerable<Person> Iperson = from p in db.person
                                          join G in db.subject
                                          on p.class_no equals G.subject_no
                                           into x
                                          from G in x.DefaultIfEmpty()
                                          //where G.id < 100
                                          select p;

            string sql;
            sql = person_List.ToString();
            Console.WriteLine("SQL iS ({0})",sql);


            //匿名类也可以用点点出来 
            foreach (var item in person_List)
            {
                
                Console.WriteLine(item.id);
                Console.WriteLine(item.class_no);
                Console.WriteLine(item.person_name);
            }

            var k = from pl in person_List
                    where pl.id < 15
                    select pl;

            sql = Iperson.ToString();
            Console.WriteLine(sql);


        }

        ///// <summary>
        ///// 附加数据
        ///// </summary>
        ///// <param name="person"></param>
        //public void AttachPerson(Person person,System.Data.Entity.EntityState state)
        //{
        //    db.Entry(person).State = state;
        //    db.SaveChanges();

        //}

        ///// <summary>
        ///// 保存
        ///// </summary>
        //public void Dal_Save()
        //{
           
        //    try
        //    {

        //        db.SaveChanges();
        //    }
          
        //    catch (Exception ex)
        //    {
        //        //ex.InnerException.Message();
        //        Exception exnew = new Exception();
        //        exnew = ex;

        //        while (!IsNull(exnew.InnerException))
        //        {
        //            exnew = exnew.InnerException;
        //        }

        //        throw new Exception(exnew.Message);
                
        //    }
         
            
            



        //}

        //private bool IsNull<T>(T mm)
        //{
        //    if (mm == null)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

    }
}
