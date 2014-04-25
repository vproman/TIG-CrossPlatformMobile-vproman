using System;
using MonoTouch.UIKit;
using System.Collections.ObjectModel;
using Todo.Common;
using System.Collections.Specialized;
using System.Linq;
using MonoTouch.Foundation;

namespace Todo.iOS
{
	public class TasksTableViewSource : UITableViewSource
	{
		ObservableCollection<TodoItem> todos;

		public TasksTableViewSource ()
		{
		}

		public TasksTableViewSource(UITableView view, ObservableCollection<TodoItem> todos)
		{
			this.todos = todos;
			todos.CollectionChanged += (object sender, NotifyCollectionChangedEventArgs e) => {
				if (e.NewItems != null) {
					var newPaths = e.NewItems.OfType<TodoItem> ().Select (ni => NSIndexPath.FromRowSection (todos.Count - 1, 0))
						.ToArray ();
					view.InsertRows (newPaths, UITableViewRowAnimation.Top);
				}
			};
		}

		#region implemented abstract members of UITableViewSource

		public override int RowsInSection (UITableView tableview, int section)
		{
			return todos.Count;
		}

		public override UITableViewCell GetCell (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			const string cellIdentifier = "TableCell";
			UITableViewCell cell = tableView.DequeueReusableCell (cellIdentifier);

			if (cell == null) {
				cell = new UITableViewCell (UITableViewCellStyle.Default, cellIdentifier);
			}
			var task = todos [indexPath.Row];
			cell.TextLabel.Text = task.Text;
			cell.Accessory = task.IsCompleted ? UITableViewCellAccessory.Checkmark : UITableViewCellAccessory.None;
			cell.TextLabel.TextColor = task.IsCompleted ? UIColor.Green : UIColor.Black;

			return cell;
		}

		#endregion

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			var newIsCompleted = !todos [indexPath.Row].IsCompleted;
			todos [indexPath.Row].IsCompleted = newIsCompleted;
			var cell = tableView.CellAt(indexPath);
			cell.Accessory = newIsCompleted ? UITableViewCellAccessory.Checkmark : UITableViewCellAccessory.None;
			cell.TextLabel.TextColor = newIsCompleted ? UIColor.Green : UIColor.Black;
		}

		public override bool CanEditRow (UITableView tableView, NSIndexPath indexPath)
		{
			return true;
		}

		public override void CommitEditingStyle (UITableView tableView, UITableViewCellEditingStyle editingStyle, NSIndexPath indexPath)
		{
			if (editingStyle == UITableViewCellEditingStyle.Delete) {
				todos.RemoveAt (indexPath.Row);
				tableView.DeleteRows (new NSIndexPath[] { indexPath },
					UITableViewRowAnimation.Top);
			}
		}
	}
}

