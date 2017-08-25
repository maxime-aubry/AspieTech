using AspieTech.BridgeHandler.Engine.Vaillant;
using AspieTech.BridgeHandler.LocalizationHandler;
using AspieTech.BridgeHandler.LoggerHandler;
using Castle.DynamicProxy;
using System;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Mvc;

namespace AspieTech.Engine.Handlers.Vaillant
{
    public class RestProxyHandler : IInterceptor
    {
        #region Private properties
        private ILocalizableLogHandler localizableLogHandler;
        private IResourceHandler resourceHandler;
        //private IRestProxyCredential credentials;
        //private Uri requestUri;
        #endregion

        #region Constructors
        public RestProxyHandler(/*Uri requestUri, IRestProxyCredential credentials = null*/)
        {
            //this.requestUri = requestUri;
            //this.credentials = credentials;
        }
        #endregion

        #region Finalizers

        #endregion

        #region Getters & Setters
        public ILocalizableLogHandler LocalizableLogHandler
        {
            set { this.localizableLogHandler = value; }
        }

        public IResourceHandler ResourceHandler
        {
            set { this.resourceHandler = value; }
        }
        #endregion

        #region Delegates

        #endregion

        #region Events

        #endregion

        #region Public methods
        public void Intercept(IInvocation invocation)
        {
            try
            {
                VaillantDetailsAttribute vaillantDetails = invocation.Method.GetCustomAttribute<VaillantDetailsAttribute>();
                NameValueCollection nvc = null;


                Uri requestUri = null;
                this.BuildQueryString(vaillantDetails, nvc, out requestUri);

                HttpWebRequest request = WebRequest.Create(requestUri) as HttpWebRequest;
            }
            catch (Exception e)
            {

            }
        }
        #endregion

        #region Private methods
        private HttpMethod GetHttpMethod(MethodInfo methodInfo)
        {
            if (Attribute.IsDefined(methodInfo, typeof(HttpPostAttribute)))
                return HttpMethod.Post;
            if (Attribute.IsDefined(methodInfo, typeof(HttpGetAttribute)))
                return HttpMethod.Get;
            if (Attribute.IsDefined(methodInfo, typeof(HttpPutAttribute)))
                return HttpMethod.Put;
            if (Attribute.IsDefined(methodInfo, typeof(HttpDeleteAttribute)))
                return HttpMethod.Delete;
            return HttpMethod.Get;
        }

        private void BuildQueryString(VaillantDetailsAttribute vaillantDetails, NameValueCollection nvc, out Uri buildedRequestUri)
        {
            try
            {
                UriBuilder builder = new UriBuilder(vaillantDetails.RequestUri);
                //builder.Query = nvc.
                buildedRequestUri = builder.Uri;
            }
            catch(Exception e)
            {
                throw;
            }
        }
        #endregion
    }
}