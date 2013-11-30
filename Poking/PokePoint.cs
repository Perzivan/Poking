using System;
using System.Collections.Generic;

namespace Poking
{
	public class PokePoint
	{
		char _Separator;

		public PokePoint (char separator)
		{
			_Separator = separator;
		}

		public int GetPoints (string text)
		{
			string numberText = GetTextNumber (text);
			return int.Parse (numberText);
		}

		private string GetTextNumber (string text)
		{
			List<string> splits = new List<string> (text.Split (new char[] { _Separator }, StringSplitOptions.RemoveEmptyEntries));

			if (splits.Count < 1) {
				return string.Empty;
			}

			return splits [1].Trim ();
		}
	}
}