using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_controller : MonoBehaviour {
    public GameObject[] obj;
    public GameObject door;
    public Room2_GimicOn room2;
    private void Start()
    {
       // room2 = new Room2_GimicOn();
    }
    public void Update()
    {
        if (obj[0].GetComponent<Door_Open>().open_Flag)
        {
            if (obj[1].GetComponent<Door_Open>().open_Flag)
            {
                if (obj[2].GetComponent<Door_Open>().open_Flag)
                {
                    Debug.Log("ここでドア開けれるようになるで");
                    room2.LockFlagParm = true;
                   // door.GetComponent<Automatic_door>().Door_Control();
                }
            }
        }
    }
}
