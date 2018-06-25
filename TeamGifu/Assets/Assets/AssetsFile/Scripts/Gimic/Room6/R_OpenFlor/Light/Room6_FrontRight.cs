using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room6_FrontRight : MonoBehaviour {

    //プレファブ生成するアイテム
    private GameObject PrefabItem;
    [SerializeField, Header("ItemListControllerのオブジェ")]
    private ItemListController _item;
    [SerializeField, Header("固定オブジェの座標")]
    private Vector3 ObjPos;
    [SerializeField, Header("Rayのオブジェクト")]
    private ray _ray;
    private bool flag;
    private bool ClearFlag;
    public bool ClearFlagState
    {
        get
        {
            return ClearFlag;
        }
    }

    [Header("正解ランプのマテリアル")]
    public Material mtl;   // 変更するマテリアル
    [Header("不正解ランプのマテリアル")]
    public Material mtlR;   // 変更するマテリアル

    [Header("クリア判定を示すオブジェクト")]
    public GameObject obj;
    [SerializeField]
    private GameObject delete_Obj;


    private const string CreateName = "Battery_small_06(Clone)";//固定オブジェクトに出す名前
    private bool OnSwitch = false;
    // Use this for initialization
    void Start()
    {
        flag = false;
        ClearFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        //生成するオブジェクトを取得
        PrefabItem = (GameObject)Resources.Load("Prefabs/" + _item.GetSelectImage());

        if (!flag)
        {
             if (gameObject.name == _ray.RayHitNameState && _ray.LockObjFlagState)
            {
                //生成するオブジェクトを取得
                GameObject DummyPrefabItem = (GameObject)Resources.Load("Prefabs/" + _item.GetSelectImage());
                GameObject obj = Instantiate(DummyPrefabItem, new Vector3(ObjPos.x, ObjPos.y, ObjPos.z), transform.rotation);
                obj.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                obj.AddComponent<RigWakeUp>();
                _ray.LockObjFlagState = false;
                SoundManager.PlaySe("pushItem");
            }


        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            flag = true;
        }
        if (collision.gameObject.name == CreateName)
        {
            ClearFlag = true;


        }
        delete_Obj = collision.gameObject;
    }

    public bool GetOnSwitch()
    {
        return OnSwitch;
    }

    // マテリアルの変更
    private void ReplaceMaterial(Material mat)
    {
        obj.GetComponent<Renderer>().material = mat;
    }

    public void Delete()
    {
        flag = false;
        Destroy(delete_Obj);
        ReplaceMaterial(mtlR);
    }
}
