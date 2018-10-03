using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Dal;

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


    }
}



