namespace DataGridMaui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

          //    MainPage = new AppShell();
            MainPage = new LoadMorePage();
        }
    }
}
