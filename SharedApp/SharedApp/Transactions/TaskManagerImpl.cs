using SharedApp.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SharedApp
{
    class TaskManagerImpl : ITaskManager
    {

        private static TaskManagerImpl instance;

        private TaskManagerImpl()  { }

        public static TaskManagerImpl Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TaskManagerImpl();
                }
                return instance;
            }
        }

        public IEnumerable getTasks()
        {

            return App.Database.getItems();
            
        }

        public void deleteTask(Task task)
        {
            if (task == null)
            {
                throw new Exception();
            }

            App.Database.deleteItem(task.ID);
        }

        public int addTask(Task task)
        {
            if (task == null)
            {
                throw new Exception();
            }
          
           return App.Database.saveItem(task);
        }

        public Task getTask(int taskId)
        {
            return App.Database.getItem(taskId);
        }

        public void updateTask(Task task)
        {
            
            App.Database.saveItem(task);
        }

    }
}
