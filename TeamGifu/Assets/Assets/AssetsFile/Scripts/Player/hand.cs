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

            //スケールの縮小
            if (PrefabItem .name!= "Message")
            {
                child = Instantiate(PrefabItem, transform.position + ItemoffsetPos, gameObject.transform.rotation) as GameObject;

                child.transform.localScale -= new Vector3(0.75f, 0.75f, 0.75f);
            }
            else
            {
                return;
            }

            child.tag = "Untagged";
            //コンポーネントを破棄
            Destroy(child.GetComponent<Rigidbody>());
            //手のオブジェクトの子にする
            child.transform.parent = GameObject.Find("CreateIteam").transform;
            item.CreateAitemState = false;


        }


    }
}
