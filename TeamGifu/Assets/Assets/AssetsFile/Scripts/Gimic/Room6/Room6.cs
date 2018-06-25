using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Room6 : MonoBehaviour {
    private const int MAX_LIGHT = 3;
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
    [SerializeField]
    private Room6_L_SwithR l_swithR;
    [SerializeField]
    private Room6_L_SwithL l_swithL;
    [SerializeField]
    private L_UpFloor l_upFoor;
    [SerializeField]
    private GameObject L_RightFloor;
    [SerializeField]
    private Vector3 L_RightPos;

    [SerializeField]
    private GameObject L_LeftFloor;
    [SerializeField]
    private Vector3 L_LeftPos;
    [SerializeField]
    Room6L_FrontLight L_frontLight;
    [SerializeField]
    Room6L_LeftLight L_leftLight;
    [SerializeField]
    Room6L_RightLight L_rightLight;
    [SerializeField]
    private GameObject[] L_Lightobj;

    [SerializeField]
    GameObject Warp;
    private bool WarpFlag1 = false;
    private bool WarpFlag2 = false;


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
            SoundManager.PlaySe("gate");
            r_SwithR.clearFlagState = false;

        }
        if(l_swithL.clearFlagState&&l_swithR.clearFlagState)
        {
            L_RightFloor.transform.DOMove( L_RightPos, 2.0f);
            L_LeftFloor.transform.DOMove(L_LeftPos, 2.0f);
            l_upFoor.GetRideFlag(true);
            SoundManager.PlaySe("gate");
            l_swithL.clearFlagState = false;


        }
        if (_flontLight.ClearFlagState&&_leftLight.ClearFlagState&&_rightLight.ClearFlagState)
        {

            for(int i=0;i<MAX_LIGHT;i++)
            {
                Lightobj[i].GetComponent<Renderer>().material = mtl;
            }

            WarpFlag1 = true;
     
        }
        if(L_frontLight.ClearFlagState&&L_rightLight.ClearFlagState&&L_leftLight.ClearFlagState)
        {
            for (int i = 0; i < MAX_LIGHT; i++)
            {
                L_Lightobj[i].GetComponent<Renderer>().material = mtl;
            }

            WarpFlag2 = true;
        }

        if(WarpFlag1 && WarpFlag2)
        {
            Warp.SetActive(true);
        }

    }
}
