using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class Movingfloor : NetworkBehaviour
{
    public float movingrange;
    public Vector3 movingdirection;
    public float speed;
    private float time;
    private Vector3 Edge1;
    private Vector3 Edge2;
    public  bool isDirection;
    private bool isStop = false;

    // Start is called before the first frame update
    void Start()
    {
        Edge1 = transform.position + movingdirection * movingrange;
        Edge2 = transform.position - movingdirection * movingrange;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isStop == false)
        {
        time += Time.deltaTime* speed;
        if(time >= 1)
        {
            time = 0;
            isDirection = !isDirection;
        }
        if(isDirection == true)
        {
            transform.position = Vector3.Lerp(Edge1,Edge2,time);
        }
        else
        {
            transform.position = Vector3.Lerp(Edge2,Edge1,time);
        }
        }
    }
    public void StopMove()
    {
        Debug.Log("AAA");
        isStop = !isStop;
    }
}
