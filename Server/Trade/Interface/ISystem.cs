using Model.API;
using Model.DB;
using Model.Enum;
using Model.Return;
using Model.Search;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Trade.Interface
{
    [ServiceContract]
    public interface ISystem
    {
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json)]
        Result<List<LogTrade>> ListLogTrade();

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json)]
        Result UpdateStatusTrade(StatusTradeEnum status);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json)]
        Result<List<AccountPosition>> ListAccountPosition(int account_id);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json)]
        Result PositionTransfer(PositionTransfer model);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json)]
        Result PositionMoveIn(PositionMoveIn model);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json)]
        Result<List<Order>> ListOrder(SearchOrderStatus model);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json)]
        Result<List<Deal>> ListDeal(SearchDealStatus model);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json)]
        Result<List<Position>> ListPosition();

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json)]
        Result Transfer(Transfer model);
    }
}