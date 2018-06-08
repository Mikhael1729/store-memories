using Plugin.Media.Abstractions;
using StoreMemories.Models;
using StoreMemories.ViewModels;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StoreMemories.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CreateMemoryPage : ContentPage
	{
        private CreateMemoryViewModel vm;

        public CreateMemoryPage ()
		{
			InitializeComponent ();
            BindingContext = vm = ((ViewModelLocator)Application.Current.Resources["Locator"]).CreateMemoryViewModel;
            FormIsValid();
		}

        #region Event Methods
        private async void StoreButton_Clicked(object sender, EventArgs e)
        {
            if (FormIsValid())
            {
                vm.StoreData();
                MessagingCenter.Send(this, "NewMemory", vm.Memory);
                await DisplayAlert("Notification", "You have saved a memory", "OK");

                await Navigation.PopAsync();
            }
            else
            { 
                await DisplayAlert("Advertisment", "You need write valid data", "OK");
            }
        }

        private async void TakePhotoButton_Clicked(object sender, EventArgs e)
        {
            // Taking photo and storing it.
            MediaFile photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions() { });

            // Showing container.
            PhotoImage.IsVisible = true;
            
            // Filling container (Image) with stream.
            if (photo != null)
                PhotoImage.Source = ImageSource.FromStream(() => { return photo.GetStream(); });

            // Storing image.
            vm.Photo = new Photo() { ImageByte = ConvertStreamToByte(photo.GetStream()) };    
        }

        private void NameXEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckNameValid();
        }

        private void DescriptionXEditor_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckDescriptionValid();
            FormIsValid();
        }
        #endregion

        #region Validation Methods
        private bool CheckDescriptionValid()
        {
            // Name lenght.
            int descriptionLength = (DescriptionXEditor.Text ?? "").Length;

            // Is fun?
            bool isFun = descriptionLength > 5 && descriptionLength > 0;

            // Setting visual state.
            string validityState = isFun ? "Valid" : "Invalid";
            if (descriptionLength == 0) validityState = "Stateless";

            VisualStateManager.GoToState(DescriptionXEditor, validityState);

            return isFun;
        }

        private bool CheckNameValid()
        {
            // Name lenght.
            int nameLength = (NameXEntry.Text ?? "").Length;

            // Is fun?
            bool isFun = nameLength > 5;
            
            // Setting visual state.
            string validityState = isFun ? "Valid" : "Invalid";
            if (nameLength == 0) validityState = "Stateless";

            VisualStateManager.GoToState(NameXEntry, validityState);

            return isFun;
        }

        private bool FormIsValid()
        {
            bool nameValid = CheckNameValid();
            bool descriptionValid = CheckDescriptionValid();

            bool isValid = nameValid && descriptionValid;

            string validityState = isValid ? "Valid" : "Invalid";
            VisualStateManager.GoToState(StoreButton, validityState);
            
            return isValid;
        }
        #endregion

        #region Helper Methods
        public static byte[] ConvertStreamToByte(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
        #endregion
    }
}