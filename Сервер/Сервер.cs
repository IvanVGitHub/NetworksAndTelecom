using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;


using System.Text.RegularExpressions;


namespace Сервер
{
    public partial class Сервер : Form
    {
        //Слушающий сокет
        TcpListener _server;
        //Массив для клиентов
        TcpClient[] clients;

        Thread acceptThread;

        Thread readThread;
        //Счётчик клиентов
        int _clientCount;
        //Ограничение игроков
        int MaxClients;
        // Флаг мягкой остановки циклов и дополнительных потоков
        bool _stopNetwork;

        string lastCity;

        string[] CityNames;
        //Обновить количество игроков
        public void UpdateClientsDisplay()
        {
            ИгрокиОнлайн.Text = _clientCount.ToString();
        }
        // Делегат доступа к элементу формы listBox1 из вспомогательного потока.
        protected delegate void UpdateClientsDisplayDelegate();

        // Получение сообщений от клиентов
        public void UpdateReceiveDisplay(int clientnum, string message)
        {
            listBox1.Items.Add("№" + clientnum.ToString() + ": " + message);
        }
        // Делегат доступа к элементу формы listBox1 из вспомогательного потока.
        protected delegate void UpdateReceiveDisplayDelegate(int clientcount, string message);

        public Сервер()
        {
            InitializeComponent();

            this.BackColor = Color.FromArgb(255, 55, 55);

            Остановить.Enabled = false;


            CityNames = File.ReadAllLines("1.txt", Encoding.UTF8);
        }

        private void Запуск_Click(object sender, EventArgs e)
        {
            КоличествоИгроков.Enabled = false;
            Запуск.Enabled = false;
            Порт.Enabled = false;
            Остановить.Enabled = true;

            clients = new TcpClient[int.Parse(КоличествоИгроков.Value.ToString())];
            MaxClients = int.Parse(КоличествоИгроков.Value.ToString());

            StartServer();
        }

        private void Остановить_Click(object sender, EventArgs e)
        {
            КоличествоИгроков.Enabled = true;
            Запуск.Enabled = true;
            Порт.Enabled = true;

            StopServer();
        }
        
        private void StartGame_Click(object sender, EventArgs e)
        {
            readThread = new Thread(ReceiveRun);
            readThread.Start();
            acceptThread.Suspend();
        }
        // Запуск сервера и вспомогательного потока акцептирования клиентских подключений
        // т.е. назначения сокетов ответственных за обмен сообщениями 
        // с соответствующим клиентским приложением
        void StartServer()
        {
            // Предотвратим повторный запуск сервера
            if (_server == null)
            {
                // Блок перехвата исключений на случай запуска одновременно
                // двух серверных приложений с одинаковым портом.
                try
                {
                    _stopNetwork = false;
                    _clientCount = 0;

                    _server = new TcpListener(IPAddress.Any, int.Parse(Порт.Text));
                    _server.Start();


                    acceptThread = new Thread(AcceptClients);
                    acceptThread.Start();

                    // Визуальное оповещение, что сервер запущен
                    this.BackColor = Color.FromArgb(55, 155, 55);
                }
                catch
                {
                    MessageBox.Show("Порт занят");
                }
            }
        }

        //Остановка сервера 
        void StopServer()
        {
            if (_server != null)
            {
                _server.Stop();
                _server = null;
                _stopNetwork = true;

                for (int i = 0; i < _clientCount; i++)
                {
                    if (clients[i] != null) clients[i].Close();
                }
                // Визуально оповещаем, что сервер остановлен.
                readThread.Abort();
                this.BackColor = Color.FromArgb(255, 55, 55);
            }
        }

        // Принимаем запросы клиентов на подключение и
        // привязываем к каждому подключившемуся клиенту 
        // сокет (в данном случае объект класса TcpClient)
        // для обменом сообщений.
        void AcceptClients()
        {
            while (true)
            {
                try
                {
                    this.clients[_clientCount] = _server.AcceptTcpClient();
                    _clientCount++;
                    Invoke(new UpdateClientsDisplayDelegate(UpdateClientsDisplay));
                }
                catch
                {
                    // Перехватим возможные исключения
                    //ErrorSound();
                }


                if (_clientCount == MaxClients || _stopNetwork == true)
                {
                    break;
                }

            }
        }
        
