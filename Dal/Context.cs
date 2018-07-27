using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Dal
{
    public class Context:DbContext
    {
        public Context() : base(GetConnStr())
        {

            //((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 300;//设置超时时间(未测试)

            //Database.SetInitializer(new Initializer());//执行这名就会执行初始化器
            //Database.SetInitializer<Context>(new DropCreateDatabaseIfModelChanges<Context>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            //生成的数据库表的名称和定义的Model的名称将保持一致。
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new GradeMap());
            modelBuilder.Configurations.Add(new PersonMap());
            modelBuilder.Configurations.Add(new SubjectMap());
          



        }


        #region 生成表的部分

        public virtual DbSet<Grade> grade { get; set; }
        public virtual DbSet<Person> person { get; set; }
        public virtual DbSet<Subject> subject { get; set; }
        


        #endregion


        #region 解密后得到连接字符串
        /// <summary>
        /// 得到解密后的连接字符串
        /// </summary>
        /// <returns>返回解密后的连接字符串</returns>
        private static string GetConnStr()
        {



            //Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ////根据Key读取<connectionString>元素的Value
            //string name = config.AppSettings.Settings["connectionString"].Value;

            //string name=ConfigurationSettings.AppSettings["connectionString"];
            
            string name = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
            string connstr = Helper.DEncrypt.Security.DecryptDES(name);

            return connstr;

        }
        #endregion


    }
}
