using System;
using System.Drawing;
using System.Windows.Forms;

namespace MovingWindow
{
	public partial class MainWindow : Form
	{
		private const int step = 6;
		private string direction;

		public MainWindow()
		{
			InitializeComponent();
		}

		private void KeyPressed(object sender, KeyEventArgs e)
		{
			if (!timer.Enabled)
			{
				timer.Start();
			}
			switch (e.KeyCode)
			{
				case Keys.Up:
					direction = "Up";
					break;
				case Keys.Down:
					direction = "Down";
					break;
				case Keys.Left:
					direction = "Left";
					break;
				case Keys.Right:
					direction = "Right";
					break;
				case Keys.Enter:
					CenterToScreen();
					timer.Stop();
					break;
			}
		}

		private void Step(object sender, EventArgs e)
		{
			if (direction == "Down")
			{
				if (Location.Y + Height != Screen.PrimaryScreen.Bounds.Height)
				{
					if (Location.Y + step + Height <= Screen.PrimaryScreen.Bounds.Height)
					{
						Location = new Point(Location.X, Location.Y + step);
					}
					else
					{
						Location = new Point(Location.X, Screen.PrimaryScreen.Bounds.Height - Height);
					}
				}
				else
				{
					KeyPressed(this, new KeyEventArgs(Keys.Up));
				}
			}
			else if (direction == "Up")
			{
				if (Location.Y != 0)
				{
					if (Location.Y - step >= 0)
					{
						Location = new Point(Location.X, Location.Y - step);
					}
					else
					{
						Location = new Point(Location.X, 0);
					}
				}
				else
				{
					KeyPressed(this, new KeyEventArgs(Keys.Down));
				}
			}
			else if (direction == "Left")
			{
				if (Location.X != 0)
				{
					if (Location.X - step >= 0)
					{
						Location = new Point(Location.X - step, Location.Y);
					}
					else
					{
						Location = new Point(0, Location.Y);
					}
				}
				else
				{
					KeyPressed(this, new KeyEventArgs(Keys.Right));
				}
			}
			else if (direction == "Right")
			{
				if (Location.X + Width != Screen.PrimaryScreen.Bounds.Width)
				{
					if (Location.X + step + Width <= Screen.PrimaryScreen.Bounds.Width)
					{
						Location = new Point(Location.X + step, Location.Y);
					}
					else
					{
						Location = new Point(Screen.PrimaryScreen.Bounds.Width - Width, Location.Y);
					}
				}
				else
				{
					KeyPressed(this, new KeyEventArgs(Keys.Left));
				}
			}
		}
	}
}