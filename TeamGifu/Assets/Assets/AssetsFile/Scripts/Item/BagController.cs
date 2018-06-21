using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BagController : MonoBehaviour {

    private bool openBag = false;//開いている(true)いない(false)
    static Canvas bag;
    public static bool LockFlag=true;

    private AudioSource As; // 音を鳴らす
    [SerializeField,Header("効果音")]
    private AudioClip Se;

    private void Start()
    {
        As = gameObject.AddComponent<AudioSource>();
        
    }


    public void Event()
    {
        if (openBag == false)
        {
            Bag.SetActive("ItemList", true);

            openBag = true;
            LockFlag = false;
            As.PlayOneShot(Se);
        }
        else
        {
            Bag.SetActive("ItemList", false);

            openBag = false;
            LockFlag = true;
            As.PlayOneShot(Se);
        }

    }
}
