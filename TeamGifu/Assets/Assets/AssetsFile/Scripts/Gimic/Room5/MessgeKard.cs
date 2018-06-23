using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessgeKard : MonoBehaviour {
    [SerializeField]
    ItemListController item;
    [SerializeField]
    FadaText fadeText;
    bool isLock;

    private void Awake()
    {
    }

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (item.GetSelectImage() == "Message")
        {
            gameObject.GetComponent<Renderer>().enabled = true;
            isLock = true;
        }
        else
        {
            gameObject.GetComponent<Renderer>().enabled = false;
            isLock = false;

        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Hit")
        {
            if (!isLock) return;
            fadeText.fadeFunction();
        }
        else
        {
            gameObject.GetComponent<Renderer>().enabled = false;


        }

    }

}
