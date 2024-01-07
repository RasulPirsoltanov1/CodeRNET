using Delegates_Using_Example_WPF_App.Request_Creators;

namespace Delegates_Using_Example_WPF_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetRequestCreator requestCreator = new GetRequestCreator();
            requestCreator.OnRequestFinished += RequestCreator_OnRequestFinished;
            MessageBox.Show(requestCreator.GetPosts().FirstOrDefault().title);
        }

        private void RequestCreator_OnRequestFinished(object? sender, int e)
        {
            MessageBox.Show($"RequestCreator_OnRequestFinished method started Length : {e}");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PostRequestCreator requestCreator = new PostRequestCreator();
            MessageBox.Show(requestCreator.CreatePost(new Models.PostModel()).id.ToString());
        }
    }
}