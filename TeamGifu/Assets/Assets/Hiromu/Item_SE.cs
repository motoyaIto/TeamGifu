using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Item_SE : MonoBehaviour {

    const int MAX_HAVE = 12;
    public GameObject player;

    // アイテムで使うスプライト（テクスチャ）
    // これは、Unity エディタ上で事前に設定しておく必要があります
    [SerializeField]
    private Sprite[] m_spriteList;

    // SE
    private AudioSource As;
    [SerializeField, Header("効果音")]
    private AudioClip Se;

    // スプライトを描画するためのオブジェクト
    [SerializeField]
    private Image[] m_imageList;
    private bool m_inItem = false;
    [SerializeField]
    private Vector3 offset = Vector3.zero;
    private bool CreateAitemFlag = false;
    public bool CreateAitemState
    {
        get
        {
            return CreateAitemFlag;
        }
        set
        {
            CreateAitemFlag = value;
        }
    }

    //クリックされたイメージ
    private string m_selectImage;

    void Start()
    {
        gameObject.SetActive(false);

        // あらかじめすべてのアイテムのスプライトを非表示にしておく
        foreach (Image n in m_imageList)
        {
            n.gameObject.SetActive(false);
        }

        // AudioSourceを増やす
        As = gameObject.AddComponent<AudioSource>();
    }

    void Update()
    {

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
        if (sprite == null)
        {
            return;
        }

        // HorizontalLayoutGroup
        // GridLayoutGroup

        // アイテムのスプライトを表示するオブジェクトをアクティブにして
        // スプライトを設定します
        foreach (Image image in m_imageList)
        {
            //imageがアクティブなら
            if (image.gameObject.activeSelf == true)
            {
                //同じ名前なら登録しない
                if (image.sprite.name == name)
                {
                    return;
                }
            }
            else
            {
                //イメージにセットする
                image.gameObject.SetActive(true);
                image.sprite = sprite;

                m_inItem = true;

                return;
            }
        }
    }

    /// <summary>
    /// クリックされたアイテムを取得する
    /// </summary>
    /// <param name="image">アイテムの画像</param>
    public void SerectImage(Image image)
    {
        m_selectImage = image.sprite.name;
        CreateAitemFlag = true;
    }




    public string GetItemName(int i)
    {
        return m_imageList[i].sprite.name;
    }

    public bool GetItemListFlag()
    {
        return m_inItem;
    }

    public string GetSelectImage()
    {
        return m_selectImage;
    }
}
