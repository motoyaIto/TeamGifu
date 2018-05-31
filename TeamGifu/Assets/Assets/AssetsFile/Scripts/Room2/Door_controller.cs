using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_controller : MonoBehaviour {
    public LightGimick1 gimick1;
    public LightGimick2 gimick2;
    public LightGimick3 gimick3;
    public Room2_GimicOn room2;
    private void Start()
    {
        gimick1.GetComponent<LightGimick1>();
        gimick2.GetComponent<LightGimick2>();
        gimick3.GetComponent<LightGimick3>();

        // room2 = new Room2_GimicOn();
    }
    public void Update()
    {
        if (gimick1.clear_Flag&& gimick2.clear_Flag && gimick3.clear_Flag )
        {
            room2.LockFlagParm = true;
        }
    }
}
