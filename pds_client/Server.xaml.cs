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
using System.IO;
using System.Xml;

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
		Dictionary<int, ServerApp> Apps = new Dictionary<int, ServerApp>();

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

		public Server(string ipString, int port)
		{
			IpString = ipString;
			Port = port;
			Socket.Connect(IPAddress.Parse(ipString), port);
			InitializeComponent();
		}

		public void ScaricaAggiornamenti()
		{
			//while (true)
			{
				StreamReader Reader =new StreamReader(Socket.GetStream());
				string Xml="";
				string XmlLine;
				XmlDocument Doc = new XmlDocument();
				while ((XmlLine = Reader.ReadLine()) != "</application_list>")
					Xml += XmlLine;
				Xml += XmlLine;
				MessageBox.Show(Xml);
				Doc.LoadXml(Xml);
				XmlNode AppList = Doc.FirstChild;
				string Ip = AppList.Attributes["server"].Value;
				MessageBox.Show(Ip);
				foreach (XmlNode App in AppList.ChildNodes)
				{
					int Id = Convert.ToInt32(App.Attributes["id"].Value);
					string Operation = App.Attributes["operation"].Value;
					if (!Apps.ContainsKey(Id) && Operation == "add")
					{
						Apps[Id] = new ServerApp("", App.FirstChild.FirstChild.Value, "10%");
						appsList.Children.Add(Apps[Id]);
					}
				}
			}
		}
	}
}