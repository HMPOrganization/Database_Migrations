using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace webapi
{
    public class Fun
    {


        public enum ResponseCode
        {
            操作失败 = 00000,
            成功 = 10200,
        }
        public class ApiTools
        {
            private string msgModel = "{{\"code\":{0},\"message\":\"{1}\",\"result\":{2}}}";
            public ApiTools()
            {
            }
            public HttpResponseMessage MsgFormat(ResponseCode code, string explanation, string result)
            {
                string r = @"^(\-|\+)?\d+(\.\d+)?$";
                string json = string.Empty;
                if (System.Text.RegularExpressions.Regex.IsMatch(result, r) || result.ToLower() == "true" || result.ToLower() == "false" || result == "[]" || result.Contains('{'))
                {
                    json = string.Format(msgModel, (int)code, explanation, result);
                }
                else
                {
                    if (result.Contains('"'))
                    {
                        json = string.Format(msgModel, (int)code, explanation, result);
                    }
                    else
                    {
                        json = string.Format(msgModel, (int)code, explanation, "\"" + result + "\"");
                    }
                }
                return new HttpResponseMessage { Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json") };
            }
        }
    }
}