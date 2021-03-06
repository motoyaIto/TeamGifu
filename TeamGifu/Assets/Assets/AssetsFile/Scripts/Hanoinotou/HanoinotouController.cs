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

    [SerializeField]
    private GameObject ClearMessage;
    private bool ClearFlag = false;
    struct Token
    {
        public GameObject obj;
        public int startPillar; 
    }

    Token token;

    // Use this for initialization
	void Start () {
        for(int i = 0; i < PILLAR_NAM; i++)
        {
            stack[i] = new GameObject[PILLAR_NAM];
        }
        //輪の位置を初期位置に移動
        Ring[0].transform.position = Pillar[0].transform.position;
        Ring[1].transform.position = Pillar[0].transform.position;
        Ring[2].transform.position = Pillar[0].transform.position;

        Ring[0].transform.position = new Vector3(Ring[0].transform.position.x, Ring[0].transform.position.y + 0.07f * 2, Ring[0].transform.position.z);
        Ring[1].transform.position = new Vector3(Ring[1].transform.position.x, Ring[1].transform.position.y + 0.07f, Ring[1].transform.position.z);

        //あたり判定
        HanoinotouColliders = GetComponentsInChildren<Collider>();

        //各柱のあたり判定を消す
        foreach (Collider col in HanoinotouColliders)
        {
            if ("Pillar1" == col.name || "Pillar2" == col.name || "Pillar3" == col.name)
            {
                col.enabled = false;
            }
        }

        int RingCount = RING_NAM - 1;
        //初期位置にすべてスタックする
        for (int i = 0; i < RING_NAM; i++)
        {
            stack[0][i] = Ring[RingCount];

            RingCount--;
        }
    }
	
	// Update is called once per frame
	void Update () {

        if (!ClearFlag)
        {
            if (_GameSyste.GetHanoinoTouFlag())
            {
                SwitchHanoinotou(false, true);
            }
        }
        else
        {
            if (ClearMessage != null)
            {
                ClearMessage.SetActive(true);
            }

            ReturnButton();

            GetComponent<BoxCollider>().enabled = false;
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

   
    /// <summary>
    /// あたり判定を変える
    /// </summary>
    /// <param name="hanoinotou">onにする(true)offにする(false)</param>
    /// <param name="pillar">onにする(true)offにする(false)</param>
    private void SwitchHanoinotou(bool hanoinotou, bool pillar)
    {
        foreach (Collider col in HanoinotouColliders)
        {
            if ("Hanoinotou" == col.name)
            {
                col.enabled = hanoinotou;
            }

            if ("Pillar0" == col.name || "Pillar1" == col.name || "Pillar2" == col.name)
            {
                col.enabled = pillar;
            }
        }
    }

    /// <summary>
    /// 最後尾のオブジェクトを参照
    /// </summary>
    /// <param name="obj">オブジェクト配列</param>
    /// <returns>最後尾のオブジェクト</returns>
    private GameObject PushBuck(GameObject[] obj)
    {
        for (int i = PILLAR_NAM - 1; i >= 0; i--)
        {
            if(obj[i] != null)
            {
                GameObject returnObj = obj[i];
                obj[i] = null;
                return returnObj;
            }
        }

        return null;
    }

    public void ClickController(int pillarNamber)
    {
        //上がっている物がなかったら
        if (token.obj == null)
        {
            //上にあげるリングと元いた位置の柱の番号を登録
            token.obj = PushBuck(stack[pillarNamber]);

            //柱にリングがない時
            if ( token.obj == null) return;

            token.startPillar = pillarNamber;

            //リングを上にあげる
            Vector3 pos = new Vector3(token.obj.transform.position.x, token.obj.transform.position.y + 1.0f, token.obj.transform.position.z);
            token.obj.transform.position = pos;
        }
        else//リングが上がっていたら
        {
            for(int i = 0; i < PILLAR_NAM; i++)
            {
                if(stack[pillarNamber][i] == null)
                {
                    if(i - 1 >= 0)
                    {
                        int BottomObjNamber = int.Parse(stack[pillarNamber][i - 1].name.Substring(stack[pillarNamber][i - 1].name.Length - 1));
                        int ObjNamber = int.Parse(token.obj.name.Substring(token.obj.name.Length - 1));

                        if(BottomObjNamber < ObjNamber)
                        {
                            return;
                        }
                    }

                    //移動先の座標
                    Vector3 pos = Pillar[pillarNamber].transform.position;
                    pos.y += 0.07f * i;

                    token.obj.transform.position = pos;
                 
                    //管理場所に代入してトークンを消去
                    stack[pillarNamber][i] = token.obj;
                    token.obj = null;

                    token.startPillar = -99;

                    //クリア判定
                    if(stack[2][0] != null && stack[2][1] != null && stack[2][2] != null)
                    {
                        ClearFlag = true;
                    }
                    return;
                }
            }
        }
    }
}
