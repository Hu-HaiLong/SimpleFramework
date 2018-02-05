using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using UnityEngine;
using Yishimu;
/*
 * 
 *Socket客户端通信类
 * 
 */
public class SocketHelper : SingleTon<SocketHelper>
{

    //private static SocketHelper socketHelper = new SocketHelper();

    private Socket socket;

    ////单例模式
    //public static SocketHelper GetInstance()
    //{
    //    return socketHelper;
    //}

    public SocketHelper()
    {

        //采用TCP方式连接
        socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        //服务器IP地址
        IPAddress address = IPAddress.Parse("192.168.50.69");

        //服务器端口
        IPEndPoint endpoint = new IPEndPoint(address, 8000);

        //异步连接,连接成功调用connectCallback方法
        IAsyncResult result = socket.BeginConnect(endpoint, new AsyncCallback(ConnectCallback), socket);

        //这里做一个超时的监测，当连接超过5秒还没成功表示超时
        bool success = result.AsyncWaitHandle.WaitOne(5000, true);
        if (!success)
        {
            //超时
            Closed();
            Debug.Log("connect Time Out");
        }
        else
        {
            //与socket建立连接成功，开启线程接受服务端数据。
            Thread thread = new Thread(new ThreadStart(ReceiveSorket));
            thread.IsBackground = true;
            thread.Start();
        }

    }

    private void ConnectCallback(IAsyncResult asyncConnect)
    {
        Debug.Log("connect success");
    }

    private void ReceiveSorket()
    {
        //在这个线程中接受服务器返回的数据
        while (true)
        {

            if (!socket.Connected)
            {
                //与服务器断开连接跳出循环
                Debug.Log("Failed to clientSocket server.");
                socket.Close();
                break;
            }
            try
            {
                //接受数据保存至bytes当中
                byte[] bytes = new byte[4096];
                //Receive方法中会一直等待服务端回发消息
                //如果没有回发会一直在这里等着。
                int i = socket.Receive(bytes);
                if (i <= 0)
                {
                    socket.Close();
                    break;
                }

                //// 反序列化
                string jsonStr = System.Text.Encoding.Default.GetString(bytes);
                //Debug.Log(jsonStr);
                //UserData t1 = new UserData();
                //t1 = JsonManager.Instance.JsonString2Obj<UserData>(jsonStr);
                //Debug.Log(t1.id + "  " + t1.level + "  " + t1.money + "  " + t1.name);
            }
            catch (Exception e)
            {
                Debug.Log("Failed to clientSocket error." + e);
                socket.Close();
                break;
            }
        }
    }

    //关闭Socket
    public void Closed()
    {
        if (socket != null && socket.Connected)
        {
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
        }
        socket = null;
    }
    //向服务端发送一条字符串
    //一般不会发送字符串 应该是发送数据包
    public void SendMessage(string str)
    {
        byte[] msg = Encoding.UTF8.GetBytes(str);

        if (!socket.Connected)
        {
            socket.Close();
            return;
        }
        try
        {
            IAsyncResult asyncSend = socket.BeginSend(msg, 0, msg.Length, SocketFlags.None, new AsyncCallback(SendCallback), socket);
            bool success = asyncSend.AsyncWaitHandle.WaitOne(5000, true);
            if (!success)
            {
                socket.Close();
                Debug.Log("Failed to SendMessage server.");
            }
        }
        catch
        {
            Debug.Log("send message error");
        }
    }



    private void SendCallback(IAsyncResult asyncConnect)
    {
        Debug.Log("send success");
    }


}