using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Media;
using System.Threading.Tasks;

namespace SharedApp.Droid
{
    [Activity(Label = "ImageActivity")]
    public class ImageActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            var picker = new MediaPicker(this);
            if (!picker.IsCameraAvailable)
                Console.WriteLine("No camera!");
            else
            {
                //var intent = picker.GetTakePhotoUI(new StoreCameraMediaOptions
                //{
                //    Name = "test.jpg",
                //    Directory = "MediaPickerSample"
                //});
                var intent = picker.GetPickPhotoUI();
                
                StartActivityForResult(intent, 1);
            }
        }
        

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {

            // User canceled
            if (resultCode == Result.Canceled)
                return;

            data.GetMediaFileExtraAsync(this).ContinueWith(t =>
            {
                MediaFile file = t.Result;                
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

       
    }
}