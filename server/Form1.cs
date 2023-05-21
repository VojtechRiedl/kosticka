using hra;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using SuperSimpleTcp;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace server
{
    public partial class Form1 : Form
    {

        SimpleTcpServer server;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            server = new SimpleTcpServer("127.0.0.1:9000");
            server.Start();
            server.Events.ClientConnected += Events_Connected;
            server.Events.DataReceived += Events_DataReceived;

            MysqlConnector.Instance.Connect();

            string command = "SELECT * FROM leaderboard ORDER BY score DESC";

            MySqlDataReader reader = MysqlConnector.Instance.GetData(command);
            
            while (reader.Read())
            {
                listBox1.Items.Add($"Jméno hráèe: {reader.GetString("user_name")}, Score: {reader.GetString("score")}, Název hry: {reader.GetString("game_name")}");
            }
            reader.Close();
            MysqlConnector.Instance.Disconnect();

        }

        private void Events_DataReceived(object? sender, DataReceivedEventArgs e)
        {
            if (server.IsListening)
            {
                this.Invoke((MethodInvoker)delegate ()
                {
                    Console.WriteLine("server received data");

                    string receivedJson = Encoding.UTF8.GetString(e.Data);

                    Data receivedObject = JsonConvert.DeserializeObject<Data>(receivedJson);

                    if(receivedObject == null)
                    {
                        return;
                    }

                    MysqlConnector.Instance.Connect();
                    string command = $"INSERT INTO leaderboard (user_name,score,game_name) VALUES ('{receivedObject.Name}',{receivedObject.Score},'{receivedObject.GameName}')";

                    MysqlConnector.Instance.InsertData(command);

                    MysqlConnector.Instance.Disconnect();

                    listBox1.Items.Add($"Jméno hráèe: {receivedObject.Name}, Score: {receivedObject.Score}, Název hry: {receivedObject.GameName}");
                });
            }
   
        }

        private void Events_Connected(object? sender, ConnectionEventArgs e)
        {
            Console.WriteLine("client connected into server");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}