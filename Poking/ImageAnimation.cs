using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Poking
{
	public class PokeImage
	{
		public UIImageView ImageView { get; private set;}

		public PokeImage (RectangleF frame, UIImage Image)
		{
			ImageView = new UIImageView (frame);
			ImageView.Image = Image;
		}
	}
}

