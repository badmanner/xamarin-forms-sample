using System;
using System.Collections.Generic;
using System.Text;
using Couchbase.Lite;

namespace SharedApp.Data
{
    class CouchBase
    {
        //CouchLite DataBase
        private Database db;
        //Query  that automatically refreshes every time the db changes in a way that would affect the result
        private LiveQuery query;
        //db name
        private string DB_NAME = "task-db";

        /// <summary>
        /// db and query initialization 
        /// </summary>
        public void init()
        {
            db = Manager.SharedInstance.GetDatabase(DB_NAME);

            var view = db.GetView("tasks");

            if (view.Map == null)
            {
                view.SetMap((props, emit) =>
                {
                    emit(DateTime.UtcNow.ToString(), props["text"]);
                }, "1");
            }

            query = view.CreateQuery().ToLiveQuery();
            query.Changed += QueryChanged;
            query.Completed += QueryCompleted;
            query.Start();
        }

        private void QueryCompleted(object sender, QueryCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void QueryChanged(object sender, QueryChangeEventArgs e)
        {
            throw new NotImplementedException();
        }

        //Creates new document for task
        private void CreateNewDocument(string text = null, string title = null)
        {
            var props = new Dictionary<string, object>
            {
                { "text", text ?? "Create a new task!" },
                { "title", title ?? "New title"}
            };
            var doc = db.CreateDocument();
            var rev = doc.CreateRevision();
            rev.SetProperties(props);
            rev.Save();
        }
    }
}
