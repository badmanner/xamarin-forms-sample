
using SharedApp.ImagePicker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Media;

namespace SharedApp.Views
{
	public class TaskPage : ContentPage
	{
		public TaskPage ()
		{
            this.SetBinding(ContentPage.TitleProperty, "taskTitle");
            TaskManagerImpl tm = TaskManagerImpl.Instance;
            NavigationPage.SetHasNavigationBar(this, true);

            var titleLabel = new Label { Text = "Title" };
            var titleEntry = new Entry();

            titleEntry.SetBinding(Entry.TextProperty, "taskTitle");

            var textLabel = new Label { Text = "Note" };
            var textEntry = new Entry();

            textEntry.SetBinding(Entry.TextProperty, "taskText");


            var saveButton = new Button { Text = "Save" };
            saveButton.Clicked += (sender, e) =>
            {
                var taskItem = (Task)BindingContext;
                tm.addTask(taskItem);
                this.Navigation.PopAsync();
            };

            var deleteButton = new Button { Text = "Delete" };
            deleteButton.Clicked += (sender, e) =>
            {
                var taskItem = (Task)BindingContext;
                tm.deleteTask(taskItem);
                this.Navigation.PopAsync();
            };

            

#if __ANDROID__ 
            var imageView = new Image { };
            
                
            var pickImageButton = new Button { Text = "Pick image" };
            
            pickImageButton.Clicked += (sender, e) =>
            {

                var mediaFile = DependencyService.Get<IImagePicker>().getImageActivity();
                MediaFile x =  mediaFile.Result;
                imageView.Source = ImageSource.FromStream(mediaFile.Result.GetStream);
                
                                
            };

            
#endif
           


           
            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.StartAndExpand,
                Padding = new Thickness(20),
                Children = {
					titleLabel, titleEntry,
                    textLabel, textEntry,
                    saveButton, deleteButton,
                    pickImageButton, imageView
				}
            };

		}
        public delegate MediaFile getPhoto();

       
       
       
	}
}
