using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class doorOpen : MonoBehaviour
{
    public bool isOpen = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenDoor()
    {
        if(isOpen == false)
        {
            this.gameObject.transform.Rotate(new Vector3(0, 0,200));
            isOpen = true;
        }
    }
}
