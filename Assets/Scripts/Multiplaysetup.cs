using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiplaysetup : MonoBehaviour
{
    // Start is called before the first frame update
    public Mirror.NetworkManager manager;
    public GameObject Vr;
    
    public GameObject Button;
    public GameObject Cube;
    void Start()
    {
    }
    public void Vrclient()
    {
        
        Invoke("DestroyVr",1f);
       
        // Destroy(Button);
        // Destroy(Vr);
          }
    void DestroyVr()
    {
  manager.StartClient();       
    }
    public void Host()
    {
        Destroy(Vr);
        manager.StartHost();  
    }
    public void ChangePrefab()
    {
        manager.playerPrefab = Cube;
    }
}
