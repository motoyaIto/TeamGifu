using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Up_floor : MonoBehaviour {

    [SerializeField]
    GameObject BoxSwitch;

    private BoxSwitch_2pair BoxSwitch_2_Script;
    private BoxSwitch BoxSwitch_Script;

    [SerializeField]
    private float GoalPosY;

    
	// Use this for initialization
	void Start () {
        BoxSwitch_2_Script = BoxSwitch.GetComponent<BoxSwitch_2pair>();
       // BoxSwitch_Script = BoxSwitch.GetComponent<BoxSwitch>();

        
    }
	
	// Update is called once per frame
	void Update () {
		if(BoxSwitch_2_Script.GetOn_switch() == true /*|| BoxSwitch_Script.GetOnSwitch() == true*/)
        {
            if(this.transform.position.y <= GoalPosY)
            {
                Vector3 Move = new Vector3(0f, 0.01f, 0f);
                this.transform.position += Move;
            }
        }
	}
}
