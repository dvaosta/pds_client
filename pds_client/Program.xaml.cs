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
	/// Logica di interazione per Program.xaml
	/// </summary>
	public partial class Program : UserControl
	{
		public string IconPath
		{
			get { return (string)GetValue(IconPathProperty); }
			set { SetValue(IconPathProperty, value); }
		}

		public static readonly DependencyProperty IconPathProperty =
			DependencyProperty.Register("IconPath", typeof(string), typeof(Application), new PropertyMetadata(""));

		public string ApplicationName
		{
			get { return (string)GetValue(ApplicationNameProperty); }
			set { SetValue(ApplicationNameProperty, value); }
		}

		public static readonly DependencyProperty ApplicationNameProperty =
			DependencyProperty.Register("ApplicationName", typeof(string), typeof(Application), new PropertyMetadata(""));

		public string FocusPercentage
		{
			get { return (string)GetValue(FocusPercentageProperty); }
			set { SetValue(FocusPercentageProperty, value); }
		}

		public static readonly DependencyProperty FocusPercentageProperty =
			DependencyProperty.Register("FocusPercentage", typeof(string), typeof(Application), new PropertyMetadata(""));

		public Program()
		{
			InitializeComponent();
		}
	}
}
