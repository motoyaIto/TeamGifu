using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ray : MonoBehaviour {
    #region variable
    public static bool flag;

    [SerializeField]
    private new Camera camera;
    //Ray
    Ray _ray;
    RaycastHit hit;
    Vector3 hitPosition;
    [SerializeField]
    private Image CursorImage;
    //固定objをクリックしたらアイテム生成するフラグ
    private bool LockObjFlag=false;

    [SerializeField]
    GameSystem _GameSyste;//ゲームシステムスクリプト

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
    #endregion

    #region Event
    //キー・ボタンフラグ
    private bool ClickMouse_LeftButton = false;
    private bool ClickKey_Q = false;

    //アイテムリスト
    [SerializeField]
    private GameObject ItemList;//アイテムリスト
    private ItemListController ItemListScript;//アイテムリストのスクリプト
    private Door_Open DoorOpen;// Room2のドアを開けるためのスクリプト
    private string RayName;
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

    //ハノイの塔制
    [SerializeField]
    private Camera HanoicCamera;//ハノイカメラ
    // Use this for initialization
    void Start()
    {
        hitPosition = Vector3.zero;

        flag = false;

       ItemListScript = ItemList.GetComponent<ItemListController>();
        CursorImage.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Q))
        {
            ClickKey_Q = true;
        }
        else
        {
            ClickKey_Q = false;
        }

        if (Input.GetMouseButton(0))
        {
            ClickMouse_LeftButton = true;
        }
        else
        {
            ClickMouse_LeftButton = false;
        }

        //カーソルのイメージを取得
        CursorImage.transform.position = Input.mousePosition;

        //カーソルを描画
        DrawCursor();
       
        //Rayが当たったオブジェクトの情報を入れる箱
        if (Physics.Raycast(_ray, out hit))
        {
            hitPosition = hit.point;
            RayName = hit.collider.name;

            //カメラ操作を奪う物をクリックしたら
            if(hit.collider.tag == "Camerarock" && Input.GetMouseButtonDown(0))
            {
                //ハノイの塔用のカメラに切り替え
                camera.enabled = false;
                HanoicCamera.enabled = true;

                _GameSyste.HanoinoTou();
            }

            //アイテムと当たったら
            if (hit.collider.tag == "Item" && ClickKey_Q)
            {
                //アイテムリストに入れる
                ItemListScript.SetItemList(hit.collider.name);
                //Destroy(hit.collider.gameObject);
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
        _ray = camera.ScreenPointToRay(Input.mousePosition);
        //カーソルを出していてなおかつカバンが開いてないとき
        if (ClickKey_Q && BagController.LockFlag)
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
            
            obj.name = PrefabItem.name;
            //エフェクトの発生
           // obj.GetComponent<Appearance>().StartF = true;
        }
    }
    #endregion
}
