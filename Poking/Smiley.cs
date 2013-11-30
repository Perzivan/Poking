using System;
using System.Drawing;
using MonoTouch.UIKit;


namespace Poking
{
	public class Smiley {
		public RectangleF Rect { get;private set;}
		public UIImage Image { get;private set;}
		private int MaxMoveX;
		private int MaxMoveY;

		public Smiley(string imagePath, int width, int height, int maxMoveX, int maxMoveY) {
			MaxMoveX = maxMoveX;
			MaxMoveY = maxMoveY;
			Point p = GetNextPossition (maxMoveX - width, maxMoveY - height);
			Rect = new RectangleF (p.X, p.Y, width, height);
			Image = new UIImage (imagePath);
		}

		public void RandomMove(int width, int height) {
			Point p = GetNextPossition (MaxMoveX - width, MaxMoveY - height);
			Rect = new RectangleF (p.X, p.Y, width, height);
		}

		public Point GetNextPossition(int maxX, int maxY) {
			System.Random rnd = new Random ();
			int x = rnd.Next (0, maxX);
			int y = rnd.Next (0, maxY);
			return new Point (x, y);		
		}
	}
}

