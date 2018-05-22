using System;
using System.Drawing;
using System.Windows.Forms;

namespace MovingWindow
{
	public partial class Form1 : Form
	{
		private const int step = 6;

		public Form1()
		{
			InitializeComponent();
		}

		private int OldX { get; set; }

		private int OldY { get; set; }

		private void KeyPressed(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Enter)
			{
				OldX = Location.X;
				OldY = Location.Y;
			}
			if (!timer.Enabled)
			{
				timer.Start();
			}
			switch (e.KeyCode)
			{
				case Keys.Up:
					if (Location.Y - step >= 0)
					{
						Location = new Point(Location.X, Location.Y - step);
					}
					break;
				case Keys.Down:
					if (Location.Y + Height + step <= Screen.PrimaryScreen.Bounds.Height)
					{
						Location = new Point(Location.X, Location.Y + step);
					}
					break;
				case Keys.Left:
					if (Location.X - step >= 0)
					{
						Location = new Point(Location.X - step, Location.Y);
					}
					break;
				case Keys.Right:
					if (Location.X + Width + step <= Screen.PrimaryScreen.Bounds.Width)
					{
						Location = new Point(Location.X + step, Location.Y);
					}
					break;
				case Keys.Enter:
					CenterToScreen();
					timer.Stop();
					break;
			}
		}

		private void Step(object sender, EventArgs e)
		{
			if (Location.Y + step > OldY && Location.Y + step + Height <= Screen.PrimaryScreen.Bounds.Height && OldY != Location.Y)
			{
				OldY = Location.Y;
				Location = new Point(Location.X, Location.Y + step);
			}
			else if (Location.Y > OldY)
			{
				OldY = Location.Y;
				Location = new Point(Location.X, Location.Y - step);
			}

			else if (Location.Y - step < OldY && Location.Y - step >= 0 && OldY != Location.Y)
			{
				OldY = Location.Y;
				Location = new Point(Location.X, Location.Y - step);
			}
			else if (Location.Y < OldY)
			{
				OldY = Location.Y;
				Location = new Point(Location.X, Location.Y + step);
			}

			else if (Location.X + step > OldX && Location.X + step + Width <= Screen.PrimaryScreen.Bounds.Width && OldX != Location.X)
			{
				OldX = Location.X;
				Location = new Point(Location.X + step, Location.Y);
			}
			else if (Location.X > OldX)
			{
				OldX = Location.X;
				Location = new Point(Location.X - step, Location.Y);
			}

			else if (Location.X - step < OldX && Location.X - step >= 0 && OldX != Location.X)
			{
				OldX = Location.X;
				Location = new Point(Location.X - step, Location.Y);
			}
			else if (Location.X < OldX)
			{
				OldX = Location.X;
				Location = new Point(Location.X + step, Location.Y);
			}
		}
	}
}
