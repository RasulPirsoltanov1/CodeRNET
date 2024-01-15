using Delegates_Using_Example_WPF_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static Delegates_Using_Example_WPF_App.Request_Creators.BaseRequestCreator;

namespace Delegates_Using_Example_WPF_App.Request_Creators
{
    public abstract class BaseRequestCreator
    {

        public delegate string BaseAddressDelegate();
        BaseAddressDelegate _baseAddressDelegate;
        public delegate string MakeRequestDelegate();
        MakeRequestDelegate makeRequestDelegate;
        public HttpMethod _httpMethod { get; private set; }
        public BaseRequestCreator()
        {
            _httpMethod = HttpMethod.Get;
        }
        protected void SetBaseAddressMethod(BaseAddressDelegate baseAddressDelegate)
        {
            _baseAddressDelegate = baseAddressDelegate;
        }
        public string MakeGetRequest()
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
                httpRequestMessage.Method = HttpMethod.Get;
                httpRequestMessage.RequestUri = new Uri(_baseAddressDelegate.Invoke() + GetPath());
                var response = httpClient.SendAsync(httpRequestMessage).Result;
                response.EnsureSuccessStatusCode();
                return response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        protected string MakePostRequest()
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
                httpRequestMessage.Method = HttpMethod.Post;
                httpRequestMessage.RequestUri = new Uri(_baseAddressDelegate.Invoke() + GetPath());
                var bodyContent = GetBodyObj();
                if (bodyContent != null)
                    httpRequestMessage.Content = new StringContent(JsonSerializer.Serialize(bodyContent));

                var response = httpClient.SendAsync(httpRequestMessage).Result;
                response.EnsureSuccessStatusCode();
                return response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        protected string MakeRequest()
        {
            //var requestCount = requestCountFunc.Invoke(1);
            //{
            //    _requestStartedDelegate.Invoke();
            //}
            return makeRequestDelegate.Invoke();
        }
        protected virtual string GetBaseAddress()
        {
            return "";
        }
        protected virtual string GetPath()
        {
            return "";
        }
        protected virtual HttpMethod SetHttpMethod(HttpMethod httpMethod)
        {
            if (httpMethod == HttpMethod.Post)
                makeRequestDelegate = MakePostRequest;
            else
                makeRequestDelegate = MakeGetRequest;
            _httpMethod = httpMethod;
            return httpMethod;
        }
        protected virtual object GetBodyObj()
        {
            return default;
        }

        //Action

        public delegate void RequestStartedDelegate();
        RequestStartedDelegate _requestStartedDelegate;

        protected void SetRequestStartedMethod(RequestStartedDelegate requestStartedDelegate)
        {
            _requestStartedDelegate = requestStartedDelegate;
        }
        protected void SetBaseAddressMethod(Action<string> action)
        {
            action.Invoke("");
        }


        //Func

        Func<int,int> requestCountFunc;
        protected void SetRequestCountFunc(Func<int,int> func)
        {
            requestCountFunc = func;
        }
    }
}

