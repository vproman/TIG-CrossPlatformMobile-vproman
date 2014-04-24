using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Todo.Common;

namespace Todo.Android
{
	[Activity (Label = "Todo.Android", MainLauncher = true)]
	public class MainActivity : Activity
	{
		TaskManager taskManager;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			taskManager = new TaskManager ();

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.addButton);
			
			button.Click += delegate {
				var todoText = FindViewById<EditText>(Resource.Id.todoItemText);
				taskManager.NewTodoItem.Text = todoText.Text;
				taskManager.AddTodoItem();
			};

			var taskListView = FindViewById<ListView> (Resource.Id.listTasks);
			var taskListAdapter = new TaskListAdapter (this, taskManager.TodoItems);
			taskListView.Adapter = taskListAdapter;
		}
	}
}


