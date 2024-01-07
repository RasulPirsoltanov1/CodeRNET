using Delegates_Using_Example_WPF_App.Models;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace Delegates_Using_Example_WPF_App.Request_Creators
{
    public class PostRequestCreator : BaseRequestCreator
    {
        private PostModel _postModel;

        public PostModel CreatePost(PostModel postModel)
        {
            _postModel = postModel;
            base.SetBaseAddressMethod(() => "https://jsonplaceholder.typicode.com/");
            SetHttpMethod(HttpMethod.Post);
            return JsonSerializer.Deserialize<PostModel>(base.MakeRequest());
        }
        protected override string GetPath()
        {
            return "posts";
        }
        protected override string GetBaseAddress()
        {
            return "https://jsonplaceholder.typicode.com/";
        }
        protected override object GetBodyObj()
        {
            return _postModel;
        }
    }
}

