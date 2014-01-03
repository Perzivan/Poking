using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Threading.Tasks;
using System.Collections.Generic;
using MonoTouch.CoreAnimation;
using MonoTouch.CoreGraphics;
using MonoTouch.AudioToolbox;


namespace Poking
{
	public partial class PokingViewController : UIViewController
	{
		private  Smiley _Smiley;
		System.Timers.Timer _Timer;

		public PokingViewController () : base ("PokingViewController", null)
		{

		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void TouchesEnded (NSSet touches, UIEvent evt)
		{
			if (!_Timer.Enabled)
				return;

			base.TouchesEnded (touches, evt);
			// get the touch
			UITouch touch = touches.AnyObject as UITouch;

			if (touch != null) {
				PointF Location = touch.LocationInView(View);
		
				if (_Smiley.Layer.Frame.Contains (Location)) {
					AddPoints (1);
					SystemSound.Vibrate.PlaySystemSound ();
					MoveSmiley();
				}
			}
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.
			_Smiley = new Smiley (GetMoveRectangle());
			View.Layer.AddSublayer (_Smiley.Layer);

			_Timer = new System.Timers.Timer (2000);
			_Timer.Elapsed += (sender, e) => MoveSmiley ();

			lblPoints.Text = "Points: 0";
		}
	
		public void AddPoints(int points){

			PokePoint poke = new PokePoint (':',1);
			int number = poke.GetPoints (lblPoints.Text);
			lblPoints.Text = lblPoints.Text.Replace(number.ToString(),(number + points).ToString());
		}

		partial void btnStart (NSObject sender)
		{
			_Timer.Start();
			MoveSmiley();		
		}
		 
		private void MoveSmiley() 
		{
			CATransaction.Begin ();
			CATransaction.AnimationDuration = 0.3;

			_Smiley.Layer.Position = _Smiley.GetNextPossition ();

			CATransaction.Commit ();
		}

		private RectangleF GetMoveRectangle() {
			int maxWidth = Convert.ToInt32 (aBoard.Frame.Width);
			int maxHeight = Convert.ToInt32 (aBoard.Frame.Height);
			return new RectangleF (0, 0,maxWidth,maxHeight);
		}

		partial void btnStop (NSObject sender)
		{
			_Timer.Stop();
		}
	}
}

