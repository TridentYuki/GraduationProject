/////////////////////////
// UI表示クラス        //
// 製作者：前田裕輝    //
/////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIVisible : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //シーンに来た時に表示する
        UIVisibleManager.Instance.ChangeIsPlayed();
    }
}
