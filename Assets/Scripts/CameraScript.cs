using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CameraScript : NetworkBehaviour
{
    // Start is called before the first frame update
    public Vector3 Pojition;
    public Quaternion quaternion;
    [SerializeField]
    public GameObject Camera;
    private GameObject c;
    public List<Vector3> list;
    public List<Quaternion> qlist;
    private int count = 0;
    private bool on_off = true;
    void Start()
    {
        if(isLocalPlayer == true)
        {
        transform.position = Pojition;
        transform.rotation = quaternion;
        c = Instantiate(Camera,transform.position,Quaternion.identity);
        c.transform.position = list[0];
        c.transform.rotation = qlist[0];
        GameObject.FindWithTag("Vr").gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.X)  && on_off == true && isLocalPlayer == true)
        {
            on_off = false;
            Invoke("On",0.2f);
            count += 1;
            if(count >= list.Count || count > qlist.Count)
            {
                count -= list.Count;
            }
            c.transform.position = list[count];
            c.transform.rotation = qlist[count];
        }
        if(Input.GetKey(KeyCode.Z)  && on_off == true)
        {
            on_off = false;
            Invoke("On",0.2f);
            count -= 1;
            if(count <= -1|| count <= -1)
            {
                count += list.Count;
            }
            c.transform.position = list[count];
            c.transform.rotation = qlist[count];
        }
    }
    void On()
    {
        on_off = true;
    }
}