using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Todo.Common;

namespace Todo.iOS
{
	public partial class Todo_iOSViewController : UIViewController
	{
		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		public Todo_iOSViewController ()
			: base (UserInterfaceIdiomIsPhone ? "Todo_iOSViewController_iPhone" : "Todo_iOSViewController_iPad", null)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.
			var taskManager = new TaskManager ();

			addButton.TouchUpInside += (object sender, EventArgs e) => {
				taskManager.NewTodoItem.Text = newTaskText.Text;
				taskManager.AddTodoItem ();
				newTaskText.Text = "";
			};

			tableTasks.Source = new TasksTableViewSource (tableTasks, taskManager.TodoItems);
		}

		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			if (UserInterfaceIdiomIsPhone) {
				return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
			} else {
				return true;
			}
		}
	}
}

