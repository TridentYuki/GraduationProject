///////////////////////////
// 指定ステージ生成クラス//
// 製作者：前田裕輝      //
///////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCreate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // CubeプレハブをGameObject型で取得
        GameObject obj = (GameObject)Resources.Load(UIVisibleManager.Instance.GetStageName());
        // Cubeプレハブを元に、インスタンスを生成、
        Instantiate(obj, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
    }
}
