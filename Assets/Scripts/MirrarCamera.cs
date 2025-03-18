using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Mirror;
public class MirrarCamera : NetworkBehaviour
{
    public void Start()
    {
        // GameObject vr = GameObject.FindWithTag("Vr");
        // if(vr != null)
        // {
        //     Destroy(vr);
        // }
        if(isLocalPlayer == false)
        {
            gameObject.SetActive(false);
        }
    }
    public void FixedUpdate()
    {
        if(isLocalPlayer == false)
        {
            gameObject.SetActive(false);
        }
    }
}
