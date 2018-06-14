using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room6_LightGimic : MonoBehaviour {
    //プレファブ生成するアイテム
    private GameObject PrefabItem;
    [SerializeField, Header("ItemListControllerのオブジェ")]
    private ItemListController _item;
    [SerializeField, Header("固定オブジェの座標")]
    private Vector3[] ObjPos;
    [SerializeField, Header("Rayのオブジェクト")]
    private ray _ray;
    [SerializeField,Header("各カプセルオブジェクト")]
    private GameObject[] CapselObj;
   
    private bool[] flag;

    [HideInInspector]
    public bool clear_Flag;
    [Header("正解ランプのマテリアル")]
    public Material mtl;   // 変更するマテリアル
    [Header("不正解ランプのマテリアル")]
    public Material mtlR;   // 変更するマテリアル

    [Header("クリア判定を示すオブジェクト")]
    public GameObject obj;

    private GameObject delete_Obj;


    private const string CreateName = "Battery_small_06 (1)";//固定オブジェクトに出す名前
    private bool OnSwitch = false;
    // Use this for initialization
    void Start()
    {

        flag = new bool[3];
        for(int i=0;i<2;i++)
        {
            flag[i] = false;
        }
        

        clear_Flag = false;
    }

    // Update is called once per frame
    void Update()
    {
        //生成するオブジェクトを取得
        PrefabItem = (GameObject)Resources.Load("Prefabs/" + _item.GetSelectImage());
        FrontCapsuleObj();
        RightCapsuleObj();
        LeftCapsuleObj();


    }
    private void FrontCapsuleObj()
    {
        if (!flag[0])
        {
            //ゲームオブジェクトの名前とRayに当たっているオブジェクト名が一緒か＆＆固定オブジェクトに当たっているか＆＆出すオブジェクトと選択しているアイテムの名前が一緒か
            if (CapselObj[0].name == _ray.RayHitNameState && _ray.LockObjFlagState && CreateName == _item.GetSelectImage())
            {
                GameObject obj = Instantiate(PrefabItem, ObjPos[0], transform.rotation);
                obj.AddComponent<RigWakeUp>();
                _ray.LockObjFlagState = false;

                Clear();
            }
            else if (CapselObj[0].name == _ray.RayHitNameState && _ray.LockObjFlagState)
            {

                //生成するオブジェクトを取得
                GameObject DummyPrefabItem = (GameObject)Resources.Load("Prefabs/" + _item.GetSelectImage());
                GameObject obj = Instantiate(DummyPrefabItem, ObjPos[0], transform.rotation);
                obj.AddComponent<RigWakeUp>();
            }


        }

    }
    private void LeftCapsuleObj()
    {
        if (!flag[1])
        {
            //ゲームオブジェクトの名前とRayに当たっているオブジェクト名が一緒か＆＆固定オブジェクトに当たっているか＆＆出すオブジェクトと選択しているアイテムの名前が一緒か
            if (CapselObj[1].name == _ray.RayHitNameState && _ray.LockObjFlagState && CreateName == _item.GetSelectImage())
            {
                GameObject obj = Instantiate(PrefabItem, ObjPos[1], transform.rotation);
                obj.AddComponent<RigWakeUp>();
                _ray.LockObjFlagState = false;

                Clear();
            }
            else if (CapselObj[1].name == _ray.RayHitNameState && _ray.LockObjFlagState)
            {

                //生成するオブジェクトを取得
                GameObject DummyPrefabItem = (GameObject)Resources.Load("Prefabs/" + _item.GetSelectImage());
                GameObject obj = Instantiate(DummyPrefabItem, ObjPos[1], transform.rotation);
                obj.AddComponent<RigWakeUp>();
            }


        }

    }
    private void RightCapsuleObj()
    {
        if (!flag[2])
        {
            //ゲームオブジェクトの名前とRayに当たっているオブジェクト名が一緒か＆＆固定オブジェクトに当たっているか＆＆出すオブジェクトと選択しているアイテムの名前が一緒か
            if (CapselObj[2].name == _ray.RayHitNameState && _ray.LockObjFlagState && CreateName == _item.GetSelectImage())
            {
                GameObject obj = Instantiate(PrefabItem, ObjPos[2], transform.rotation);
                obj.AddComponent<RigWakeUp>();
                _ray.LockObjFlagState = false;

                Clear();
            }
            else if (CapselObj[2].name == _ray.RayHitNameState && _ray.LockObjFlagState)
            {

                //生成するオブジェクトを取得
                GameObject DummyPrefabItem = (GameObject)Resources.Load("Prefabs/" + _item.GetSelectImage());
                GameObject obj = Instantiate(DummyPrefabItem, ObjPos[2], transform.rotation);
                obj.AddComponent<RigWakeUp>();
            }


        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == CapselObj[0].name)
        {
            flag[0] = true;
            CapselObj[0].GetComponent<Collider>().enabled = false;
        }
        if (collision.gameObject.name == CapselObj[1].name)
        {
            flag[1] = true;
            CapselObj[1].GetComponent<Collider>().enabled = false;
        }
        if (collision.gameObject.name == CapselObj[2].name)
        {
            flag[2] = true;
            CapselObj[2].GetComponent<Collider>().enabled = false;
        }
        delete_Obj = collision.gameObject;
    }

    // クリア処理
    private void Clear()
    {
        clear_Flag = true;
    }

    public bool GetOnSwitch()
    {
        return OnSwitch;
    }

    public void Delete()
    {
        
        Destroy(delete_Obj);
    }

}
