///////////////////////////
// �w��X�e�[�W�����N���X//
// ����ҁF�O�c�T�P      //
///////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCreate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Cube�v���n�u��GameObject�^�Ŏ擾
        GameObject obj = (GameObject)Resources.Load(UIVisibleManager.Instance.GetStageName());
        // Cube�v���n�u�����ɁA�C���X�^���X�𐶐��A
        Instantiate(obj, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
    }
}
