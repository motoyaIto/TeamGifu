using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_controller : MonoBehaviour {
    public GameObject[] obj;
    public Room2_GimicOn room2;
    private void Start()
    {
       // room2 = new Room2_GimicOn();
    }
    public void Update()
    {
        if (obj[0].GetComponent<Door_Open>().Lock_State & 
            obj[1].GetComponent<Door_Open>().Lock_State & 
            obj[2].GetComponent<Door_Open>().Lock_State)
        {
            room2.LockFlagParm = true;
        }
    }
}
