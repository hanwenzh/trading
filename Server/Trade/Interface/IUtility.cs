using Model.Return;
using Model.DB;
using System;
using System.ServiceModel;
using System.ServiceModel.Web;
using Version = Model.DB.Version;

namespace Trade.Interface
{
    [ServiceContract]
    public interface IUtility
    {
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json)]
        ResultLogin Login(User model);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json)]
        Result<Version> Version(int current_version);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json)]
        Result<VersionFiles> VersionFiles(int current_version);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json)]
        Result Close(string token);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json)]
        Result LoadConfig(string token);
    }
}