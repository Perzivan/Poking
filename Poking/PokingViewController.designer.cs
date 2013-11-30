// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace Poking
{
	[Register ("PokingViewController")]
	partial class PokingViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIView aBoard { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIView imgTarget { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lblPoints { get; set; }

		[Action ("btnStart:")]
		partial void btnStart (MonoTouch.Foundation.NSObject sender);

		[Action ("btnStop:")]
		partial void btnStop (MonoTouch.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (lblPoints != null) {
				lblPoints.Dispose ();
				lblPoints = null;
			}

			if (aBoard != null) {
				aBoard.Dispose ();
				aBoard = null;
			}

			if (imgTarget != null) {
				imgTarget.Dispose ();
				imgTarget = null;
			}
		}
	}
}
