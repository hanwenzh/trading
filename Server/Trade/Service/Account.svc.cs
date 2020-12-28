using Model.Return;
using Model.Common;
using Model.Enum;
using MySQLSrv;
using Trade.Interface;
using System;
using System.Collections.Generic;
using System.ServiceModel.Activation;
using Trade.Biz;
using RedisSrv;
using System.Linq;
using Base = Model.Common.Base;

namespace Trade.Service
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Account : Service, IAccount
    {
        public Result<List<Model.DB.Account>> List()
        {
            UserRoleEnum role = (UserRoleEnum)int.Parse(UserRA.Get(user_id.ToString(), "role"));
            List<Model.DB.Account> lst = AccountDA.List<Model.DB.Account>(role == UserRoleEnum.Administrator ? 0 : user_id);
            return Result(lst);
        }

        public Result<List<Base>> List4Filter()
        {
            UserRoleEnum role = (UserRoleEnum)int.Parse(UserRA.Get(user_id.ToString(), "role"));
            List<Base> lst = AccountDA.List<Base>(role == UserRoleEnum.Administrator ? 0 : user_id);
            return Result(lst);
        }

        public Result<List<Base>> List4Unit(int unit_id)
        {
            List<Base> lst = AccountDA.List4Unit(unit_id);
            return Result(lst);
        }

        public Result<int> Add(Model.DB.Account model)
        {
            int id = 0;
            model.created_by = user_id;
            ApiResultEnum result = AccountDA.Add(model, ref id);
            if (result == ApiResultEnum.Success && MonitorRA.GetStatusTrade() != 0)
            {
                model.id = id;
                OpenCloseBiz.LoadAccount(model);
            }
            return Result(result, id);
        }

        public Result Update(Model.DB.Account model)
        {
            model.created_by = user_id;
            ApiResultEnum result = AccountDA.Update(model);
            if (result == ApiResultEnum.Success && MonitorRA.GetStatusTrade() != 0)
                OpenCloseBiz.LoadAccount(model, false);
            return Result(result);
        }

        public Result UpdateStatus(Status model)
        {
            ApiResultEnum result = AccountDA.UpdateStatus(model);
            if (result == ApiResultEnum.Success && MonitorRA.GetStatusTrade() != 0)
                AccountRA.UpdateStatus(model.status, "A_" + model.id);
            return Result(result);
        }

        public Result UpdateStatusOrder(StatusOrder model)
        {
            ApiResultEnum result = AccountDA.UpdateStatusOrder(model);
            if (result == ApiResultEnum.Success && MonitorRA.GetStatusTrade() != 0)
                AccountRA.UpdateStatusOrder(model.status, "A_" + model.id);
            return Result(result);
        }

        public Result Delete(Model.DB.Account model)
        {
            var account_groups = AccountGroupDA.List4Account(model.id);
            if (account_groups.Count > 0)
                return Result(ApiResultEnum.Cited, string.Join(",", account_groups.Select(u => u.code)));

            model.created_by = user_id;
            ApiResultEnum result = AccountDA.Delete(model);
            if (result == ApiResultEnum.Success && MonitorRA.GetStatusTrade() != 0)
            {
                TradeBiz.RemoveAccount(model.id);
                AccountRA.Delete("A_" + model.id);
            }
            return Result(result);
        }
    }
}
