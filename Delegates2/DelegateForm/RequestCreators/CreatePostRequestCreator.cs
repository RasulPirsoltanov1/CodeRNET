 using DelegateForm.Models;
using System.Text.Json;

namespace DelegateForm.RequestCreators
{
    public class CreatePostRequestCreator : BaseRequestCreator
    {
        private PostModel _postModel;
        public CreatePostRequestCreator()
        {
            var delType = new GetBaseAddressDelegate(GetBaseAddress);
            base.SetBaseAddressDlegateMethod(delType);
        }
        public PostModel CreatePost(PostModel postModel)
        {
            
            return JsonSerializer.Deserialize<PostModel>(base.MakeRequest());
        }
        protected override string GetBaseAddress()
        {
            return "https://jsonplaceholder.typicode.com/";
        }
        protected override HttpMethod SetHttpMethod()
        {
            return HttpMethod.Post;
        }
        protected override string GetUrlPath()
        {
            return "posts";
        }
        protected override object GetBodyObject()
        {
            return _postModel;
        }
    }

}
