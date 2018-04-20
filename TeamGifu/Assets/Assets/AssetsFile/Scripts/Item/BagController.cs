using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagController : MonoBehaviour {

    private bool openBag = false;//開いている(true)いない(false)
    public void Event()
    {
        if (openBag == false)
        {
            Bag.SetActive("ItemList", true);

            openBag = true;
        }
        else
        {
            Bag.SetActive("ItemList", false);

            openBag = false;
        }

    }
}
