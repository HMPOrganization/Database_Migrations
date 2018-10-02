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
    ///  人员类
    /// </summary>
   public class Person
    {
        public Person()
        {
            subject = new HashSet<Subject>();
        }










        #region 字段信息

        /// <summary>
        /// 主键ID
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //自增长列
        public int id { get; set; }











        /// <summary>
        /// 班级编号
        /// </summary>
        [Required, MaxLength(50)]//必填项
        public string class_no { get; set; }










        /// <summary>
        /// 人员编号
        /// </summary>
        [Required, MaxLength(50)]//必填项
        public string person_no { get; set; }


        
        /// <summary>
        /// 人员名称
        /// </summary>
        [MaxLength(50)]//必填项
        public string person_name { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int age { get; set; }

        /// <summary>
        /// 入学时间
        /// </summary>
        public DateTime? enrollment_time { get; set; }


        /// <summary>
        /// memo
        /// </summary>
        [MaxLength(50)]//必填项
        public string memo { get; set; }

        /// <summary>
        /// memo
        /// </summary>
        [MaxLength(50)]//必填项
        public string memo2 { get; set; }

        #endregion

        #region 扩展信息


        /// <summary>
        /// 班级信息
        /// </summary>
        public virtual Grade grade { get; set; }


        /// <summary>
        /// 学科信息
        /// </summary>
        public virtual ICollection<Subject> subject { get; set; }

        #endregion
    }






    public class PersonMap : EntityTypeConfiguration<Person>
    {
        public PersonMap()
        {
            //定义主键
            this.HasKey(t => new {  t.person_no });


            //定义表之间的关系



            HasMany(d => d.subject)
                .WithMany(d => d.person)
                .Map(m =>
                {
                    m.MapLeftKey("person_no");
                    m.MapRightKey("subject_no");
                    m.ToTable("Person_Subject");

                });

        }
    }

}
