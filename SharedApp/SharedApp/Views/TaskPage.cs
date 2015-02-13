
using SharedApp.ImagePicker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Media;
using Couchbase.Lite;

namespace SharedApp.Views
{
	public class TaskPage : ContentPage
	{
		public TaskPage (int taskId)
		{
            this.SetBinding(ContentPage.TitleProperty, "taskTitle");
            Manager tm = App.Manager;
            NavigationPage.SetHasNavigationBar(this, true);

            Database db = tm.GetDatabase("task-db");
            


            var titleLabel = new Label { Text = "Title" };
            var titleEntry = new Entry();

            titleEntry.SetBinding(Entry.TextProperty, "taskTitle");

            var textLabel = new Label { Text = "Note" };
            var textEntry = new Entry();

            textEntry.SetBinding(Entry.TextProperty, "taskText");


            var saveButton = new Button { Text = "Save" };
            saveButton.Clicked += (sender, e) =>
            {
                Document doc = db.CreateDocument();
                var properties = new Dictionary<string, object> 
                {
                    {"taskTitle", titleEntry},
                    {"taskText", textEntry}
                };
                doc.PutProperties(properties);
                this.Navigation.PopAsync();
            };

            var deleteButton = new Button { Text = "Delete" };
            deleteButton.Clicked += (sender, e) =>
            {
                //var taskItem = currentTask;
                //tm.deleteTask(taskItem);
                this.Navigation.PopAsync();
            };

            var imageView = new Image {
                Source = null
            };

            ////if (currentTask != null)
            ////{                
            ////    if (currentTask.taskImage != null)
            ////    {                   
            ////        imageView.Source = ImageSource.FromFile(currentTask.taskImage);
            ////    }                    
            ////}
            var pickImageButton = new Button { 
                Text = "Pick image"
                
            };
            //if (currentTask != null)
            //{

                
                pickImageButton.Clicked += (sender, e) =>
                {
                    
                    //DependencyService.Get<IImagePicker>().getImageActivity(currentTask.ID);
                };
           // }
            

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
        

       
       
       
	}
}
