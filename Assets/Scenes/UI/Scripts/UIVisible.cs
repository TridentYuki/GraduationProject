/////////////////////////
// UI�\���N���X        //
// ����ҁF�O�c�T�P    //
/////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIVisible : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //�V�[���ɗ������ɕ\������
        UIVisibleManager.Instance.ChangeIsPlayed();
    }
}
