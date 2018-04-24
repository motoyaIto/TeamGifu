using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemListController : MonoBehaviour {

    const int MAX_HAVE = 12;

    [SerializeField]
    private string[] Items;
	// Use this for initialization
	void Start () {
        gameObject.SetActive(false);

        Items = new string[MAX_HAVE];
	}
	
	// Update is called once per frame
	void Update () {
      
	}


    /// <summary>
    /// アイテムを収納する
    /// </summary>
    /// <param name="name">アイテム名</param>
    public void SetItemList(string name)
    {
        for(int i = 0; i < MAX_HAVE; i++)
        {
            if (Items[i] == null )
            {
                Items[i] = name;

                return;
            }
            else if(Items[i] == name)
            {
                return;
            }
        }
    }
}
