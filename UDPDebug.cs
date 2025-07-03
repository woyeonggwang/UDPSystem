using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UDPDebug : MonoBehaviour
{
    UDPSend udpSend;
    private string[] removeParenL;
    private string[] removeParenR;
    private string[] colorStr;
    private float[] colorValue;
    //public ColorChange colorChange;
    public ReadUdpData reader;
    void Start()
    {
        UDPReceive.OnUDPMessage += LogMessage;
        udpSend = gameObject.GetComponent<UDPSend>();
        StartCoroutine(SendDummyText());
        removeParenL = new string[2];
        removeParenR = new string[2];
        colorStr = new string[4];
        colorValue = new float[4];
    }

    private void Update()
    {
        //SendMsg("s0");
    }

    public void SendMsg(string msg)
    {
        udpSend.SendString(msg);
    }

    private void LogMessage(string obj)
    {
        Debug.Log("Received: " + obj);
        reader.ReadData(obj);
        ProjectManager.instance.MsgReceiver(obj);

    }

    IEnumerator SendDummyText()
    {
        while (true)
        {
            //udpSend.SendString("S0");
            yield return new WaitForSeconds(1);
        }
    }

}