using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace Poking
{
	public partial class PokingViewController : UIViewController
	{
		private  Board _Board;
		private static Smiley _Smiley;
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
			base.TouchesEnded (touches, evt);
			// get the touch
			UITouch touch = touches.AnyObject as UITouch;

			if (touch != null) {
				//==== IMAGE TOUCH
				if (_Smiley.PokeImage.ImageView.Frame.Contains(touch.LocationInView(View)))
				{
					AddPoints (1);
					UIView.Animate (0.5,0,UIViewAnimationOptions.CurveEaseIn,MoveSmiley,()=>{});
				}
			}
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// Perform any additional setup after loading the view, typically from a nib.
			_Board = new Board (262, 365);

			_Smiley = new Smiley ("smiley.png",34, 34,_Board.Width ,_Board.Height );
			Add (_Smiley.PokeImage.ImageView);

			_Timer = new System.Timers.Timer (2000);
			//hmm is this aproach wrong? how are these kinds of timed animations best done. 
			_Timer.Elapsed += (sender, e) => {
				MoveSmiley();
			};

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
		}
		 
		private void MoveSmiley() 
		{
			int width = _Board.Width - Convert.ToInt32(_Smiley.PokeImage.ImageView.Frame.Width);
			int height = _Board.Height - Convert.ToInt32(_Smiley.PokeImage.ImageView.Frame.Height);

			Point p = _Smiley.GetNextPossition (width, height);
			_Smiley.PokeImage.ImageView.Frame = new RectangleF (p.X, p.Y, _Smiley.Rect.Width, _Smiley.Rect.Height);
		}

		partial void btnStop (NSObject sender)
		{
			_Timer.Stop();
		}
	}
}

