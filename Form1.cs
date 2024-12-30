using MOAP;
using System.Net.Sockets;
using System.Net;
using Microsoft.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Data;
using System.Runtime.Serialization.Formatters.Binary;
using static System.Net.WebRequestMethods;
using System;
using System.IO.Compression;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Cryptography;

namespace MOAP_CLIENT_APP
{
    public partial class Form1 : Form
    {
        string filePath = string.Empty;
        const int CHUNK_SIZE = 4096;
        string[] args = Environment.GetCommandLineArgs();
        string serverIP = string.Empty;
        const int serverPort = 5425;

        //����
        string userid;
        string dtRecvTime;
        string dtEndTime;
        string serverIp;
        string serviceType = "";
        string folderPath = "";

        public Form1()
        {
            InitializeComponent();
            textBox3.Text = serverPort.ToString();
            textBox6.Text = serverPort.ToString();
            textBox8.Text = serverPort.ToString();

        }

        private void FileSearch_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    filePath = ofd.FileName;
                    FilePathDir.Text = filePath;
                }
            }
        }

        private void FileConnect_Click(object sender, EventArgs e)
        {
            serverIP = textBox2.Text;
            if (serverIP == "" || serverIP.Length == 0)
            {
                MessageBox.Show("���� IP �������ּ���");
                return;
            }
            if (filePath == "" || filePath.Length == 0)
            {
                MessageBox.Show("������ ������ �������ּ���");
                return;
            }

            Thread FileThreadHandler = new Thread(new ParameterizedThreadStart(FileTcpHandler));
            FileThreadHandler.Start();



        }

        private void FileTcpHandler(object? obj)
        {
            try
            {
                IPEndPoint clientAddress = new IPEndPoint(0, 0);
                IPEndPoint serverAddress = new IPEndPoint(IPAddress.Parse(serverIP), serverPort);
                uint msgId = 0;

                MOAP.Message reqMsg = new MOAP.Message();
                reqMsg.Body = new BodyRequest()
                {
                    FILESIZE = new FileInfo(filePath).Length,
                    FILENAME = System.Text.Encoding.Default.GetBytes(filePath)
                };
                reqMsg.Header = new Header()
                {
                    MOAID = msgId++,
                    MOATYPE = CONSTANTS.REQ_FILE_SEND,
                    BODYLEN = (uint)reqMsg.Body.GetSize(),
                    FRAGMENTED = CONSTANTS.NOT_FRAGMENTED,
                    LASTMSG = CONSTANTS.LASTMSG,
                    SEQ = 0
                };

                TcpClient client = new TcpClient(clientAddress);
                client.Connect(serverAddress);

                NetworkStream stream = client.GetStream();

                MOAP.MessageUtil.Send(stream, reqMsg);

                MOAP.Message rspMsg = MOAP.MessageUtil.Receive(stream); //���� ���� ����
             
                if (rspMsg.Header.MOATYPE != CONSTANTS.REP_FILE_SEND)
                {
                    if (textBox4.InvokeRequired)
                    {
                        textBox4.Invoke(new EventHandler(delegate
                        {
                            textBox4.Text = "�������� ���� ������ �ƴմϴ�. " + rspMsg.Header.MOATYPE.ToString();
                        }));
                    }
                    return;
                }

                if (((BodyResponse)rspMsg.Body).RESPONSE == CONSTANTS.DENIED)
                {
                    if (textBox4.InvokeRequired)
                    {
                        textBox4.Invoke(new EventHandler(delegate
                        {
                            textBox4.Text = "�������� ���� ������ �ź��߽��ϴ�.";
                        }));
                    }
                    return;
                }

                if (textBox4.InvokeRequired)
                {
                    textBox4.Invoke(new EventHandler(delegate
                    {
                        textBox4.Text = "���� ���� ���� ��û ����";
                    }));
                }

                using (Stream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    byte[] rbytes = new byte[CHUNK_SIZE];
                    long readValue = BitConverter.ToInt64(rbytes, 0);

                    int totalRead = 0;
                    ushort msgSeq = 0;
                    byte fragmented = (fileStream.Length < CHUNK_SIZE) ? CONSTANTS.NOT_FRAGMENTED : CONSTANTS.FRAGMENTED;

                    while (totalRead < fileStream.Length)
                    {
                        int read = fileStream.Read(rbytes, 0, CHUNK_SIZE);
                        totalRead += read;
                        MOAP.Message fileMsg = new MOAP.Message();

                        byte[] sendBytes = new byte[read];
                        Array.Copy(rbytes, 0, sendBytes, 0, read);

                        fileMsg.Body = new BodyData(sendBytes);
                        fileMsg.Header = new Header()
                        {
                            MOAID = msgId,
                            MOATYPE = CONSTANTS.FILE_SEND_DATA,
                            BODYLEN = (uint)fileMsg.Body.GetSize(),
                            FRAGMENTED = fragmented,
                            LASTMSG = (totalRead < fileStream.Length) ? CONSTANTS.NOT_LASTMSG : CONSTANTS.LASTMSG,
                            SEQ = msgSeq++
                        };

                        Console.WriteLine("sendBytes.Length : " + sendBytes.Length);
                        MessageUtil.Send(stream, fileMsg);
                    }

                    MOAP.Message rstMsg = MOAP.MessageUtil.Receive(stream);                       
                   
                    BodyResult result = ((BodyResult)rstMsg.Body);
                    if (textBox5.InvokeRequired)
                    {
                        if (result.RESULT == CONSTANTS.SUCCESS)
                        {
                            textBox5.Invoke(new EventHandler(delegate
                            {
                                textBox5.Text = "���� ���� ����";
                            }));
                        }
                        else
                        {
                            textBox5.Invoke(new EventHandler(delegate
                            {
                                textBox5.Text = "���� ���� ����";
                            }));
                        }
                    }                   
                }           
        }catch (SocketException se){
            MessageBox.Show("���Ͽ��� : " + se.Message);
        }
    }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox3.Text = serverPort.ToString();
            textBox6.Text = serverPort.ToString();
            textBox8.Text = serverPort.ToString();
            textBox4.Text = "���� �ȵ�";
            textBox11.Text = "���� �ȵ�";
            textBox15.Text = "���� �ȵ�";
        }

        private void MsgSocket_Click(object sender, EventArgs e)
        {
            textBox11.Text = "";
            textBox12.Text = "";

            folderPath = System.IO.Directory.GetCurrentDirectory() + @"\MsgDataFolder";
            DirectoryInfo di = new DirectoryInfo(folderPath);
            if (di.Exists == false)
            {
                di.Create();
            }

            if (textBox10.Text == "" || textBox10.Text.Length == 0)
            {
                MessageBox.Show("���̵�� �־��ּž� �ؿ�");
                return;
            }
            if (textBox7.Text == "" || textBox7.Text.Length == 0)
            {
                MessageBox.Show("���� IP�� �Է��ؾ� �մϴ�.");
                return;
            }

            userid = textBox10.Text.Trim();
            dtRecvTime = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            dtEndTime = dateTimePicker2.Value.ToString("yyyy-MM-dd");
            serverIp = textBox7.Text.Trim();

            try
            {
                lock (DBConn.DBc)
                {
                    if (!DBConn.IsDBConnected)
                    {
                        Console.WriteLine("DB������ Ȯ���ϼ���");
                        return;
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = DBConn.DBc;
                        cmd.CommandText = string.Format("Select sservicetype from Userlist with (nolock) where suserid='{0}'", userid);

                        SqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            serviceType = rdr["sservicetype"] as string;
                        }
                        rdr.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Thread MsgThreadHandler = new Thread(MsgTcpHandler);
            MsgThreadHandler.Start();
        }

        private void MsgTcpHandler(object? obj)
        {
            try
            {
                IPEndPoint clientAddress = new IPEndPoint(0, 0);
                IPEndPoint serverAddress = new IPEndPoint(IPAddress.Parse(serverIp), serverPort);
                uint msgId = 0;

                if (serviceType.Equals("ASP"))
                {
                    serviceType = "ASP";
                }
                else
                {
                    serviceType = "MOA";
                }

                MOAP.Message reqMsg = new MOAP.Message();
                reqMsg.Body = new MsgBodyRequest()
                {
                    USERID = System.Text.Encoding.Default.GetBytes(userid),
                    REQDATE = System.Text.Encoding.Default.GetBytes(dtRecvTime),
                    ENDDATE = System.Text.Encoding.Default.GetBytes(dtEndTime),
                    SERVICE = System.Text.Encoding.Default.GetBytes(serviceType)
                };
                reqMsg.Header = new Header()
                {
                    MOAID = msgId++,
                    MOATYPE = CONSTANTS.REQ_MSG_SEND,
                    BODYLEN = (uint)reqMsg.Body.GetSize(),
                    FRAGMENTED = CONSTANTS.NOT_FRAGMENTED,
                    LASTMSG = CONSTANTS.LASTMSG,
                    SEQ = 0
                };

                TcpClient client = new TcpClient(clientAddress);
                client.Connect(serverAddress);

                NetworkStream stream = client.GetStream();

                MessageUtil.Send(stream, reqMsg); //���۰�� ��û

                MOAP.Message rspMsg;
                uint? dataMsgId = null;
                ushort prevSeq = 0;
                int fileflag = 0;
                while ((rspMsg = MOAP.MessageUtil.Receive(stream)) != null)
                {
                    if (rspMsg.Header.MOATYPE == CONSTANTS.REP_FILE_SEND)
                    {
                        if (textBox11.InvokeRequired)
                        {
                            textBox11.Invoke(new MethodInvoker(delegate
                            {
                                textBox11.Text = "�����κ��� ������ �źεǾ����ϴ�";
                            }));
                        }
                        break;
                    }
                    else if (rspMsg.Header.MOATYPE != CONSTANTS.MSG_SEND_DATA && rspMsg.Header.MOATYPE != CONSTANTS.REP_FILE_SEND)
                    {
                        if (textBox11.InvokeRequired)
                        {
                            textBox11.Invoke(new MethodInvoker(delegate
                            {
                                textBox11.Text = "�߸��� ��û���� �źεǾ����ϴ�";
                            }));
                        }
                        break;
                    }
                    if (dataMsgId == null)
                    {
                        dataMsgId = rspMsg.Header.MOAID;
                    }
                    else
                    {
                        if (dataMsgId != rspMsg.Header.MOAID)
                        {
                            if (textBox11.InvokeRequired)
                            {
                                textBox11.Invoke(new MethodInvoker(delegate
                                {
                                    textBox11.Text = "������ ��û ��� ���̵� ����";
                                }));
                            }

                            break;
                        }
                    }
                    if (prevSeq++ != rspMsg.Header.SEQ)
                    {
                        string msg = string.Format("{0}, {1}", prevSeq, rspMsg.Header.SEQ);
                        if (textBox11.InvokeRequired)
                        {
                            textBox11.Invoke(new MethodInvoker(delegate
                            {
                                textBox11.Text = "������ ��û ���� ���� : " + msg;
                            }));
                        }
                        break;
                    }
                    if (textBox11.InvokeRequired)
                    {
                        textBox11.Invoke(new MethodInvoker(delegate
                        {
                            textBox11.Text = "���� ��û ���� ����";
                        }));
                    }

                    byte[] temp = rspMsg.Body.GetBytes();
                    DataSet ds = DecompressDataSet(temp);
                    DataTable dt = ds.Tables[0];

                    var filePath = folderPath + @"\" + userid + "(" + dtRecvTime + "~" + dtEndTime + ")_���� ���۰��.txt";

                    if (!System.IO.File.Exists(filePath))
                    {
                        fileflag = 1;
                        using (StreamWriter sw = System.IO.File.CreateText(filePath))
                        {
                            sw.WriteLine("����̵�\t\t\t\t���̵�\t�߽Ź�ȣ\t�ѹ߼۰�\t������\t���а�");
                            foreach (DataRow row in dt.Rows)
                            {
                                sw.WriteLine(row["sJobID"].ToString() + "\t" + row["sUserID"].ToString() + "\t" + row["sFromInfo"].ToString() + "\t" + row["ntotalcnt"].ToString()
                                    + "\t" + row["nsuccesscnt"].ToString() + "\t\t" + row["nfailcnt"].ToString());
                            }
                        }
                    }
                    else
                    {
                        fileflag = 1;
                        MessageBox.Show("�̹� ������ �����մϴ�");
                    }
                    if (textBox12.InvokeRequired)
                    {
                        textBox12.Invoke(new MethodInvoker(delegate
                        {
                            textBox12.Text = "���۰�� ��ȸ �Ϸ�";
                        }));
                    }
                    MOAP.Message rstMsg = new MOAP.Message();
                    rstMsg.Body = new MSGBodyResult()
                    {
                        MOAID = (uint)dataMsgId,
                        RESULT = CONSTANTS.SUCCESS
                    };

                    rstMsg.Header = new Header()
                    {
                        MOAID = msgId++,
                        MOATYPE = CONSTANTS.MSG_SEND_RES,
                        BODYLEN = (uint)rstMsg.Body.GetSize(),
                        FRAGMENTED = CONSTANTS.NOT_FRAGMENTED,
                        LASTMSG = CONSTANTS.LASTMSG,
                        SEQ = 0
                    };
                    if (fileflag > 0)
                    {
                        MessageUtil.Send(stream, rstMsg);
                        Console.WriteLine("����� ������");
                    }
                    else
                    {
                        rstMsg.Body = new BodyResult()
                        {
                            MOAID = rspMsg.Header.MOAID,
                            RESULT = CONSTANTS.FAIL
                        };
                        MessageUtil.Send(stream, rstMsg);
                    }

                }
            }
            catch (SocketException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private DataSet DecompressDataSet(byte[] temp)
        {
            MemoryStream mem = new MemoryStream(temp);
            GZipStream zip = new GZipStream(mem, CompressionMode.Decompress);
            DataSet dataset = new DataSet();
            dataset.ReadXml(zip, XmlReadMode.ReadSchema);
            zip.Close();
            mem.Close();
            return dataset;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox14.Text = "";
            textBox15.Text = "";

            folderPath = System.IO.Directory.GetCurrentDirectory() + @"\FaxDataFolder";
            DirectoryInfo di = new DirectoryInfo(folderPath);
            if (di.Exists == false)
            {
                di.Create();
            }

            if (textBox13.Text == "" || textBox13.Text.Length == 0)
            {
                MessageBox.Show("���̵�� �־��ּž� �ؿ�");
                return;
            }
            if (textBox9.Text == "" || textBox9.Text.Length == 0)
            {
                MessageBox.Show("���� IP�� �Է��ؾ� �մϴ�.");
                return;
            }

            userid = textBox13.Text.Trim();
            dtRecvTime = dateTimePicker4.Value.ToString("yyyy-MM-dd");
            dtEndTime = dateTimePicker3.Value.ToString("yyyy-MM-dd");
            serverIp = textBox9.Text.Trim();

            try
            {
                lock (DBConn.DBc)
                {
                    if (!DBConn.IsDBConnected)
                    {
                        Console.WriteLine("DB������ Ȯ���ϼ���");
                        return;
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = DBConn.DBc;
                        cmd.CommandText = string.Format("Select sservicetype from Userlist with (nolock) where suserid='{0}'", userid);

                        SqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            serviceType = rdr["sservicetype"] as string;
                        }
                        rdr.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Thread FaxThreadHandler = new Thread(FaxTcpHandler);
            FaxThreadHandler.Start();
        }

        private void FaxTcpHandler(object? obj)
        {
            try
            {
                IPEndPoint clientAddress = new IPEndPoint(0, 0);
                IPEndPoint serverAddress = new IPEndPoint(IPAddress.Parse(serverIp), serverPort);
                uint msgId = 0;

                if (serviceType.Equals("ASP"))
                {
                    serviceType = "ASP";
                }
                else
                {
                    serviceType = "MOA";
                }

                MOAP.Message reqMsg = new MOAP.Message();
                reqMsg.Body = new FAXBodyRequest()
                {
                    USERID = System.Text.Encoding.Default.GetBytes(userid),
                    REQDATE = System.Text.Encoding.Default.GetBytes(dtRecvTime),
                    ENDDATE = System.Text.Encoding.Default.GetBytes(dtEndTime),
                    SERVICE = System.Text.Encoding.Default.GetBytes(serviceType)
                };
                reqMsg.Header = new Header()
                {
                    MOAID = msgId++,
                    MOATYPE = CONSTANTS.REQ_FAX_SEND,
                    BODYLEN = (uint)reqMsg.Body.GetSize(),
                    FRAGMENTED = CONSTANTS.NOT_FRAGMENTED,
                    LASTMSG = CONSTANTS.LASTMSG,
                    SEQ = 0
                };

                TcpClient client = new TcpClient(clientAddress);
                client.Connect(serverAddress);

                NetworkStream stream = client.GetStream();

                MessageUtil.Send(stream, reqMsg); //���۰�� ��û

                MOAP.Message rspMsg;
                uint? dataMsgId = null;
                ushort prevSeq = 0;
                int fileflag = 0;
                while ((rspMsg = MOAP.MessageUtil.Receive(stream)) != null)
                {
                    if (rspMsg.Header.MOATYPE == CONSTANTS.REP_FILE_SEND)
                    {
                        if (textBox15.InvokeRequired)
                        {
                            textBox15.Invoke(new MethodInvoker(delegate
                            {
                                textBox15.Text = "�����κ��� ������ �źεǾ����ϴ�";
                            }));
                        }
                        break;
                    }
                    else if (rspMsg.Header.MOATYPE != CONSTANTS.FAX_SEND_DATA && rspMsg.Header.MOATYPE != CONSTANTS.REP_FILE_SEND)
                    {
                        if (textBox15.InvokeRequired)
                        {
                            textBox15.Invoke(new MethodInvoker(delegate
                            {
                                textBox15.Text = "�߸��� ��û���� �źεǾ����ϴ�";
                            }));
                        }
                        break;
                    }
                    if (dataMsgId == null)
                    {
                        dataMsgId = rspMsg.Header.MOAID;
                    }
                    else
                    {
                        if (dataMsgId != rspMsg.Header.MOAID)
                        {
                            if (textBox15.InvokeRequired)
                            {
                                textBox15.Invoke(new MethodInvoker(delegate
                                {
                                    textBox15.Text = "������ ��û ��� ���̵� ����";
                                }));
                            }

                            break;
                        }
                    }
                    if (prevSeq++ != rspMsg.Header.SEQ)
                    {
                        string msg = string.Format("{0}, {1}", prevSeq, rspMsg.Header.SEQ);
                        if (textBox15.InvokeRequired)
                        {
                            textBox15.Invoke(new MethodInvoker(delegate
                            {
                                textBox15.Text = "������ ��û ���� ���� : " + msg;
                            }));
                        }
                        break;
                    }
                    if (textBox15.InvokeRequired)
                    {
                        textBox15.Invoke(new MethodInvoker(delegate
                        {
                            textBox15.Text = "���� ��û ���� ����";
                        }));
                    }

                    byte[] temp = rspMsg.Body.GetBytes();
                    DataSet ds = DecompressDataSet(temp);
                    DataTable dt = ds.Tables[0];

                    var filePath = folderPath + @"\" + userid + "(" + dtRecvTime + "~" + dtEndTime + ")_�ѽ� ���۰��.txt";

                    if (!System.IO.File.Exists(filePath))
                    {
                        fileflag = 1;
                        using (StreamWriter sw = System.IO.File.CreateText(filePath))
                        {
                            sw.WriteLine("����̵�\t\t\t\t���̵�\t�߽Ź�ȣ\t�ѹ߼۰�\t������\t���а�");
                            foreach (DataRow row in dt.Rows)
                            {
                                sw.WriteLine(row["sJobID"].ToString() + "\t" + row["sUserID"].ToString() + "\t" + row["sFromInfo"].ToString() + "\t" + row["ntotalcnt"].ToString()
                                    + "\t" + row["nsuccesscnt"].ToString() + "\t\t" + row["nfailcnt"].ToString());
                            }
                        }
                    }
                    else
                    {
                        fileflag = 1;
                        MessageBox.Show("�̹� ������ �����մϴ�");
                    }
                    if (textBox14.InvokeRequired)
                    {
                        textBox14.Invoke(new MethodInvoker(delegate
                        {
                            textBox14.Text = "���۰�� ��ȸ �Ϸ�";
                        }));
                    }
                    MOAP.Message rstMsg = new MOAP.Message();
                    rstMsg.Body = new FAXBodyResult()
                    {
                        MOAID = (uint)dataMsgId,
                        RESULT = CONSTANTS.SUCCESS
                    };

                    rstMsg.Header = new Header()
                    {
                        MOAID = msgId++,
                        MOATYPE = CONSTANTS.FAX_SEND_RES,
                        BODYLEN = (uint)rstMsg.Body.GetSize(),
                        FRAGMENTED = CONSTANTS.NOT_FRAGMENTED,
                        LASTMSG = CONSTANTS.LASTMSG,
                        SEQ = 0
                    };
                    if (fileflag > 0)
                    {
                        MessageUtil.Send(stream, rstMsg);                        
                    }
                    else
                    {
                        rstMsg.Body = new BodyResult()
                        {
                            MOAID = rspMsg.Header.MOAID,
                            RESULT = CONSTANTS.FAIL
                        };
                        MessageUtil.Send(stream, rstMsg);
                    }

                }
            }
            catch (SocketException e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
