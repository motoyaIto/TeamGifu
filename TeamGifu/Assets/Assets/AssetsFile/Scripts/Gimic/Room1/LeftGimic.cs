using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftGimic : MonoBehaviour {
    //プレファブ生成するアイテム
    private GameObject PrefabItem;
    [SerializeField, Header("ItemListControllerのオブジェ")]
    private ItemListController _item;
    [SerializeField, Header("固定オブジェの座標")]
    private Vector3 ObjPos;
    [SerializeField, Header("Rayのオブジェクト")]
    private ray _ray;
    [SerializeField]
    private GameObject parentObj;

    private const string CreateName = "Sphere";//固定オブジェクトに出す名前
    private bool OnSwitch = false;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //生成するオブジェクトを取得
        PrefabItem = (GameObject)Resources.Load("Prefabs/" + _item.GetSelectImage());

      
        //ゲームオブジェクトの名前とRayに当たっているオブジェクト名が一緒か＆＆固定オブジェクトに当たっているか＆＆出すオブジェクトと選択しているアイテムの名前が一緒か
        if (gameObject.name == _ray.RayHitNameState && _ray.LockObjFlagState && CreateName == _item.GetSelectImage())
        {
            Appearance.StartHeight = parentObj.transform.position.y - 0.74f;
            Appearance.StartWorldHeight = parentObj.transform.position.y;
            GameObject obj =Instantiate(PrefabItem, new Vector3(ObjPos.x,ObjPos.y,ObjPos.z), transform.rotation);
            obj.transform.localScale -= new Vector3(0.5f, 0.5f, 0.5f);
            obj.transform.parent = GameObject.Find("swich_1").transform;

            SoundManager.PlaySe("pushItem");
            _ray.LockObjFlagState = false;
            
            
    }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Item")
        {
            OnSwitch = true;
            GetComponent<Collider>().enabled = false;
        }
    }

    public bool GetOnSwitch()
    {
        return OnSwitch;
    }
}
