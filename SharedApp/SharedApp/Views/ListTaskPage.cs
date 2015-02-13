using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Couchbase.Lite;
using Xamarin.Forms;

namespace SharedApp.Views
{
	public class ListTaskPage : ContentPage
	{
        ListView listView;
        //TaskManagerImpl tm = TaskManagerImpl.Instance;
        Manager manager = App.Manager;
        

		public ListTaskPage ()
		{
            

            Title = "Task list";

            NavigationPage.SetHasNavigationBar(this, true);

            listView = new ListView
            {
                RowHeight = 25
            };

            listView.ItemTemplate = new DataTemplate(typeof(TaskCell));
           
            


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
                var taskPage = new TaskPage(taskItem.ID);
                taskPage.BindingContext = taskItem;
                                
                Navigation.PushAsync(taskPage);

            };

            ToolbarItem tbitem = null;

            tbitem = new ToolbarItem("+", null, () =>
            {
                var taskItem = new Task();
                var taskPage = new TaskPage(taskItem.ID);

                taskPage.BindingContext = taskItem;
                Navigation.PushAsync(taskPage);
            }, 0, 0);

            ToolbarItems.Add(tbitem);

		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Database db = manager.GetDatabase("task-db");
            Document doc = db.CreateDocument();
            
            var properties = new Dictionary<string, object>()
            {
                {"title", "title one"},
                {"text", "text one"}
            };
            doc.PutProperties(properties);
            
            Console.WriteLine("HELLO                                          BEFORE");
            Console.WriteLine("HELLO  " + doc.Id);
            Console.WriteLine("HELLO  " + doc.CurrentRevisionId);
            doc.Id = "task-id";
            doc.Update((UnsavedRevision newRevision) =>
            {
                var prop = newRevision.Properties;
                prop["title"] = "title2";
                prop["text"] = "text2";
                return true;
            });
           

            Document doc2  = db.GetDocument("task-id");
            
            //Console.WriteLine("HELLO  " + doc2.GetProperty("title"));

                
        }
	}
}
