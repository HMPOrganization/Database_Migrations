using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Dal;

namespace Bll
{
    public class Grade_Bll:Base_Bll
    {
        private Grade_Dal grade_dal;

        public Grade_Bll()
        {
            grade_dal = new Grade_Dal(base.base_dal);


        }

        /// <summary>
        /// 得到班级与人名
        /// </summary>
        
        /// <returns></returns>
        public Object GetClass_Person()
        {

            //Grade grade = new Grade();

            return grade_dal.GetClass_Person();



        }


        /// <summary>
        /// 得到所有的年级数据
        /// </summary>
        /// <returns>返回grade的list</returns>
        public List<Grade> GetGrade()
        {
            return grade_dal.Get_Grade();
        }

    }
}
