using DelegateForm.RequestCreators;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace DelegateForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int rand = Random.Shared.Next(1, 98);
            try
            {
                GetPostRequestCreator getPostRequestCreator = new GetPostRequestCreator();
                var response = getPostRequestCreator.GetPosts();
                MessageBox.Show(response.Where(x => x.id == rand).FirstOrDefault().title);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " rnd : " + rand);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                CreatePostRequestCreator createPostRequestCreator = new CreatePostRequestCreator();
                var response =createPostRequestCreator.CreatePost(new Models.PostModel
                {
                    body = "asndkjasndkasnd",
                    title = "test rasul",
                    userId = 3
                });
                MessageBox.Show(response.id.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}