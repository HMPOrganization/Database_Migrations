using System;
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

        /// <summary>        /// 主键ID        /// </summary>        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //自增长列
        public int id { get; set; }


        

     


        


        /// <summary>        /// 学科编号        /// </summary>        [Required, MaxLength(50)]//必填项
        public string subject_no { get; set; }


        

        /// <summary>        /// 学科名称        /// </summary>        [MaxLength(50)]//必填项
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
