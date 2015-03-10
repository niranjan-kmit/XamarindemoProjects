#pragma warning disable 1591


namespace JsonService
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.ServiceModel.Web;

    using JsonService.JsonDto;

    /// <summary>
    /// EntitiesModelService interface.
    /// </summary>
    [ServiceContract]
    public interface IEntitiesModelService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetData/{value}")]
        string GetData(string value);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        IEnumerable<Contact> GetContacts();

        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        void SaveContacts(IEnumerable<Contact> Contacts);

        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        byte[] DownloadBytes(string Folder, string FileName);

        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        void UploadBytes(string FileName, string Folder, IEnumerable<byte> Bytes);

    }
}
#pragma warning restore 1591
