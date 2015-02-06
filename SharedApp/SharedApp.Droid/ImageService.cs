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
using SharedApp.ImagePicker;
using Xamarin.Forms;
using System.Threading.Tasks;
using SharedApp.Droid;
using Java.Lang;
using Xamarin.Media;


[assembly: Dependency(typeof(ImageService))]
namespace SharedApp.Droid
{
    public class ImageService : IImagePicker
    {
        public Task<MediaFile> getImageActivity()
        {
            #region IImagePicker implementation
            Class isd = new ImageActivity().Class;
            var intent = new Intent(Forms.Context, isd);
            Forms.Context.StartActivity(intent);

            return null;
            #endregion

        }
    }
}