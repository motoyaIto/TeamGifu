using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSwitch_2pair : MonoBehaviour {

    [SerializeField]
    private GameObject obj1;
    [SerializeField]
    private GameObject obj2;
    private BoxSwitch obj1_script;
    private BoxSwitch obj2_script;

    private bool On_switch = false;

    // Use this for initialization
    void Start () {
        obj1_script = obj1.GetComponent<BoxSwitch>();
        obj2_script = obj2.GetComponent<BoxSwitch>();
    }
	
	// Update is called once per frame
	void Update () {

        if (obj1_script.GetOnSwitch() == true && obj2_script.GetOnSwitch() == true)
        {
            On_switch = true;

            if (this.transform.localScale.y >= 0.5f)
            {
                Vector3 lostScale = new Vector3(0f, 0.01f, 0f);
                this.transform.localScale -= lostScale;
            }
        }
	}

    public bool GetOn_switch()
    {
        return On_switch;
    }


}
