using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dal;
namespace Bll
{
    public class Base_Bll
    {
        protected internal Base_Dal base_dal;

        public Base_Bll()
        {
            base_dal = new Base_Dal();
        }





        /// <summary>
        /// 增加一个对象到数据库
        /// </summary>
        /// <typeparam name="T">对象的类型</typeparam>
        /// <param name="model">要增加的对象</param>
        public void Add<T>(T model) where T : class
        {
            try
            {
                base_dal.Add<T>(model);
                //person_dal.Add<Person>(person);
                //person_dal.Dal_save();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// 增加一个对象的List到数据库
        /// </summary>
        /// <typeparam name="T">对象的类型</typeparam>
        /// <param name="model_list">要增加的对象集合</param>
        public void Add<T>(List<T> model_list) where T : class
        {
            try
            {
                foreach (T item in model_list)
                {
                    base_dal.Add<T>(item);
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }



        /// <summary>
        /// 修改一个数据库中已经存在的对象
        /// </summary>
        /// <typeparam name="T">对象的类型</typeparam>
        /// <param name="model">要修改的对象</param>
        public void Mod<T>(T model) where T : class
        {
            try
            {

                base_dal.Mod<T>(model);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }



        /// <summary>
        /// 修改一组数据库中已经存在的对象
        /// </summary>
        /// <typeparam name="T">对象的类型</typeparam>
        /// <param name="model_list">要修改的对象集合</param>
        public void Mod<T>(List<T> model_list) where T : class
        {
            try
            {
                foreach (T item in model_list)
                {
                    base_dal.Mod<T>(item);
                }


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 删除一个数据库中已经存在的对象
        /// </summary>
        /// <typeparam name="T">对象的类型</typeparam>
        /// <param name="model">要修改的对象</param>
        public void Del<T>(T model) where  T:class
        {
            try
            {

                base_dal.Del<T>(model);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 删除一组数据库中已经存在的对象
        /// </summary>
        /// <typeparam name="T">对象的类型</typeparam>
        /// <param name="model">要删除的对象集合</param>
        public void Del<T>(List<T> model_list) where T : class
        {
            try
            {
                foreach (T item in model_list)
                {
                    base_dal.Mod<T>(item);
                }


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// 修改某个模型中的某些列
        /// </summary>
        /// <typeparam name="T">对象的类型</typeparam>
        /// <param name="model">要修改的对象</param>
        /// <param name="proName">对象中要修改的列的数组</param>
        public void Modify<T>(T model, params string[] proName) where T:class
        {
            try
            {
                base_dal.Modify<T>(model, proName);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 修改某个模型的某些列
        /// </summary>
        /// <typeparam name="T">对象的类型</typeparam>
        /// <param name="model_list">要修改的对象</param>
        /// <param name="proName">对象中要修改的列的数组</param>
        public void Modify<T>(List<T> model_list, params string[] proName) where T:class
        {
            try
            {
                foreach (T item in model_list)
                {
                    base_dal.Modify<T>(item, proName);
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
