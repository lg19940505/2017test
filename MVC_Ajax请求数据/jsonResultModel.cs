using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Ajax请求数据
{
    public class JsonResultModel<T>
    {
        private JsonResultModel() { }

        public JsonResultModel(bool _success, string _msg, T _data)
        {
            success = _success;
            msg = _msg;
            data = _data;
        }

        public bool success { get; set; }

        public int errorcode { get; set; }

        public string msg { get; set; }

        public T data { get; set; }


        public static JsonResultModel<T> ReturnSuccess(T data, string msg = "")
        {
            return new JsonResultModel<T>()
            {
                success = true,
                msg = msg,
                data = data
            };
        }


        public static JsonResultModel<string> ReturnStringResult(string data)
        {
            return new JsonResultModel<string>()
            {
                success = data == string.Empty,
                msg = data,
                data = data
            };
        }


        public static JsonResultModel<T> ReturnNoPermission()
        {
            return new JsonResultModel<T>()
            {
                msg = ApiErrorCode.权限不足.ToString(),
                errorcode = (int)ApiErrorCode.权限不足
            };
        }



        public static JsonResultModel<T> ReturnFailure(string msg, int errorcode = 0)
        {
            return new JsonResultModel<T>()
            {
                success = false,
                msg = msg,
                errorcode = errorcode
            };
        }

        public static JsonResultModel<T> ReturnAuthorizeFailure()
        {
            return new JsonResultModel<T>()
            {
                msg = ApiErrorCode.验证用户失败.ToString(),
                errorcode = (int)ApiErrorCode.验证用户失败
            };
        }
    }

    public enum ApiErrorCode
    {
        验证用户失败 = 401,
        权限不足 = 402
    }
}