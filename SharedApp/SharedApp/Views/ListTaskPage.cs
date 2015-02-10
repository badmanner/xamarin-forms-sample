using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace SharedApp.Views
{
	public class ListTaskPage : ContentPage
	{
        ListView listView;
        TaskManagerImpl tm = TaskManagerImpl.Instance;
		public ListTaskPage ()
		{
            

            Title = "Task list";

            NavigationPage.SetHasNavigationBar(this, true);

            listView = new ListView
            {
                RowHeight = 25
            };

            listView.ItemTemplate = new DataTemplate(typeof(TaskCell));
            if (tm.getTasks() != null)
            {                
                listView.ItemsSource = tm.getTasks();
                foreach (Task task in tm.getTasks())
                {
                    Console.WriteLine("IMAGE FOR EACH TASK " + task.taskImage + " " + task.ID);
                }
            }
            


            //if (tm.getSize() > 0)
            //{
            //    var tasks = new Task[tm.getSize()];
            //    int i = 0;
            //    foreach (Task task in tm.getTasks())
            //    {

            //        tasks[i] = task;
            //        i++;
            //    }
            //    listView.ItemsSource = tasks;
            //}

            
            var layout = new StackLayout();
            layout.Children.Add(listView);
            layout.VerticalOptions = LayoutOptions.FillAndExpand;
            Content = layout;

            listView.ItemSelected += (sender, e) =>
            {
                var taskItem = (Task) e.SelectedItem;
                var taskPage = new TaskPage(taskItem);
                taskPage.BindingContext = taskItem;
                                
                Navigation.PushAsync(taskPage);

            };

            ToolbarItem tbitem = null;

            tbitem = new ToolbarItem("+", null, () =>
            {
                var taskItem = new Task();
                var taskPage = new TaskPage(taskItem);

                taskPage.BindingContext = taskItem;
                Navigation.PushAsync(taskPage);
            }, 0, 0);

            ToolbarItems.Add(tbitem);

		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (tm.getTasks() != null)
            {
                listView.ItemsSource = tm.getTasks();
                foreach (Task task in tm.getTasks()) {
                    Console.WriteLine("IMAGE FOR EACH TASK " + task.taskImage + " " + task.ID);
                }
            }
                
        }
	}
}
