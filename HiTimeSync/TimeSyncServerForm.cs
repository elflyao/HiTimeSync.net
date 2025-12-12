using System.Net;
using System.Net.Sockets;
using System.Text;

namespace HiTimeSync
{
    public partial class TimeSyncServerForm : Form
    {
        UdpClient broadcastServer;
        const string magicNumber = "HITIMESYNCSERVER";
        const string broadcastIP = "FF01:0E0F::1E1F";
        const UInt16 broadcastPort = 8888;
        public TimeSyncServerForm()
        {
            InitializeComponent();
            timer.Enabled = true;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timelabel.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            broadcastServer = new UdpClient(AddressFamily.InterNetworkV6);
            var b_magicNumber = Encoding.ASCII.GetBytes(magicNumber);
            broadcastServer.Connect(IPAddress.Parse(broadcastIP), broadcastPort);
            broadcastServer.Send(b_magicNumber);
            broadcastServer.Close();
        }
    }
}