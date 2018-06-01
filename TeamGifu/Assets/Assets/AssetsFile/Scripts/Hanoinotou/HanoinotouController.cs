﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HanoinotouController : MonoBehaviour {

    private static int PILLAR_NAM = 3;//柱の合計
    private static int RING_NAM = 3;//リングの合計

    
    [SerializeField]
    private Camera PlayerCamera;//プレイヤーカメラ
    [SerializeField]
    private Camera HanoiCamera;//ハノイの塔カメラ
    [SerializeField]
    private GameSystem _GameSyste;//ゲームシステムスクリプト

    private Collider[] HanoinotouColliders;//ハノイの塔内のコライダー

    [SerializeField]
    private GameObject[] Pillar = new GameObject[PILLAR_NAM];//柱1~3

    [SerializeField]
    private GameObject[] Ring = new GameObject[RING_NAM];//輪1~3

    private GameObject[][] stack = new GameObject[PILLAR_NAM][];//各柱の輪を管理する
	// Use this for initialization
	void Start () {
        //輪の位置を初期位置に移動
        Ring[0].transform.position = Pillar[0].transform.position;
        Ring[1].transform.position = Pillar[0].transform.position;
        Ring[2].transform.position = Pillar[0].transform.position;

        Ring[0].transform.position = new Vector3(Ring[0].transform.position.x, Ring[0].transform.position.y + 0.07f * 2, Ring[0].transform.position.z);
        Ring[1].transform.position = new Vector3(Ring[1].transform.position.x, Ring[1].transform.position.y + 0.07f, Ring[1].transform.position.z);

        //あたり判定
        HanoinotouColliders = GetComponentsInChildren<Collider>();

        foreach (Collider col in HanoinotouColliders)
        {
            if ("Pillar1" == col.name || "Pillar2" == col.name || "Pillar3" == col.name)
            {
                col.enabled = false;
            }
        }

        for(int i = 0; i < PILLAR_NAM; i++)
        {
            for (int j = 0; j < RING_NAM; j++)
            {
                if (i == 0)
                {
                    stack[i][j] = Ring[j];
                }
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		if(_GameSyste.GetHanoinoTouFlag())
        {
            SwitchHanoinotou(false, true);
            
            
        }
	}

    public void ReturnButton()
    {
        //プレイヤー用のカメラに切り替え
        PlayerCamera.enabled = true;
        HanoiCamera.enabled = false;

        _GameSyste.ReturnButton();

        SwitchHanoinotou(true, false);
           
    }






    private void SwitchHanoinotou(bool hanoinotou, bool pillar)
    {
        foreach (Collider col in HanoinotouColliders)
        {
            if ("Hanoinotou" == col.name)
            {
                col.enabled = hanoinotou;
            }

            if ("Pillar1" == col.name || "Pillar2" == col.name || "Pillar3" == col.name)
            {
                col.enabled = pillar;
            }
        }
    }
}
