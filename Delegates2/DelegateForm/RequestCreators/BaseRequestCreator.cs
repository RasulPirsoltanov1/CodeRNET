using DelegateForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DelegateForm.RequestCreators
{
    public abstract class BaseRequestCreator
    {
        protected delegate string GetBaseAddressDelegate();
        GetBaseAddressDelegate baseAddressDelegate;
        private delegate string MakeRequestDelegate();
        MakeRequestDelegate makeRequestDelegate;

        protected void SetBaseAddressDlegateMethod(GetBaseAddressDelegate getBaseAddressDelegate)
        {
            baseAddressDelegate = getBaseAddressDelegate;
        }

        protected string MakeGetRequest()
        {
            HttpClient client = new HttpClient();
            var msg = new HttpRequestMessage();
            msg.Method = SetHttpMethod();
            msg.RequestUri = new Uri(baseAddressDelegate.Invoke() + GetUrlPath());
            var response = client.Send(msg);
            response.EnsureSuccessStatusCode();
            var resultContent = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return resultContent;
        }
        protected string MakePostRequest()
        {
            HttpClient client = new HttpClient();
            var msg = new HttpRequestMessage();
            msg.Method = SetHttpMethod();
            msg.RequestUri = new Uri(baseAddressDelegate.Invoke() + GetUrlPath());
            if (GetBodyObject() != null)
            {
                msg.Content = new StringContent(JsonSerializer.Serialize(GetBodyObject()));
            }
            var response = client.Send(msg);
            response.EnsureSuccessStatusCode();
            var resultContent = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return resultContent;
        }
        protected string MakeRequest()
        {
            if (GetBodyObject() != null)
                return MakePostRequest();
            else
                return MakeGetRequest();
        }
        protected virtual string GetBaseAddress()
        {
            return "";
        }
        protected virtual string GetUrlPath()
        {
            return "";
        }
        protected virtual HttpMethod SetHttpMethod()
        {
            return HttpMethod.Get;
        }

        protected virtual object GetBodyObject()
        {
            return default;
        }
    }
}
