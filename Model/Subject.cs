﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 学科类
    /// </summary>
    public class Subject
    {

        public Subject()
        {
            person = new HashSet<Person>();
        }
















        #region 字段信息

        /// <summary>
        public int id { get; set; }


        

     


        


        /// <summary>
        public string subject_no { get; set; }


        

        /// <summary>
        public string subject_name { get; set; }





        #endregion

        #region 扩展信息





        /// <summary>
        /// 学科信息
        /// </summary>
        public virtual ICollection<Person> person { get; set; }

        #endregion
    }


    public class SubjectMap : EntityTypeConfiguration<Subject>
    {
        public SubjectMap()
        {
            //定义主键
            this.HasKey(t => new { t.subject_no });


           

        }
    }
}