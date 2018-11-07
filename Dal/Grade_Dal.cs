using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Dal
{
    public class Grade_Dal:Base_Dal
    {

        //private class aa
        //{
        //    string class_no;
        //    string class_name;
        //    string person_no;
        //    string person_name;

        //}
        public Grade_Dal(Base_Dal BD) : base(BD)
        {
        }

        /// <summary>
        /// 得到班级与人名
        /// </summary>
        /// <returns>Person对象</returns>
        public object GetClass_Person()
        {

            var CP = db.grade.SelectMany(
                g => g.person.Select(
                    p => new { g.class_no, g.class_name, p.person_no, p.person_name }
                    )
                ).ToList();
            
            
            return CP;

            //person_list = db.person.Where(a => a.person_no==person_no).Select(a => a).ToList();

            //if (person_list.Count > 0)
            //{
            //    return person_list[0];
            //}
            //else
            //{
            //    return null;
            //}
         

        }

        /// <summary>
        /// 得到所有的年级数据
        /// </summary>
        /// <returns>返回grade的list</returns>
        public List<Grade> Get_Grade()
        {
            return db.grade.Select(a => a).ToList();
        }
    }
}
