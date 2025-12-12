using System.Net;
using System.Net.Sockets;
using System.Text;

namespace HiTimeSyncClient
{
    public partial class TimeSyncClientForm : Form
    {
        UdpClient broadcastClient;
        const string magicNumber = "HITIMESYNCSERVER";
        const string broadcastIP = "FF01:0E0F::1E1F";
        const UInt16 broadcastPort = 8888;

        public TimeSyncClientForm()
        {
            InitializeComponent();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            broadcastClient = new UdpClient(AddressFamily.InterNetworkV6);
            broadcastClient.Connect(IPAddress.Parse(broadcastIP), broadcastPort);
            broadcastClient.Close();
        }
    }
}