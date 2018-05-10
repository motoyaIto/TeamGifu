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
    private bool rayFlag;

    [SerializeField]
   public static string[] objName;
    private GameObject PrefabItem;

    private Light_Controller light_obj;
    #endregion
    Vector3 hitPosition;
    #region Event
    [SerializeField]
    private GameObject ItemList;
    private ItemListController ItemListScript;
    private BagController _bag;

    private void Awake()
    {

        gameObject.SetActive(true);

    }
    // Use this for initialization
    void Start()
    {
        light_obj = new Light_Controller();
        hitPosition = Vector3.zero;
        CursorImage.enabled = false;
        rayFlag = false;
        objName = new string[5];
        flag = false;
        ItemListScript = ItemList.GetComponent<ItemListController>();
        //ItemListScript = gameObject.AddComponent<ItemListController>();

        _bag = gameObject.AddComponent<BagController>();
    }

    // Update is called once per frame
    void Update()
    {
 

        if (ray.objName!=null)
        {
            //アイテム名の取得
            PrefabItem = (GameObject)Resources.Load("Prefabs/" + objName[0]);
        }

    
        if (BagController.LookFlag)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                CursorImage.enabled = true;
                rayFlag = true;

            }
            else
            {
                CursorImage.enabled = false;
                rayFlag = false;

            }
            if (rayFlag)
            {
                Debug.Log("生成");
                //カーソル画像にマウス座標を追加
                CursorImage.transform.position = Input.mousePosition;
                _ray = camera.ScreenPointToRay(Input.mousePosition);
            }
        }

        //Rayが当たったオブジェクトの情報を入れる箱

        if (Physics.Raycast(_ray, out hit))
        {
            hitPosition = hit.transform.position;
            if (hit.collider.tag == "Item")
            {
                ItemListScript.SetItemList(hit.collider.name);
                GetObjectName();
                Light_Controller.name = hit.collider.name;

            }
            if (hit.collider.tag == "Hit")
            {
                Debug.Log("Hit");
                if(PrefabItem!=null)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        Debug.Log("生成");
                        Instantiate(PrefabItem,  new Vector3(hitPosition.x,hitPosition.y+0.5f,hitPosition.z),hit.transform.rotation);
                    }
                }
            }
       
        }
    }
    private void GetObjectName()
    {
        for (int i = 0; i < 4; i++)
        {
            if (objName[i] == null)
            {
                if (objName[i] != hit.collider.name)
                {
                    objName[i] = hit.collider.gameObject.name;

                    break;
                }


            }
            else if (objName[i] == hit.collider.name) { break; }
        }
    }

    #endregion

}
