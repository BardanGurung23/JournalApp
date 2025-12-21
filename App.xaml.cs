using Myjournal.Database;

namespace Myjournal;

public partial class App : Application
{
    public static ApplicationDbContext Database { get; private set; }

    public App()
    {
        InitializeComponent();

        Database = new ApplicationDbContext();

        // Set your main page
        MainPage = new MainPage(); // or MainPage = new MainPage();
    }
}