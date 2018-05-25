using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hand : MonoBehaviour {
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Vector3 offsetPos = Vector3.zero;
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
       // transform.position = player.transform.position+offsetPos;
        if(item.CreateAitemState)
        {
            if (PrefabItem != null)
            {
                Destroy(child);
            }
            PrefabItem = (GameObject)Resources.Load("Prefabs/" + item.GetSelectImage());
            //アイテムの生成
            child = Instantiate(PrefabItem, transform.position+ ItemoffsetPos, player.transform.rotation) as GameObject;
            child.transform.parent = transform.root.Find("FirstPersonCharacter");
            child.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
            item.CreateAitemState = false;
            Destroy(child.GetComponent<Rigidbody>());
        }

		
	}
}
