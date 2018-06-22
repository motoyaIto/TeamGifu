using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hand : MonoBehaviour {
    [SerializeField]
    private Vector3 ItemoffsetPos = Vector3.zero;
    [SerializeField]
    private ItemListController item;
    GameObject PrefabItem;
    [SerializeField]
    GameObject child;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (item.CreateAitemState)
        {
            //既に生成されていれば
            if (PrefabItem != null)
            {
                Destroy(child);//破棄
            }
            //生成するオブジェクトを取得
            PrefabItem = (GameObject)Resources.Load("ItemPrefab/" + item.GetSelectImage());
            //アイテムの生成
            child = Instantiate(PrefabItem, transform.position+ItemoffsetPos, new Quaternion(0,0,0,0)) as GameObject;
            //スケールの縮小
            if(child.gameObject.name!= "Message(Clone)")
            {
               child.transform.localScale -= new Vector3(0.75f, 0.75f, 0.75f);
            }
            else
            {
                child.transform.Rotate( new Vector3(-169.694f, 117.82f, -100.308f));
            }

            child.tag = "Untagged";
            //コンポーネントを破棄
            Destroy(child.GetComponent<Rigidbody>());
            Destroy(child.GetComponent<Appearance>());
            //手のオブジェクトの子にする
            child.transform.parent = GameObject.Find("Hand").transform;
            item.CreateAitemState = false;


        }


    }
}
