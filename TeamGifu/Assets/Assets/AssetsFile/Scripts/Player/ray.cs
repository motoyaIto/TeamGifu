using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ray : MonoBehaviour {
    #region variable
    public static bool flag;
    [SerializeField]
    private new Camera camera;
    Ray _ray;
    RaycastHit hit;
    
    #endregion
    Vector3 hitPosition;
    [SerializeField]
    private Image CursorImage;

    #region Event

    [SerializeField]
    private GameObject ItemList;//アイテムリスト
    private ItemListController ItemListScript;//アイテムリストのスクリプト

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
        //カーソルのイメージを取得
        CursorImage.transform.position = Input.mousePosition;

        //カーソルを描画
        DrawCursor();
       
        //Rayが当たったオブジェクトの情報を入れる箱
        if (Physics.Raycast(_ray, out hit))
        {
            hitPosition = hit.transform.position;
            if (hit.collider.tag == "Item")
            {
                //アイテムリストに入れる
                ItemListScript.SetItemList(hit.collider.name);
                Destroy(hit.collider.gameObject);
            }

            //アイテムが選択されていてなおかつアイテムが出せる場所に当たったら
            if (ItemListScript.GetSelectImage() != "" && hit.collider.tag == "Hit")
            {
                TraceOnObject();
            }           
        } 
    }

    /// <summary>
    /// カーソルを描画する
    /// </summary>
    private void DrawCursor()
    {
        //カーソルを出していてなおかつカバンが開いてないとき
        if (Input.GetKey(KeyCode.Q) && BagController.LockFlag)
        {
            CursorImage.enabled = true;

            //マウス座標からrayを飛ばす
            _ray = camera.ScreenPointToRay(Input.mousePosition);
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

        if (Input.GetMouseButtonDown(0))
        {
            //アイテムの生成
            GameObject obj = Instantiate(PrefabItem, new Vector3(hitPosition.x, hitPosition.y + 1.0f, hitPosition.z), hit.transform.rotation);
            //エフェクトの発生
            obj.GetComponent<Appearance>().StartF = true;
        }
    }
    #endregion
}
