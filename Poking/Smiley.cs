using System;
using System.Drawing;
using MonoTouch.UIKit;
using MonoTouch.CoreAnimation;

namespace Poking
{
	public class Smiley {
		public RectangleF Rect { get;private set;}
		public RectangleF MoveBoundary { get;private set;}
		public CALayer Layer { get;private set;}

		private const string ImagePath = "smiley.png";

		public Smiley(RectangleF moveBoundary) {
			MoveBoundary = moveBoundary;
			PointF p = GetNextPossition ();
			Rect = new RectangleF (p.X, p.Y, MoveBoundary.Width, MoveBoundary.Height);
			Layer = new CALayer ();
			Layer.Bounds = new RectangleF (0,0,50,50);
			Layer.Position = GetNextPossition ();
			Layer.Contents = UIImage.FromFile (ImagePath).CGImage;
			Layer.ContentsGravity = CALayer.GravityResizeAspectFill;
		}

		public PointF GetNextPossition() {
			System.Random rnd = new Random ();
			int x = rnd.Next (0, Convert.ToInt32(MoveBoundary.Width));
			int y = rnd.Next (0, Convert.ToInt32(MoveBoundary.Height));
			return new Point (x, y);		
		}
	}
}

