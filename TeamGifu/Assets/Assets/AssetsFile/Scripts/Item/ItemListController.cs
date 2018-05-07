//--------------------------------------------------
//アイテムリスト
//作成者：伊藤　元哉
//--------------------------------------------------


using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ItemListController : MonoBehaviour {

    const int MAX_HAVE = 12;

    // アイテムで使うスプライト（テクスチャ）
    // これは、Unity エディタ上で事前に設定しておく必要があります
    [SerializeField]
    private Sprite[] m_spriteList;

    // スプライトを描画するためのオブジェクト
    public Image[] m_imageList;
    
	void Start () {
        gameObject.SetActive(false);

        // あらかじめすべてのアイテムのスプライトを非表示にしておく
        foreach (var n in m_imageList)
        {
            n.gameObject.SetActive(false);
        }
    }
	
	void Update () {
      
	}
    
    /// <summary>
    /// UI用の画像を取得する
    /// </summary>
    /// <param name="name">アイテム名</param>
    public void SetItemList(string name)
    {
        // スプライトのリストから、
        // オブジェクトの名前に等しいスプライトを検索して取得します
        Sprite sprite = m_spriteList.FirstOrDefault(c => c.name == name);

        // もし等しい名前のスプライトが存在しない場合は
        // エラーメッセージを表示して処理をスキップします
        if ( sprite == null )
        {
            Debug.LogErrorFormat( "{0} という名前のスプライトは存在しません", name );
            return;
        }

        // HorizontalLayoutGroup
        // GridLayoutGroup

        // アイテムのスプライトを表示するオブジェクトをアクティブにして
        // スプライトを設定します
        foreach(Image image in m_imageList)
        {
            //imageがアクティブなら
            if (image.gameObject.activeSelf == true)
            {
                //同じ名前なら登録しない
                if(image.sprite.name == name)
                {
                    return;
                }
            }
            else
            {
                //イメージにセットする
                image.gameObject.SetActive(true);
                image.sprite = sprite;

                return;
            }            
        }
    }
}
