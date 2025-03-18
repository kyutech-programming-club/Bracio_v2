using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class FollowCamera : NetworkBehaviour
{
    public GameObject Camera;
    private GameObject FollowObj;
    void Start()
    {
        FollowObj = Instantiate(Camera,transform.position,transform.rotation);
    }
    void Update()
    {
        if(isLocalPlayer == false)
        {
        FollowObj.transform.position = transform.position;
        FollowObj.transform.rotation = transform.rotation;
        }
    }
}
