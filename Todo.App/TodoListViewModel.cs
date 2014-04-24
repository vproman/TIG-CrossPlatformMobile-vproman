using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Common;

namespace Todo.App
{
    public class TodoListViewModel : Bindable
    {
        TaskManager manager = new TaskManager();

        public ObservableCollection<TodoItem> TodoItems
        {
            get { return manager.TodoItems; }
        }

        public TodoItem NewTodoItem
        {
            get { return manager.NewTodoItem; }
        }

        private DelegateCommand<object> _addCommand;
        public DelegateCommand<object> AddCommand
        {
            get
            {
                return _addCommand = _addCommand ?? new DelegateCommand<object>(AddExecutedHandler);
            }
        }
        private void AddExecutedHandler(object obj)
        {
            manager.AddTodoItem();
            OnPropertyChanged("NewTodoItem");
        }

        private DelegateCommand<TodoItem> _deleteCommand;
        public DelegateCommand<TodoItem> DeleteCommand
        {
            get
            {
                return _deleteCommand = _deleteCommand ?? new DelegateCommand<TodoItem>(DeleteExecutedHandler);
            }
        }
        private void DeleteExecutedHandler(TodoItem todoItem)
        {
            manager.RemoveItem(todoItem);
        }
    }
}
