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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pds_client
{
	/// <summary>
	/// Logica di interazione per ServerApp.xaml
	/// </summary>
	public partial class ServerApp : UserControl
	{
		private bool _hasFocus;
		public bool HasFocus {
			get { return _hasFocus; }
			set {
				_hasFocus = value;
				if (!_hasFocus)
					modifyButton.Visibility = Visibility.Hidden;
				else
					modifyButton.Visibility = Visibility.Visible;
			}
		}

		public string IconPath
		{
			get { return (string)GetValue(IconPathProperty); }
			set { SetValue(IconPathProperty, value); }
		}

		public static readonly DependencyProperty IconPathProperty =
			DependencyProperty.Register("IconPath", typeof(string), typeof(ServerApp), new PropertyMetadata(""));

		public string ApplicationName
		{
			get { return (string)GetValue(ApplicationNameProperty); }
			set { SetValue(ApplicationNameProperty, value); }
		}

		public static readonly DependencyProperty ApplicationNameProperty =
			DependencyProperty.Register("ApplicationName", typeof(string), typeof(ServerApp), new PropertyMetadata(""));

		public string FocusPercentage
		{
			get { return (string)GetValue(FocusPercentageProperty); }
			set { SetValue(FocusPercentageProperty, value); }
		}

		public static readonly DependencyProperty FocusPercentageProperty =
			DependencyProperty.Register("FocusPercentage", typeof(string), typeof(ServerApp), new PropertyMetadata(""));

		public ServerApp()
		{
			InitializeComponent();
		}

		public ServerApp(string iconPath, string applicationName, string focusPercentage)
		{
			IconPath = iconPath;
			ApplicationName = applicationName;
			FocusPercentage = focusPercentage;
			InitializeComponent();
		}
	}
}
