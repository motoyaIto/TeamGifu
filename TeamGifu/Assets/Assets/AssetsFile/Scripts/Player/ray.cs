using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ray : MonoBehaviour {
    #region variable
    public static bool flag;
    [SerializeField]
    private Image CursorImage;
    private GameObject HitObj;//ヒットしたオブジェクト
    [SerializeField]
    private new Camera camera;
    Ray _ray;
    RaycastHit hit;
    

    //[SerializeField]
   //public static string[] objName;
    private GameObject PrefabItem;
    #endregion
    Vector3 hitPosition;
    CursorLockMode lockMode = CursorLockMode.None;
    #region Event

    [SerializeField]
    private GameObject ItemList;//アイテムリスト
    private ItemListController ItemListScript;//アイテムリストのスクリプト
   
    int Number = 0;

    private void Awake()
    {

    }
    // Use this for initialization
    void Start()
    {

        hitPosition = Vector3.zero;
        CursorImage.enabled = false;
        //objName = new string[5];
        flag = false;

       ItemListScript = ItemList.GetComponent<ItemListController>();
       
    }

    // Update is called once per frame
    void Update()
    {
        //if (ItemListScript.GetItemListFlag())
        //{
        //    //アイテム名の取得
        //    PrefabItem = (GameObject)Resources.Load("Prefabs/" /*+ objName[0]*/);
        //}

        //カバンが開いてないとき
        if (BagController.LockFlag)
        {
            //カーソルを出しているとき
            if (Input.GetKey(KeyCode.Q))
            {
                CursorImage.enabled = true;

                Debug.Log("生成");
                //カーソル画像にマウス座標を追加
                CursorImage.transform.position = Input.mousePosition;
                //マウス座標からrayを飛ばす
                _ray = camera.ScreenPointToRay(Input.mousePosition);
            }
            else
            {
                CursorImage.enabled = false;
            }
        }

        //Rayが当たったオブジェクトの情報を入れる箱
        if (Physics.Raycast(_ray, out hit))
        {
            hitPosition = hit.transform.position;
            if (hit.collider.tag == "Item")
            {
                //アイテムリストに入れる
                ItemListScript.SetItemList(hit.collider.name);
                //GetObjectName();
            }

            //アイテムが出せる場所に当たったら
            if (hit.collider.tag == "Hit")
            {
                Debug.Log("Hit");
                if(PrefabItem!=null)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        Debug.Log("生成");
                    
                        //アイテムの生成
                        GameObject obj= Instantiate(PrefabItem,  new Vector3(hitPosition.x,hitPosition.y+1.0f,hitPosition.z),hit.transform.rotation);
                        //エフェクトの発生
                        obj.GetComponent<Appearance>().StartF = true;
                        
          
                    }
                }
            }
       
        }
    }
   
    #endregion

}
