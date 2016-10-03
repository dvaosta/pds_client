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
using System.Net;
using System.Net.Sockets;

public delegate void DownloadCallback(string data);

namespace pds_client
{
	/// <summary>
	/// Logica di interazione per Server.xaml
	/// </summary>
	public partial class Server : TabItem
	{
		int Port;
		TcpClient Socket = new TcpClient();
		DownloadCallback CallbackDownload;

		public string IpString
		{
			get { return (string)GetValue(IpStringProperty); }
			set { SetValue(IpStringProperty, value); }
		}

		// Using a DependencyProperty as the backing store for EntityName.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty IpStringProperty =
			DependencyProperty.Register("IpString", typeof(string), typeof(Server), new PropertyMetadata(""));

		public Server()
		{
			InitializeComponent();
		}

		public Server(string ipString)
		{
			IpString = ipString;
			InitializeComponent();
		}

		public Server(string ipString, int port, DownloadCallback callbackDownload)
		{
			IpString = ipString;
			Port = port;
			Socket.Connect(IPAddress.Parse(ipString), port);
			CallbackDownload = callbackDownload;
			InitializeComponent();
		}

		public void ScaricaAggiornamenti()
		{
			Byte[] Data = System.Text.Encoding.ASCII.GetBytes("");
			while (true)
			{
				((NetworkStream)Socket.GetStream()).Read(Data, 0, 1024);
				if (CallbackDownload == null)
					throw new Exception("Callback per gestire gli aggiornamenti non registrata");
				CallbackDownload(System.Text.Encoding.ASCII.GetString(Data));
			}
		}
	}
}