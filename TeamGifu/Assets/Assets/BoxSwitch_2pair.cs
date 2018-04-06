using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSwitch_2pair : MonoBehaviour {

    private GameObject obj1;
    private GameObject obj2;
    private BoxSwitch obj1_script;
    private BoxSwitch obj2_script;
    // Use this for initialization
    void Start () {
        obj1 = GameObject.Find("swich_1") as GameObject;

        obj2 = GameObject.Find("swich_2") as GameObject;

        obj1_script = obj1.GetComponent<BoxSwitch>();
        obj2_script = obj2.GetComponent<BoxSwitch>();
    }
	
	// Update is called once per frame
	void Update () {

        if (obj1_script.GetOnSwitch() == true && obj2_script.GetOnSwitch())
        {
            if (this.transform.localScale.y >= 0.5f)
            {
                Vector3 lostScale = new Vector3(0f, 0.01f, 0f);
                this.transform.localScale -= lostScale;
            }
        }
	}


}
