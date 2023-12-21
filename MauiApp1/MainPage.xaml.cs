namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnSecButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SecondPage());
        }

        private void OnThiButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ThirdPage());
        }

        private void OnFouButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FourPage());
        }
        private void OnFivButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FivePage());
        }
    }
}