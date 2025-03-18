using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class Changeprefab : MonoBehaviour
{
    // Start is called before the first frame update
    public VRNetworkManager managers;
    public GameObject Vr;
    public void Change()
    {
        Debug.Log("AA");
        managers.StartHost();
        managers.playerPrefab = Vr;
    }
}
