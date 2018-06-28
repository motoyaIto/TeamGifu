using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour {

    //非同期動作で使用する
    private AsyncOperation async;

    //シーンロード中に表示するUI画面
    [SerializeField]
    private GameObject loadUI;

    //読み込み率を表示するスライダー
    [SerializeField]
    private Slider slider;

    public void NextScene()
    {
        //ロード画面UIをアクティブにする
        loadUI.SetActive(true);

        //コルーチンを開始
        StartCoroutine("LoadData");

        //サウンドを鳴らす
        SoundManager.PlaySe("start",-1,0.5f);
    }

	IEnumerator LoadData()
    {
        //シーンの読み込みをする
        async = SceneManager.LoadSceneAsync("PlayScene");


        //読み込みが終わるまで進捗状況をスライダーの値に反映する
        while(!async.isDone)
        {
            var progressVal = Mathf.Clamp01(async.progress / 0.9f);
            slider.value = progressVal;
            yield return null;
        }

        //async.allowSceneActivation = false;

    }
}
