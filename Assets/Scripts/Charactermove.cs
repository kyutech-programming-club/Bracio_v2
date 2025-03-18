// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Charactermove : MonoBehaviour
// {
//     // Start is called before the first frame update
//         // Start is called before the first frame update    public float speed = 3.0f;
//      public float speed = 3.0f;
//     public float rotationSpeed = 90.0f;

//     private Rigidbody rb;
//     private Transform vrCamera;

//     void Start()
//     {
//         rb = GetComponent<Rigidbody>();
//         vrCamera = Camera.main.transform;
//         transform.position = new Vector3(0,2,0);
//     }

//     void Update()
//     {
//         Vector2 primaryAxis = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
//         float rotationInput = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).x;

//         // Movement direction based on camera
//         Vector3 moveDirection = vrCamera.forward * primaryAxis.y + vrCamera.right * primaryAxis.x;
//         moveDirection.y = 0;
//         moveDirection.Normalize();

//         rb.MovePosition(rb.position + moveDirection * speed * Time.deltaTime);

//         // Smooth rotation
//         if (Mathf.Abs(rotationInput) > 0.1f)
//         {
//             Quaternion rotation = Quaternion.Euler(0, rotationInput * rotationSpeed * Time.deltaTime, 0);
//             rb.MoveRotation(rb.rotation * rotation);
//         }
//     }
// }
