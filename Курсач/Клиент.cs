using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
using System.Threading;


namespace Курсач
{
    public partial class Клиент : Form
    {
        public Клиент()
        {
            InitializeComponent();
        }
        string LastMessage;
        // Объект содержащий рабочий сокет клиентского приложения
        TcpClient _tcpСlient = new TcpClient();

        // Объект сетевого потока для приема и отправки сообщений
        NetworkStream ns;

        private void Начать_Click(object sender, EventArgs e)
        {
            if (Connect())
            {
                Адрес.Enabled = false;
                Порт.Enabled = false;
                Начать.Enabled = false;
            }
        }

        private void Отключиться_Click(object sender, EventArgs e)
        {
            CloseClient();
            Адрес.Enabled = true;
            Порт.Enabled = true;
            Начать.Enabled = true;
        }

        // Попытка подключения к серверу
        bool Connect()
        {
            try
            {
                _tcpСlient.Connect(Адрес.Text, int.Parse(Порт.Text));
                
                ns = _tcpСlient.GetStream();

                ns.Flush();

                Thread th = new Thread(ReceiveRun);
                th.Start();

                // Цветовое оповещение о подключении.
                BackColor = Color.FromArgb(255, 128, 0);
                return true;
            }
            catch
            {
                this.BackColor = Color.FromArgb(255, 55, 55);
                MessageBox.Show("Невозможно подключиться к серверу");
                return false;
            }
            
        }

        void CloseClient()
        {
            if (ns != null)
            {
                //byte[] buffer = Encoding.Default.GetBytes("Leave");
                //ns.Write(buffer, 0, buffer.Length);

                SendMessage("Leave");
            }


            //if (ns != null) ns.Close();
            if (_tcpСlient != null) _tcpСlient.Close();

            // Цветовое оповещение об отключении.
            BackColor = Color.FromName("Control");
        }

        void SendMessage(string message)
        {
            if (ns != null)
            {
                byte[] Sendbuffer = Encoding.Default.GetBytes(message);
                ns.Write(Sendbuffer, 0, Sendbuffer.Length);

                //ns.Flush();

            }
        }

        private void Отправить_Click(object sender, EventArgs e)
        {
            SendMessage(Ответ.Text);
            Отправить.Enabled = false;
        }

        // Цикл извлечения сообщений,
        // запускается в отдельном потоке.
        void ReceiveRun()
        {
            while (true)
            {
                try
                {
                    string s = null;
                    while (ns.DataAvailable)
                    {
                        // Определение необходимого размера буфера приема.
                        byte[] buffer = new byte[_tcpСlient.Available];

                        ns.Read(buffer, 0, buffer.Length);
                        s = Encoding.Default.GetString(buffer);

                        if (s != null)
                        {
                            if (s.Contains("turn"))
                            {
                                Отправить.Enabled = true;
                                Отправить.BackColor = Color.Green;
                                s = Encoding.Default.GetString(buffer);
                            }
                            else if (s.Contains("next"))
                            {
                                Отправить.Enabled = false;
                                Отправить.BackColor = Color.FromName("Control");
                                s = Encoding.Default.GetString(buffer);
                            }

                            if (s.Contains("lose"))
                            {
                                ShowReceiveMessage("Проигрышь");
                            }

                            if (s.Length > 0)
                            {
                                ShowReceiveMessage(s);
                            }

                            s = String.Empty;
                        }
                    }
                }
                catch
                {
                    //ErrorSound();
                }
            }
        }

        // Код доступа к свойствам объектов главной формы  из других потоков
        delegate void UpdateReceiveDisplayDelegate(string message);
        void ShowReceiveMessage(string message)
        {
            if (!message.Contains("turn") && !message.Contains("next"))
            {
                if (Ответы.InvokeRequired == true)
                {
                    UpdateReceiveDisplayDelegate rdd = new UpdateReceiveDisplayDelegate(ShowReceiveMessage);

                    // Данный метод вызывается в дочернем потоке,
                    // ищет основной поток и выполняет делегат указанный в качестве параметра 
                    // в главном потоке, безопасно обновляя интерфейс формы.
                    Invoke(rdd, new object[] { message });
                }
                else
                {
                    // Если не требуется вызывать метод Invoke, обратимся напрямую к элементу формы.
                    Ответы.Items.Add(message);
                }
            }
        }

        private void Клиент_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseClient();
        }
    }
}
