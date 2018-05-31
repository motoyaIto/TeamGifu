using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BoxSwitch_2pair : MonoBehaviour {


    [SerializeField]
    private LeftGimic obj1_script;
    [SerializeField]
    private RightGimic obj2_script;

    private bool On_switch = false;
    [SerializeField,Header("Boxswich_2pairの初期座標")]
    private Vector3 objPos;
    [SerializeField,Header("移動量")]
    private Vector3 MovePos;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {

        if (obj1_script.GetOnSwitch() == true && obj2_script.GetOnSwitch() == true)
        {
            On_switch = true;

            transform.DOLocalMove(new Vector3(objPos.x, objPos.y, objPos.z)+MovePos, 5.0f);
        }
	}

    public bool GetOn_switch()
    {
        return On_switch;
    }


}
