using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessgeKard : MonoBehaviour {
    [SerializeField]
    ItemListController item;
    [SerializeField]
    FadaText fadeText;
    [SerializeField]
    private GameObject TextObj;//FadaTextのオブジェクト
    bool isLock;//メッセージカードを取得したらtrueにするフラグ

    private void Awake()
    {
    }

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        //開くアイテムがメッセージカードなら
        if (item.GetSelectImage() == "Message")
        {
            //メッセージカードのRenderを表示
            gameObject.GetComponent<Renderer>().enabled = true;
            isLock = true;
            //フェードアニメーションがまだ行われていなかったら？
            if(fadeText.isAnimetionState)
            {
                TextObj.SetActive(true);
            }
   
        }
        else
        {
            gameObject.GetComponent<Renderer>().enabled = false;
            TextObj.SetActive(false);
            isLock = false;

        }
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Hit")
        {
            if (!isLock) return;
            fadeText.fadeFunction();//アニメーションの開始
        }
        else
        {
            gameObject.GetComponent<Renderer>().enabled = false;


        }

    }

}
