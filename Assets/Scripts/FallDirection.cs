using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDirection : MonoBehaviour
{
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Fall(Vector3 direction, float force)
    {
        rb.useGravity = true;
        rb.isKinematic = false;
        rb.AddForce(direction.normalized * force, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<FallDirection>().Fall(new Vector3(1, -1, 0), 10f);
        }
    }
}
