using Model.Return;
using Model.Common;
using Model.DB;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using Base = Model.Common.Base;

namespace Trade.Interface
{
    [ServiceContract]
    public interface IUnit
    {
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json)]
        Result<List<Unit>> List();

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json)]
        Result<List<Base>> List4Filter();

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json)]
        Result<List<Base>> List4Undirected();

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json)]
        Result<List<Base>> List4User(int _user_id);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json)]
        Result<List<Base>> List4Account(int account_id);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json)]
        Result<int> Add(Unit model);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json)]
        Result Update(Unit model);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json)]
        Result UpdateStatus(Status model);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json)]
        Result UpdateRatioFreezing(Unit model);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json)]
        Result CapitalInOut(LogCapital model);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json)]
        Result Delete(Unit model);
    }
}