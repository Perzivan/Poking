using System;
using System.Drawing;
using MonoTouch.UIKit;
using MonoTouch.CoreAnimation;

namespace Poking
{
	public class Smiley  : CALayer {
		public RectangleF Rect { get;private set;}
		public RectangleF MoveBoundary { get;private set;}
		private const string ImagePath = "smiley.png";

		public Smiley(RectangleF moveBoundary) {
			MoveBoundary = moveBoundary;
			PointF p = GetNextPossition ();
			Rect = new RectangleF (p.X, p.Y, MoveBoundary.Width, MoveBoundary.Height);

			Bounds = new RectangleF (0,0,50,50);
			Position = GetNextPossition ();
			Contents = UIImage.FromFile (ImagePath).CGImage;
			ContentsGravity = CALayer.GravityResizeAspectFill;
		}

		public PointF GetNextPossition() {
			System.Random rnd = new Random ();
			int x = rnd.Next (0, Convert.ToInt32(MoveBoundary.Width));
			int y = rnd.Next (0, Convert.ToInt32(MoveBoundary.Height));
			return new Point (x, y);		
		}
	}
}

