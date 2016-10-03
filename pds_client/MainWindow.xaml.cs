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
using System.Threading;
using pds_client;

namespace pds_client
{
	/// <summary>
	/// Logica di interazione per MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private Dictionary<string, Server> Servers = new Dictionary<string, Server>();
		private string aggiornamenti=null;

		public MainWindow()
		{
			InitializeComponent();
		}

		private void ConnettiServer(object sender, RoutedEventArgs e)
		{
			try
			{
				Server S = new Server(textBox.Text, 1993, new DownloadCallback(UsaAggiornamenti));
				Servers.Add(textBox.Text, S);
				Thread Downloader = new Thread(S.ScaricaAggiornamenti);
				Downloader.Start(aggiornamenti);
				MessageBox.Show("Connessione riuscita");
                serverList.Items.Add(S);
			}
			catch (Exception exception)
			{
                MessageBox.Show("Impossibile connettersi a questo server: "+exception.Message);
			}
		}

		private void UsaAggiornamenti(string data)
		{
			
		}
	}
}
