using DelegateForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DelegateForm.RequestCreators
{
    public class GetPostRequestCreator : BaseRequestCreator
    {
        public GetPostRequestCreator()
        {
            GetBaseAddressDelegate getBaseAddressDelegate = new GetBaseAddressDelegate(() =>
            {
                return "https://jsonplaceholder.typicode.com/";
            });
            base.SetBaseAddressDlegateMethod(getBaseAddressDelegate);
        }
        public List<PostModel> GetPosts()
        {
            return JsonSerializer.Deserialize<List<PostModel>>(base.MakeRequest());
        }
        protected override string GetBaseAddress()
        {
            return "https://jsonplaceholder.typicode.com/";
        }
        protected override HttpMethod SetHttpMethod()
        {
            return HttpMethod.Get;
        }
        protected override string GetUrlPath()
        {
            return "posts";
        }
    }

}
