using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using UnityEditor;

public class Example : MonoBehaviour {

    [MenuItem("Tools/Example")]
    private static void Show()
    {
        var type = typeof(Editor)
            .Assembly
            .GetType("UnityEditor.Web.WebViewEditorWindowTabs")
        ;

        var attr =
            BindingFlags.Public |
            BindingFlags.Static |
            BindingFlags.FlattenHierarchy
        ;

        var methodInfo = type
            .GetMethod("Create", attr)
            .MakeGenericMethod(type)
        ;

        methodInfo.Invoke(null, new object[]
        {
            "Title", // ウィンドウのタイトル
            "https://google.co.jp", // URL
            300, // 横幅（最小）
            300, // 縦幅（最小）
            900, // 横幅（最大）
            900 // 縦幅（最大）
        });
    }
}
