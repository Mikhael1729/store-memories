using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StoreMemories.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MemoriesPage : ContentPage
	{
		public MemoriesPage ()
		{
			InitializeComponent ();
            CreateMemoryFab.Clicked += CreateMemoryFab_Clicked;
		}

        public void CreateMemoryFab_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateMemoryPage());
        }
	}
}