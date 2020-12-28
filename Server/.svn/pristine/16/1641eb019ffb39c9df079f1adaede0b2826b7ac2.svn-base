using Model.Return;
using Model.Enum;
using System;
using System.Net;
using System.Runtime.Serialization.Json;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace Trade.Code
{
    public class ApiException : Exception
    {
        public ApiResultEnum Code { get; set; }

        public ApiException(ApiResultEnum code, string message) : base(message)
        {
            Code = code;
        }
    }


    public class GlobalErrorHandle : IErrorHandler
    {
        public bool HandleError(Exception error)
        {
            return true;
        }

        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            Result model;
            if (error.GetType() == typeof(ApiException))
            {
                ApiException apiException = error as ApiException;
                model = new Result(apiException.Code, error.Message);
            }
            else
            {
                model = new Result(ApiResultEnum.UncaughtException, error.Message);
            }

            //添加将要返回的异常信息
            fault = Message.CreateMessage(version, "", model, new DataContractJsonSerializer(typeof(Result)));

            //告诉WCF使用JSON编码而不是默认的XML
            WebBodyFormatMessageProperty wbf = new WebBodyFormatMessageProperty(WebContentFormat.Json);
            fault.Properties.Add(WebBodyFormatMessageProperty.Name, wbf);

            //修改响应
            HttpResponseMessageProperty rmp = new HttpResponseMessageProperty();
            rmp.StatusCode = HttpStatusCode.OK;
            rmp.Headers[HttpResponseHeader.ContentType] = "application/json";
            rmp.Headers[HttpResponseHeader.ContentEncoding] = "utf-8";
            fault.Properties.Add(HttpResponseMessageProperty.Name, rmp);
        }
    }
}