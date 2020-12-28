using Model.Return;
using Model.Enum;
using MySQLSrv;
using Trade.Interface;
using RedisSrv;
using System.ServiceModel.Activation;
using Common;
using System.Collections.Generic;
using System.Configuration;
using Trade.Biz;
using System.Linq;
using System;
using Model.DB;
using Version = Model.DB.Version;

namespace Trade.Service
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Utility : Service, IUtility
    {
        public ResultLogin Login(Model.DB.User model)
        {
            ApiResultEnum result = UserDA.Login(ref model, platform);
            if (result == ApiResultEnum.Success)
            {
                string user_token = UserRA.Get(model.id.ToString(), "platform_" + platform);
                if (string.IsNullOrWhiteSpace(user_token))
                {
                    user_token = FuncHelper.GetUniqueString();
                    Dictionary<string, string> dic = new Dictionary<string, string>();
                    dic.Add("platform_" + platform, user_token);
                    dic.Add("name", model.name);
                    dic.Add("status_order", model.status_order.ToString());
                    dic.Add("role", model.role.ToString());
                    dic.Add("login_time_" + platform, DateTime.Now.Format());
                    UserRA.Set(model.id.ToString(), dic);
                    UserRA.SetExpire(model.id.ToString());
                }
                return new ResultLogin(result, model, model.id + "-" + user_token);
            }
            else
            {
                return new ResultLogin(result, null, null);
            }
        }

        public Result<Version> Version(int current_version)
        {
            Version version = new Version()
            {
                version = Config.client_version,
                version_no = Config.client_version_no
            };
            if (current_version >= Config.client_version)
                return Result(ApiResultEnum.LatestVersion, version);
            else
                return Result(ApiResultEnum.Success, version);
        }

        public Result<VersionFiles> VersionFiles(int current_version)
        {
            VersionFiles version = new VersionFiles()
            {
                version = Config.client_version,
                version_no = Config.client_version_no
            };
            if (current_version >= Config.client_version)
                return Result(ApiResultEnum.LatestVersion, version);

            version.files = ClientFileDA.List(current_version);
            version.total_file_count = version.files.Count;
            version.total_size = version.files.Sum(f => f.size);
            return Result(ApiResultEnum.Success, version);
        }

        public Result Close(string token)
        {
            if (token != ConfigurationManager.AppSettings["CloseToken"])
                return Result(ApiResultEnum.InvalidRequest);

            int status_trade = MonitorRA.GetStatusTrade();
            UserRA.FlushDatabase(new List<int>() { 7, 8, (int)DateTime.Now.AddDays(1).DayOfWeek });
            if (status_trade != 0)
            {
                if (LogTradeDA.Close("系统"))
                {
                    MonitorRA.SetStatusTrade((int)StatusTradeEnum.Closed);
                    OpenCloseBiz.Close();
                    NLog.Info("系统自动收盘");
                    return Result(ApiResultEnum.Success);
                }
            }
            return Result(ApiResultEnum.Order_Closed);
        }

        public Result LoadConfig(string token)
        {
            if (token != ConfigurationManager.AppSettings["CloseToken"])
                return Result(ApiResultEnum.InvalidRequest);

            Config.Init();
            return Result(ApiResultEnum.Success);
        }
    }
}