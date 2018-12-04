using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;


using System.Data;
using System.Data.Entity.Infrastructure;

namespace Dal
{
    public class Base_Dal
    {
        protected internal Context db;

        public Base_Dal()
        {
            db = new Context();
            db.Database.Log = Console.WriteLine;
        }

        public Base_Dal(Base_Dal bd)
        {
            db = bd.db;
            
        }


        /// <summary>
        /// 增加一个对象
        /// </summary>
        /// <typeparam name="T">要增加的类名</typeparam>
        /// <param name="model">传入要增加的类</param>
        /// <returns></returns>
        public Boolean Add <T>( T model)where T:class
        {

            try
            {

                db.Entry(model).State = System.Data.Entity.EntityState.Added;
                return true;
            }

            catch (Exception ex)
            {
                //ex.InnerException.Message();
                Exception exnew = new Exception();
                exnew = ex;

                while (!IsNull(exnew.InnerException))
                {
                    exnew = exnew.InnerException;
                }

                throw new Exception(exnew.Message);

            }
        }



        /// <summary>
        /// 修改一个对象
        /// </summary>
        /// <typeparam name="T">要修改对象的类型</typeparam>
        /// <param name="model">传入要修改的类</param>
        /// <returns></returns>
        public Boolean Mod<T>(T model) where T : class
        {
            

            try
            {

                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                return true;
            }

            catch (Exception ex)
            {
                //ex.InnerException.Message();
                Exception exnew = new Exception();
                exnew = ex;

                while (!IsNull(exnew.InnerException))
                {
                    exnew = exnew.InnerException;
                }

                throw new Exception(exnew.Message);

            }

        }

        /// <summary>
        /// 删除一个对象
        /// </summary>
        /// <typeparam name="T">要删除对象的类型</typeparam>
        /// <param name="model">传入要删除的类</param>
        /// <returns></returns>
        public Boolean Del<T>(T model) where T : class
        {
            


            try
            {
                
                db.Entry(model).State = System.Data.Entity.EntityState.Deleted;
                return true;
            }

            catch (Exception ex)
            {
                //ex.InnerException.Message();
                Exception exnew = new Exception();
                exnew = ex;

                while (!IsNull(exnew.InnerException))
                {
                    exnew = exnew.InnerException;
                }

                throw new Exception(exnew.Message);

            }

        }




        /// <summary>
        /// 要按字段修改类
        /// </summary>
        /// <typeparam name="T">要修改类的类型</typeparam>
        /// <param name="model">传入要修改的类</param>
        /// <param name="proName">要修改的字段名称的数组</param>
        /// <returns></returns>
        public Boolean Modify<T>(T model, params string[] proName) where T:class
        {
            try
            {
                DbEntityEntry<T> entityentry = db.Entry<T>(model);
                entityentry.State = System.Data.Entity.EntityState.Unchanged;

                foreach (string s in proName)
                {
                    entityentry.Property(s).IsModified = true;
                }

                
                return true;
            }

            catch (Exception ex)
            {
                //ex.InnerException.Message();
                Exception exnew = new Exception();
                exnew = ex;

                while (!IsNull(exnew.InnerException))
                {
                    exnew = exnew.InnerException;
                }

                throw new Exception(exnew.Message);

            }
        }


        /// <summary>
        /// 提交更改
        /// </summary>
        public void Dal_save()
        {

            try
            {

                db.SaveChanges();
            }

            catch (Exception ex)
            {
                //ex.InnerException.Message();
                Exception exnew = new Exception();
                exnew = ex;

                while (!IsNull(exnew.InnerException))
                {
                    exnew = exnew.InnerException;
                }

                throw new Exception(exnew.Message);

            }
        }




        /// <summary>
        /// 判断对象是否为空
        /// </summary>
        /// <typeparam name="T">需要判断的对象类型</typeparam>
        /// <param name="mm">需要判断的对象<
        /// /param>
        /// <returns></returns>
        private bool IsNull<T>(T mm)
        {
            if (mm == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
