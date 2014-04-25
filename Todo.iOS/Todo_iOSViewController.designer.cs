// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace Todo.iOS
{
	[Register ("Todo_iOSViewController")]
	partial class Todo_iOSViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton addButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField newTaskText { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITableView tableTasks { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (addButton != null) {
				addButton.Dispose ();
				addButton = null;
			}

			if (newTaskText != null) {
				newTaskText.Dispose ();
				newTaskText = null;
			}

			if (tableTasks != null) {
				tableTasks.Dispose ();
				tableTasks = null;
			}
		}
	}
}