        /// Отправка сообщений клиентам
        /// text текст сообщения
        /// skipindex индекс клиента которому не посылается сообщение
        void SendToClients(string text)
        {
            for (int j = 0; j < MaxClients; j++)
            {
                if (clients[j] != null)
                {
                    // Подготовка и запуск асинхронной отправки сообщения.
                    NetworkStream ns = clients[j].GetStream();

                    //MessageBox.Show(j.ToString());
                    Thread.Sleep(10);
                    byte[] myReadBuffer = Encoding.Default.GetBytes(text);
                    ns.Write(myReadBuffer, 0, myReadBuffer.Length);

                }
            }
        }

        // Извлечение сообщения от клиента и ретрансляция полученного 
        // сообщения другим клиентам
        void ReceiveRun()
        {
            while (true)
            {
                for (int i = 0; i < MaxClients; i++)
                {
                    string s = null;
                    if (clients[i] != null)
                    {
                        // Подготовка и запуск асинхронной отправки сообщения.
                        NetworkStream ns = clients[i].GetStream();
                        
                        ns.Flush();

                        byte[] MessageBuffer = Encoding.Default.GetBytes("turn");
                        ns.Write(MessageBuffer, 0, MessageBuffer.Length);

                        ns.Flush();

                        byte[] buffer = new byte[clients[i].Available];
                        ns.Read(buffer, 0, buffer.Length);
                        s = Encoding.Default.GetString(buffer);

                        if (buffer.Length == 0)
                        {
                            ns.Read(buffer, 0, buffer.Length);
                            s = Encoding.Default.GetString(buffer);
                            i--;
                            continue;
                        }


                        if (s != null)
                        {
                            if (!checkAnswer(s))
                            {
                                byte[] LoseBuffer = Encoding.Default.GetBytes("lose");
                                ns.Write(LoseBuffer, 0, LoseBuffer.Length);
                                SendToClients("№" + (i).ToString() + " Выбыл");
                                clients[i] = null;
                                _clientCount--;
                                Invoke(new UpdateClientsDisplayDelegate(UpdateClientsDisplay));
                            }
                            else
                            {
                                ns.Flush();

                                if (s.Contains("Leave"))
                                {
                                    clients[i] = null;
                                    _clientCount--;
                                    Invoke(new UpdateClientsDisplayDelegate(UpdateClientsDisplay));
                                }
                                // Данный метод, хотя и вызывается в отдельном потоке (не в главном),
                                // но находит родительский поток и выполняет делегат указанный в качестве параметра 
                                // в главном потоке, безопасно обновляя интерфейс формы.
                                Invoke(new UpdateReceiveDisplayDelegate(UpdateReceiveDisplay), new object[] { i, s });

                                // Принятое сообщение от клиента перенаправляем всем клиентам
                                s = "№" + (i).ToString() + ": " + s;
                                
                                SendToClients(s);
                                s = String.Empty;
                            }

                            MessageBuffer = Encoding.Default.GetBytes("next");
                            ns.Write(MessageBuffer, 0, MessageBuffer.Length);
                        }
                        else
                        {
                            continue;
                        }
                    }
                    Thread.Sleep(100);
                }
            }
        }

        
        bool checkAnswer(string message)
        {
            if (CityNames.Contains(message) || listBox1.Items.Count == 0)
            {
                if (listBox1.Items.Count == 0)
                {
                    lastCity = message;
                    return true;
                }else if (listBox1.Items.Count > 0 && message[0] == lastCity.ToUpper()[lastCity.Length - 1])
                {
                    lastCity = message;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        private void StopGame_Click(object sender, EventArgs e)
        {
            readThread.Abort();
        }
    }
}