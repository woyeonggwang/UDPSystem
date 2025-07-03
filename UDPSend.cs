using UnityEngine;
using System.Collections;

using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

public class UDPSend : MonoBehaviour
{
    [SerializeField]
    private string IP;

    [SerializeField]
    private int port;

    IPEndPoint remoteEndPoint;
    UdpClient client;
    TcpClient clientTCP;

    private void OnEnable()
    {
        IP = ProjectManager.instance.uIp;
        port = int.Parse(ProjectManager.instance.uPort);
    }

    public void Start()
    {
        remoteEndPoint = new IPEndPoint(IPAddress.Parse(IP), port);
        client = new UdpClient();
        clientTCP = new TcpClient();
    }

    public void SendString(string message)
    {
        try
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            client.Send(data, data.Length, remoteEndPoint);
        }
        catch (Exception err)
        {
            print(err.ToString());
        }
    }
}