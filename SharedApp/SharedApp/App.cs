using SharedApp.Data;
using SharedApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Couchbase.Lite;

namespace SharedApp
{
	public class App : Application
	{


        public App()
        {
            database = new TaskItemDatabase();
            manager = CouchBase.init();
            MainPage = new NavigationPage(new ListTaskPage { });
        }

        static TaskItemDatabase database;
        public static TaskItemDatabase Database
        {
            get { return database; }
        }

        static Manager manager;
        public static Manager Manager
        {
            get { return manager; }
        }

            
       
		

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
