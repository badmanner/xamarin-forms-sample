using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Media;

namespace SharedApp.ImagePicker
{
    public interface IImagePicker
    {
        Task<MediaFile> getImageActivity();
    }
}
