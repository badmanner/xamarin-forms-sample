using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SharedApp.Models
{
    interface ITaskManager
    {
       IEnumerable getTasks();
       //int getSize();
       void deleteTask(Task task);
       int addTask(Task task);
    }
}
