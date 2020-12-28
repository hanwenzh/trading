using Model.Return;
using Model.Enum;
using System;
using System.ServiceModel.Web;

namespace Trade.Service
{
    public class Service
    {
        protected int user_id { get; set; }

        protected string user_token { get; set; }

        protected int platform { get; set; }

        public Service()
        {
            platform = int.Parse(WebOperationContext.Current.IncomingRequest.Headers["platform"]);
            string _token = WebOperationContext.Current.IncomingRequest.Headers["token"];
            if (!string.IsNullOrWhiteSpace(_token))
            {
                string[] _tokens = _token.Split('-');
                user_id = int.Parse(_tokens[0]);
                user_token = _tokens[1];
            }
        }

        protected Result Result(ApiResultEnum code)
        {
            return new Result(code, null);
        }

        protected Result Result(ApiResultEnum code, string data)
        {
            return new Result(code, data);
        }

        protected Result<T> Result<T>(T data)
        {
            return new Result<T>(ApiResultEnum.Success, data);
        }

        protected Result<T> Result<T>(ApiResultEnum code, T data)
        {
            return new Result<T>(code, data);
        }
    }
}