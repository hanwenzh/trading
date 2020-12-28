using Model.Return;
using Model.Common;
using Model.DB;
using System;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Collections.Generic;
using Base = Model.Common.Base;

namespace Trade.Interface
{
    [ServiceContract]
    public interface IAccount
    {
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json)]
        Result<List<Account>> List();

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json)]
        Result<List<Base>> List4Filter();

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json)]
        Result<List<Base>> List4Unit(int unit_id);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json)]
        Result<int> Add(Account model);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json)]
        Result Update(Account model);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json)]
        Result UpdateStatus(Status model);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json)]
        Result UpdateStatusOrder(StatusOrder model);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json)]
        Result Delete(Account model);
    }
}
