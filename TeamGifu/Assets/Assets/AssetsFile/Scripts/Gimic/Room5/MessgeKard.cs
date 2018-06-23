using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessgeKard : MonoBehaviour {
    [SerializeField]
    ItemListController item;

    private void Awake()
    {
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (item.GetSelectImage() == "Message")
        {
            gameObject.GetComponent<Renderer>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<Renderer>().enabled = false;


        }

    }

}
