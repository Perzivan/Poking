using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Poking
{
	public class PokePoint
	{
		char _Separator;
		int _PointPos;

		public PokePoint (char separator, int pointPos)
		{
			_Separator = separator;
			_PointPos = pointPos;
		}

		public int GetPoints (string text)
		{
			string numberText = GetTextNumber (text);
			return int.Parse (numberText);
		}

		private string GetTextNumber (string text)
		{
			if (string.IsNullOrEmpty(text)) {
				throw new ArgumentException ("The parameter text is null or empty.");
			}

			List<string> splits = new List<string> (text.Split (new char[] { _Separator }, StringSplitOptions.RemoveEmptyEntries));

			if (splits.Count != 2) {
				throw new FormatException ("The parameter text is incorrectly formated.");
			}

			return splits [_PointPos].Trim ();
		}
	}
}