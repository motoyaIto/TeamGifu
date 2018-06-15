using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Room6 : MonoBehaviour {
    [SerializeField]
    Room6_UpFloor _upFloor;
    [SerializeField]
    private GameObject[] Lightobj;
    [SerializeField]
    private Room6_FrontRight _flontLight;
    [SerializeField]
    private Room6_LeftLight _leftLight;
    [SerializeField]
    private Room6_RightLight _rightLight;
    private const int MAX_LIGHT = 3;
    [SerializeField]
    private Room6_R_SwithR r_SwithR;
    [SerializeField]
    private Room6_R_Swith_L r_SwithL;
    [SerializeField]
    private GameObject RightFloor;
    [SerializeField]
    private Vector3 RightPos;

    [SerializeField]
    private GameObject LeftFloor;
    [SerializeField]
    private Vector3 LeftPos;
    [Header("正解ランプのマテリアル")]
    public Material mtl;   // 変更するマテリアル


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (r_SwithR.clearFlagState&& r_SwithL.clearFlagState)
        {
            RightFloor.transform.DOMove(RightPos, 2.0f);
            LeftFloor.transform.DOMove(LeftPos, 2.0f);
            _upFloor.GetRideFlag(true);

        }
        if(_flontLight.ClearFlagState&&_leftLight.ClearFlagState&&_rightLight.ClearFlagState)
        {

            for(int i=0;i<MAX_LIGHT;i++)
            {
                Lightobj[i].GetComponent<Renderer>().material = mtl;
            }
     
        }


    }
}
