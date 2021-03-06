﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ray : MonoBehaviour {
    #region Variable
    public static bool flag;
    [SerializeField,Header("Room6のオブジェクト")]
    private Room6 _room6;
    Appearance _appearance;
    //エフェクト
    public PrometheanDissolveEffect DissolveSource;

    //Ray
    private　Ray _ray;
    private RaycastHit hit;
    private Vector3 hitPosition;
    private string RayName;
    [SerializeField]
    private new Camera camera;
    [SerializeField]
    private Image CursorImage;

    [SerializeField]
    private GameSystem _GameSyste;//ゲームシステムスクリプト
    //固定objをクリックしたらアイテム生成するフラグ
    private bool LockObjFlag=false;
    //キー・ボタンフラグ
    private bool ClickMouse_LeftButton = false;
    private bool ClickKey_Q = false;
    private bool OperationFlag = false;

    //ハノイの塔制
    [SerializeField]
    private Camera HanoicCamera;//ハノイカメラ
    [SerializeField]
    private HanoinotouController hanoiScript;//ハノイスクリプト

    //アイテムリスト
    [SerializeField]
    private GameObject ItemList;//アイテムリスト
    private ItemListController ItemListScript;//アイテムリストのスクリプト
    [SerializeField]
    private Material Changematerial;


    #region PropertyVariable
    public bool LockObjFlagState
    {
        get
        {
            return LockObjFlag;
        }
        set
        {
            LockObjFlag = value;
        }
    }

    public string RayHitNameState
    {
        get
        {
            return RayName;
        }
        set
        {
            RayName = value;
        }

    }
#endregion

    #endregion

    #region Event

    // Use this for initialization
    void Start()
    {
        hitPosition = Vector3.zero;

        flag = false;

       ItemListScript = ItemList.GetComponent<ItemListController>();
        CursorImage.enabled = false;
        _appearance = new Appearance();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Q))
        {
            ClickKey_Q = true;
        }
        else
        {
            ClickKey_Q = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            ClickMouse_LeftButton = true;
        }
        else
        {
            ClickMouse_LeftButton = false;
        }
        LockGetItem();

        //カーソルのイメージを取得
        CursorImage.transform.position = Input.mousePosition;

        //カーソルを描画
        DrawCursor();
       
        //Rayが当たったオブジェクトの情報を入れる箱
        if (Physics.Raycast(_ray, out hit,10.0f))
        {
            hitPosition = hit.point;
            RayName = hit.collider.name;
            Transform target = null;

            //カメラ操作を奪う物をクリックしたら
            if (hit.collider.tag == "Camerarock" && Input.GetMouseButtonDown(0))
            {
                //ハノイの塔用のカメラに切り替え

                camera.enabled = false;

                HanoicCamera.enabled = true;

                _GameSyste.HanoinoTou();
            }

            //ハノイの塔をプレイ
            if (_GameSyste.GetHanoinoTouFlag() && hit.collider.tag == "Pillar" && Input.GetMouseButtonDown(0))
            {
                hanoiScript.ClickController(int.Parse(hit.collider.name.Substring(hit.collider.name.Length - 1)));
            }

            //アイテムと当たったら
            if(!OperationFlag)
            {
                if (hit.collider.tag == "Item" && ClickKey_Q &&! Input.GetMouseButtonDown(0))
                {
                    //アイテムリストに入れる
                    ItemListScript.SetItemList(hit.collider.name);
                    target = hit.transform;
                    //エフェクトの発生
                    if (target.GetComponent<PrometheanDissolveEffect>() == null)
                    {
                        var source = Instantiate(DissolveSource);
                        source.DissolveTarget(target, hit.point);
                        SoundManager.PlaySe("getItem", 1);

                    }
                }
            }

            //アイテムが選択されていてなおかつアイテムが出せる場所に当たったら
            if (ItemListScript.GetSelectImage() != "" && hit.collider.tag == "Hit")
            {
                TraceOnObject();
         
            }      
            if(hit.collider.tag=="LockHit"&&ClickKey_Q && ClickMouse_LeftButton)
            {
                LockObjFlag = true;
            }
            else
            {
                LockObjFlag = false;
            }
        }

    }

    /// <summary>
    /// カーソルを描画する
    /// </summary>
    private void DrawCursor()
    {
        //マウス座標からrayを飛ばす
        if(_GameSyste.GetHanoinoTouFlag())
        {
            _ray = HanoicCamera.ScreenPointToRay(Input.mousePosition);

        }
        else
        {
            _ray = camera.ScreenPointToRay(Input.mousePosition);

        }
        //カーソルを出していてなおかつカバンが開いてないとき
        if (ClickKey_Q && BagController.LockFlag && !_GameSyste.GetGameFlag())
        {
            CursorImage.enabled = true;
        }
        else
        {
            CursorImage.enabled = false;
        }
    }
   
    /// <summary>
    /// トレースオンオブジェクト
    /// </summary>
    private void TraceOnObject()
    {
        //アイテム名の取得
        GameObject PrefabItem = (GameObject)Resources.Load("Prefabs/" + ItemListScript.GetSelectImage());
        
        if (ClickKey_Q && ClickMouse_LeftButton && PrefabItem)
        {

            //アイテムの生成
            GameObject obj = Instantiate(PrefabItem, new Vector3(hitPosition.x, hitPosition.y , hitPosition.z), hit.transform.rotation);
            if (_room6.ProinRoom6)
            {
                obj.GetComponent<Appearance>().StartHeightState = 29.0f;
                obj.GetComponent<Appearance>().MaxHeightState = 32.0f;
            }

            obj.transform.localScale -= new Vector3(0.5f, 0.5f, 0.5f);

            obj.name = PrefabItem.name;

            SoundManager.PlaySe("pushItem", 1);

                
        }
    }
    void LockGetItem()
    {
        if(Input.GetMouseButton(0)&&Input.GetKey(KeyCode.Q))
        {
            OperationFlag = true;
        }
        else if(!Input.GetMouseButton(0)&&!Input.GetKey(KeyCode.Q))
        {
            OperationFlag = false;
        }


    }
    #endregion
}
