
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
		public TaskPage (Task task)
		{
            this.SetBinding(ContentPage.TitleProperty, "taskTitle");
            TaskManagerImpl tm = TaskManagerImpl.Instance;
            NavigationPage.SetHasNavigationBar(this, true);
            var currentTask = task;
            Console.WriteLine("CURRENT TASK" + currentTask.ID);
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

            var imageView = new Image {
                Source = null
            };

            if (currentTask != null)
            {                
                if (currentTask.taskImage != null)
                {                   
                    imageView.Source = ImageSource.FromFile(currentTask.taskImage);
                }                    
            }
                
            var pickImageButton = new Button { Text = "Pick image" };
            
            pickImageButton.Clicked += (sender, e) =>
            {
                DependencyService.Get<IImagePicker>().getImageActivity(currentTask.ID);
            };

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
