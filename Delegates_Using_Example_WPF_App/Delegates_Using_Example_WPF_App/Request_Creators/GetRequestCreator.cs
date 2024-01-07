using Delegates_Using_Example_WPF_App.Models;
using System.Text.Json;

namespace Delegates_Using_Example_WPF_App.Request_Creators
{
    public class GetRequestCreator : BaseRequestCreator
    {
        //events
        public event EventHandler<int> OnRequestFinished;
        public List<PostModel> GetPosts()
        {
            SetBaseAddressMethod(()=> "https://jsonplaceholder.typicode.com/");
            SetHttpMethod(HttpMethod.Get);
            SetRequestStartedMethod(() =>
            {

                MessageBox.Show("Request started.");

            });
            SetRequestCountFunc((int count) =>
            {
                return count+1;
            });
            var responseCount = base.MakeRequest();
            OnRequestFinished?.Invoke(this,responseCount.Length);
            return JsonSerializer.Deserialize<List<PostModel>>(base.MakeRequest());
        }
        protected override string GetBaseAddress()
        {
            return "https://jsonplaceholder.typicode.com/";
        }
        protected override string GetPath()
        {
            return "posts";
        }
     
    }
}

