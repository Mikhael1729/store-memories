using CommonServiceLocator;
using StoreMemories.Data;
using StoreMemories.DataServices;
using StoreMemories.ViewModels;
using StoreMemories.Views;
using Unity;
using Unity.ServiceLocation;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace StoreMemories
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();
            ConfigureServices();
			MainPage = new NavigationPage(new MemoriesPage());
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}

        private void ConfigureServices()
        {
            // Container.
            var container = new UnityContainer();

            // Your services.
            container.RegisterType(typeof(ApplicationDbContext));
            container.RegisterType<IMemoryService, MemoryService>();
            container.RegisterType<IPhotoService, PhotoService>();
            container.RegisterInstance(typeof(CreateMemoryViewModel));
            container.RegisterInstance(typeof(MemoriesViewModel));

            // Creating a locator.
            var serviceLocator = new UnityServiceLocator(container);

            // Setting the service locator with serviceLocator.
            ServiceLocator.SetLocatorProvider(() => serviceLocator);
        }
	}
}
