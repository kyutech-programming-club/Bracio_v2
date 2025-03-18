using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MirrarText : MonoBehaviour
{
    public  Mirror.NetworkManager manager;
    private TextMeshProUGUI textMeshProUGUI;
    // Start is called before the first frame update
    void Start()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
            if (Mirror.NetworkServer.active && Mirror.NetworkClient.active)
            {
                // host mode
               textMeshProUGUI.text = $"<b>Host</b>: running via {Mirror.Transport.active}";
            }
            else if (Mirror.NetworkServer.active)
            {
                // server only
                textMeshProUGUI.text =$"<b>Server</b>: running via {Mirror.Transport.active}";
            }
            else if (Mirror.NetworkClient.isConnected)
            {
                // client only
                textMeshProUGUI.text =$"<b>Client</b>: connected to {manager.networkAddress} via {Mirror.Transport.active}";
            }
            else
            {
                textMeshProUGUI.text = manager.networkAddress.ToString();
                
            }
                if (Mirror.NetworkClient.isConnected && !Mirror.NetworkClient.ready)
            {
                textMeshProUGUI.text += "GG";
            }
 

    }
}
