using System;
using System.Drawing;

namespace Poking
{
	public  class Board {


		Rectangle _Rectangle;

		public int Width { get; private set;}
		public int Height  { get; private set;}

		public Board(int width, int height) {
			Width = width;
			Height = height;
		}
	}
}

