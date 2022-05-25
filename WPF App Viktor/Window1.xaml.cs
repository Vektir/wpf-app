using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Timers;
using System.Diagnostics;
using System.Threading;
using System.Windows.Threading;

namespace WPF_App_Viktor
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class Window1 : Window
	{
		bool working = true;

		Ellipse myEllipse = new Ellipse();

		int counter = 0;

		DispatcherTimer dt;
		TimeSpan ts;

		int radius;

		public Window1(int Aimradius)
		{
			radius = Aimradius;
			InitializeComponent();
			Draw_Circle();
		
			ts = TimeSpan.FromSeconds(20);

			dt = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
			{
				Timer.Text = ts.ToString("c");
				if (ts == TimeSpan.Zero && working)
				{
					dt.Stop();
					Window2 w2 = new Window2(counter);
					w2.Show();
					this.Close();
				}
				ts = ts.Add(TimeSpan.FromSeconds(-1));
			}, Application.Current.Dispatcher);
			dt.Start();
			
			myEllipse.MouseLeftButtonDown += OnEllipseMouseLeftButtonDown;


		}


		private void Button_Click(object sender, RoutedEventArgs e)
		{
			MainWindow mw = new MainWindow();
			mw.Show();
			this.Hide();
			working = false;
		}
		private void Draw_Circle()
		{
			//GameStuff.Children.Clear();


			myEllipse.Stroke = System.Windows.Media.Brushes.Black;
			myEllipse.Fill = System.Windows.Media.Brushes.DarkBlue;
			myEllipse.SetValue(Canvas.LeftProperty, 100.00);
			myEllipse.SetValue(Canvas.TopProperty, 100.00);
			myEllipse.Width = radius;
			myEllipse.Height = radius;

			GameStuff.Children.Add(myEllipse);

		}

		private void OnEllipseMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			//Ellipse myEllipse = (Ellipse)sender;
			
			counter++;
			Score_Value.Text = counter.ToString();
			 
			Random rnd = new Random();

			myEllipse.SetValue(Canvas.LeftProperty, (double)rnd.Next(30, 750));

			myEllipse.SetValue(Canvas.TopProperty, (double)rnd.Next(30, 400));
		}

	}
}
