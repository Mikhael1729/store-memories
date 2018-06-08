//using System;
//using Android.App;
//using Android.Content;
//using Android.Graphics;
//using Android.OS;
//using Android.Provider;
//using Android.Runtime;
//using Java.IO;
//using StoreMemories.Droid.DependencyService;
//using StoreMemories.Droid.Utilities;
//using StoreMemories.Services;
//using Xamarin.Forms;

//[assembly:Dependency(typeof(TakePhoto))]
//namespace StoreMemories.Droid.DependencyService
//{
//    public class TakePhoto : Activity, ITakePhoto
//    {
//        // Others.
//        private File imageDirectory;
//        private File imageFile;
//        private Bitmap imageBitmap;

//        protected override void OnCreate(Bundle savedInstanceState)
//        {
//            base.OnCreate(savedInstanceState);

//            imageDirectory = new File
//            (
//                Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures),
//                "StoreMemories"
//            );

//            if (!imageDirectory.Exists())
//                imageDirectory.Mkdirs();
//        }

//        void ITakePhoto.TakePhoto()
//        {
//            // Storing the new photo in previusly created directory.
//            imageFile = new File(imageDirectory, String.Format("Memory_{0}.jpg", Guid.NewGuid()));

//            // Creating intent to send a CameraActivity of Android.OS.
//            var intent = new Intent(MediaStore.ActionImageCapture);

//            // Passing the path of the image taken to intent.
//            intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile(imageFile));

//            StartActivityForResult(intent, 0);
//        }

//        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
//        {
//            int heihgt = 200;
//            int width = 200;

//            imageBitmap = ImageHelper.GetImageBitmapFromFilePath(imageFile.Path, width, heihgt);
            

//            //if (imageBitmap != null)
//            //{
//            //    imageView.SetImageBitmap(imageBitmap);
//            //    imageBitmap = null;
//            //}

//            GC.Collect();
//        }
//    }
//}