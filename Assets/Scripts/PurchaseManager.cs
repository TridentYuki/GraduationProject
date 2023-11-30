using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PurchaseManager : MonoBehaviour
{
    private int purchasedAdRemoval = 0; // �L����\�����ۋ��ς݂��ǂ����̃t���O
    public GameObject purchaseMenu; // �ۋ����j���[��UI�I�u�W�F�N�g���A�T�C��

    private void Start()
    {
        //���̕�����csv����ǂݎ��
        //�L���\���N���X�ɂ������̂����
        purchasedAdRemoval = PlayerPrefs.GetInt("KakinData");
        //

        if (purchasedAdRemoval != 0)
        {
            this.gameObject.SetActive(false);
        }
        ClosePurchaseMenu();
    }

    public void OpenPurchaseMenu()
    {
        Time.timeScale = 0.0f;

        // �ۋ����j���[��\������
        purchaseMenu.SetActive(true);
    }

    public void ClosePurchaseMenu()
    {
        Time.timeScale = 1.0f;

        // �ۋ����j���[���\���ɂ���
        purchaseMenu.SetActive(false);
    }

    public void PurchaseProduct()
    {
        // �ۋ����������s�i��F�L����\�����w���j
        if (purchasedAdRemoval == 0)
        {


            purchasedAdRemoval = 1; // �L����\�����ۋ��ς݂Ƃ���
            SavePlayerData(); // �v���C���[�f�[�^��ۑ�
            ClosePurchaseMenu(); // �ۋ����j���[�����
            this.gameObject.SetActive(false);


        }
        else
        {
            // �w�����s���̏���
            ClosePurchaseMenu();
            this.gameObject.SetActive(false);
        }
    }


    private void SavePlayerData()
    {
        // �v���C���[�f�[�^��ۑ����郍�W�b�N����������
        // ��FPlayerPrefs��t�@�C���Z�[�u�Ȃǂ��g�p���ăf�[�^���i��������

        //���̕�����csv�ɏ�������
        PlayerPrefs.SetInt("KakinData", purchasedAdRemoval);

    }


    public void ReSetKakinn()
    {
        purchasedAdRemoval = 0;
        SavePlayerData();
        this.gameObject.SetActive(true);
    }
}
