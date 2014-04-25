using System;
using MonoTouch.UIKit;

namespace Todo.iOS
{
	public class CatchEnterDelegate : UITextFieldDelegate
	{
		public CatchEnterDelegate ()
		{
		}

		public override bool ShouldReturn (UITextField textField)
		{
			textField.ResignFirstResponder ();
			return true;
		}
	}
}

