using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

namespace MobileTracker
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        [WebInvoke(Method = "GET",
            BodyStyle= WebMessageBodyStyle.Wrapped,
            ResponseFormat=WebMessageFormat.Json,
            UriTemplate="WriteGps/{userName}/{password}/{imei}/{time}/{lat}/{lng}")]
        int WriteGps(string userName, string password, string imei, string time, string lat, string lng);

        [OperationContract]
        [WebInvoke(Method = "GET",
               BodyStyle = WebMessageBodyStyle.Wrapped,
               ResponseFormat = WebMessageFormat.Json,
               UriTemplate = "UserExist/{userName}/{password}")]
        bool UserExist(string userName, string password);

        [OperationContract]
        [WebInvoke(Method = "GET",
        BodyStyle = WebMessageBodyStyle.Wrapped,
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "CheckDevice/{userName}/{password}/{imei}")]
        bool CheckDevice(string userName, string password, string imei);

        [OperationContract]
        [WebInvoke(Method="GET",
            BodyStyle= WebMessageBodyStyle.Wrapped,
            //RequestFormat= WebMessageFormat.Json,
            ResponseFormat= WebMessageFormat.Json,
            UriTemplate="/DeviceJson/{userName}/{password}/{imei}")]
        string DeviceJson(string userName, string password, string imei);
    }
}
