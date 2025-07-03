using UnityEngine;
using System.Collections;
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class UDPReceive : MonoBehaviour
{
    Thread receiveThread;
    UdpClient client;

    [SerializeField]
    private int port;
    IPEndPoint anyIP;
    [SerializeField]
    private bool PrintDebug = true;

    public static event Action<string> OnUDPMessage;

    private void OnEnable()
    {
        port = int.Parse(ProjectManager.instance.uPort);
        client = new UdpClient(port);
    }

    public void Start()
    {
        init();
        OnUDPMessage += LogMessage;
    }

    private void LogMessage(string obj)
    {
        if (PrintDebug)
        { Debug.Log("Received: " + obj); }
        //transform.GetChild(0).GetComponent<ReadUdpData>().obj = obj;
        //transform.GetChild(0).gameObject.SetActive(true);
        
    }

    private void init()
    {
        receiveThread = new Thread(
            new ThreadStart(ReceiveData));

        receiveThread.IsBackground = true;
        receiveThread.Start();
    }

    private void ReceiveData()
    {
        
        while (true)
        {
            try
            {
                anyIP = new IPEndPoint(IPAddress.Any, 0);
                byte[] data = client.Receive(ref anyIP);

                string text = Encoding.UTF8.GetString(data);
                OnUDPMessage(text);
            }
            catch (Exception err)
            {
                print(err.ToString());
            }
        }
    }

}