using Model;
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
    /// 班级类
    /// </summary>
    public class Grade
    {

        public Grade()
        {
             person = new HashSet<Person>();
        }
    
        


        #region 字段信息

        /// <summary>        /// 主键ID        /// </summary>            [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //自增长列
        public int id { get; set; }


        

        /// <summary>        /// 班级编号        /// </summary>        [Required, MaxLength(50)]//必填项
        public string class_no { get; set; }








        /// <summary>        /// 班级名称        /// </summary>        [MaxLength(50)]//必填项
        public string class_name { get; set; }

     



        #endregion

        #region 扩展信息



        /// <summary>
        /// 人员信息类
        /// </summary>
        public virtual ICollection<Person> person { get; set; }

        #endregion
    }


    public class GradeMap : EntityTypeConfiguration<Grade>
    {
        public GradeMap()
        {
            //定义主键
            this.HasKey(t => new { t.class_no });



            //定义表之间的关系
            HasMany(d => d.person)
            .WithRequired(d => d.grade)
            .HasForeignKey(m => new { m.class_no }).WillCascadeOnDelete(false);




        }
    }
}
