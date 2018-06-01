using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HanoinotouController : MonoBehaviour {

    [SerializeField]
    private Camera PlayerCamera;//プレイヤーカメラ
    [SerializeField]
    private Camera HanoiCamera;//ハノイの塔カメラ
    [SerializeField]
    private GameSystem _GameSyste;//ゲームシステムスクリプト

    private Collider[] HanoinotouColliders;//ハノイの塔内のコライダー

    [SerializeField]
    private GameObject[] Pillar = new GameObject[3];//柱1~3

    [SerializeField]
    private GameObject[] Ring = new GameObject[3];//輪1~3

	// Use this for initialization
	void Start () {
        //輪の位置を初期位置に移動
        Ring[0].transform.position = Pillar[0].transform.position;
        Ring[1].transform.position = Pillar[0].transform.position;
        Ring[2].transform.position = Pillar[0].transform.position;

        Ring[0].transform.position = new Vector3(Ring[0].transform.position.x, Ring[0].transform.position.y + 0.07f * 2, Ring[0].transform.position.z);
        Ring[1].transform.position = new Vector3(Ring[1].transform.position.x, Ring[1].transform.position.y + 0.07f, Ring[1].transform.position.z);

        //あたり判定
        HanoinotouColliders = GetComponents<Collider>();

        foreach (Collider col in HanoinotouColliders)
        {
            if ("Pillar1" == col.name/* || "Pillar2" == col.name || "Pillar3" == col.name*/)
            {
                col.enabled = false;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		if(_GameSyste.GetHanoinoTouFlag())
        {
            foreach(Collider col in HanoinotouColliders)
            {
                Debug.Log(col);
                if ("Hanoinotou" == col.name)
                {
                    col.enabled = false;
                }
   
                if ("Pillar1" == col.name || "Pillar2" == col.name || "Pillar3" == col.name)
                {
                    col.enabled = true;
                }
            
            }
            
            //Debug.Log("ハノイの塔");
            
            
        }
	}

    public void ReturnButton()
    {
        //プレイヤー用のカメラに切り替え
        PlayerCamera.enabled = true;
        HanoiCamera.enabled = false;

        _GameSyste.ReturnButton();

        foreach (Collider col in HanoinotouColliders)
        {
            if ("Hanoinotou" == col.name)
            {
                col.enabled = true;
            }

            if ("Pillar1" == col.name || "Pillar2" == col.name || "Pillar3" == col.name)
            {
                col.enabled = false;
            }
        }
    }
}
