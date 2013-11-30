using System;
using System.Drawing;
using MonoTouch.UIKit;
using MonoTouch.CoreAnimation;

namespace Poking
{
	public class Smiley {
		public RectangleF Rect { get;private set;}
		public CALayer Layer { get;private set;}
		private int MaxMoveX;
		private int MaxMoveY;

		public Smiley(string imagePath, int width, int height, int maxMoveX, int maxMoveY) {
			MaxMoveX = maxMoveX;
			MaxMoveY = maxMoveY;
			PointF p = GetNextPossition (maxMoveX - width, maxMoveY - height);
			Rect = new RectangleF (p.X, p.Y, width, height);

			Layer = new CALayer ();
			Layer.Bounds = new RectangleF (0, 0, 50, 50);
			Layer.Position = GetNextPossition (maxMoveX, maxMoveY);
			Layer.Contents = UIImage.FromFile ("smiley.png").CGImage;
			Layer.ContentsGravity = CALayer.GravityResizeAspectFill;
		}

		public void RandomMove(int width, int height) {
			PointF p = GetNextPossition (MaxMoveX - width, MaxMoveY - height);
			Rect = new RectangleF (p.X, p.Y, width, height);
		}

		public PointF GetNextPossition(int maxX, int maxY) {
			System.Random rnd = new Random ();
			int x = rnd.Next (0, maxX);
			int y = rnd.Next (0, maxY);
			return new Point (x, y);		
		}
	}
}

