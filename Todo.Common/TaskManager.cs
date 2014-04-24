using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Common
{
    public class TaskManager
    {
        private ObservableCollection<TodoItem> _todoItems = new ObservableCollection<TodoItem>();
        public ObservableCollection<TodoItem> TodoItems
        {
            get { return _todoItems; }
            set { _todoItems = value; }
        }

        private TodoItem _newTodoItem = new TodoItem();
        public TodoItem NewTodoItem
        {
            get { return _newTodoItem; }
            set { _newTodoItem = value; }
        }

        public void AddTodoItem()
        {
            TodoItems.Add(NewTodoItem);
            NewTodoItem = new TodoItem();
        }

        public void RemoveItem(TodoItem todoItem)
        {
            TodoItems.Remove(todoItem);
        }
    }
}
