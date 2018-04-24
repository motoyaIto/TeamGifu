using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BagController : MonoBehaviour {

    private bool openBag = false;//開いている(true)いない(false)
    static Canvas bag;
    public static bool LookFlag=true;
    public bool LookFlagState
    {
        get
        {
            return LookFlag;
        }
        set
        {
            LookFlag = value;
        }
    }

    public void Event()
    {
        if (openBag == false)
        {
            Bag.SetActive("ItemList", true);

            openBag = true;
            LookFlag = false;
        }
        else
        {
            Bag.SetActive("ItemList", false);

            openBag = false;
            LookFlag = true;
            
        }

    }
}
