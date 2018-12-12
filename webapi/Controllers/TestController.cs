using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static webapi.Fun;

namespace webapi.Controllers
{
    public class TestController : ApiController
    {

        private ApiTools tool = new ApiTools();


        [HttpPost]
        public HttpResponseMessage CheckName(string userName)
        {
            string _username="";

            _username = "aaa";


            if (userName==_username)
            {
                return tool.MsgFormat(ResponseCode.操作失败, "不可注册/用户已注册", "1 " + userName);
            }
            else
            {
                return tool.MsgFormat(ResponseCode.成功, "可注册", "0 " + userName);
            }

        }

        [HttpGet]
        public string GetName()
        {
            return "all name";
        }

        [HttpGet]
        public string GetName(string id)
        {
            return string.Format("GetName id:{0}\r\n", id);
        }

        [HttpGet]
        public string GetID()
        {
            return "all id";
        }


        [HttpGet]
        public string GetId(string id)
        {
            return string.Format("Getid id:{0}\r\n", id);
        }


        [HttpGet]
        public string GetALl(string id, string name)
        {
            return "Get OK";
        }


        [HttpPost]
        public string PostAll(string id, string name)
        {
            return "Post OK";
        }


        //Get,Post都可以调用
        [AcceptVerbs("Get", "Post")]
        public string GetPostAll(string id, string name)
        {
            return "GetPost Ok";
        }


    }
}
