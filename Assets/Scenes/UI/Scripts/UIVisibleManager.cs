/////////////////////////
// UI�\���Ǘ��N���X    //
// ����ҁF�O�c�T�P    //
/////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIVisibleManager : MonoBehaviour
{
    //���[���h�Z���N�gUI
    [SerializeField] GameObject m_SWorldCanvas;

    //�X�e�[�W�Z���N�gUI
    [SerializeField] GameObject m_SStageCanvas;

    //�X�e�[�W�Z���N�g������
    bool m_IsStageSelect = false;

    //�v���C����
    bool m_IsPlayHide = false;

    //���̃��[���h
    string m_NextWorld;

    //���̃X�e�[�W
    string m_NextStage;

    // Start is called before the first frame update
    void Start()
    {
        //�@�ی�����Ȃ�
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        //�v���C���͕\�����Ȃ�
        if(m_IsPlayHide)
        {
            m_SWorldCanvas.SetActive(false);
            m_SStageCanvas.SetActive(false);
            return;
        }

        //�X�e�[�W�Z���N�g�����邩
        if(m_IsStageSelect)
        {
            m_SWorldCanvas.SetActive(false);
            m_SStageCanvas.SetActive(true);
        }
        //���[���h�Z���N�g�����邩
        else
        {
            m_SWorldCanvas.SetActive(true);
            m_SStageCanvas.SetActive(false);
        }
    }


    //�{�^���̖��̂��擾���A���̃V�[���Ɉڍs����������
    //���[���h�I���͕s�K�v�ɂȂ�̂Ŕ�\��
    public void WorldBottonsClick(GameObject gameObject)
    {
        m_IsStageSelect = true;
        m_NextWorld = gameObject.name;
    }

    //�X�e�[�W�̃{�^�����������ƂŃV�[���̐؂�ւ����s��
    public void StageBottonsClick(GameObject gameObject)
    {
        m_NextStage = gameObject.name;

        SceneManager.LoadScene(m_NextWorld);

        m_IsStageSelect = false;

        m_IsPlayHide = true;
    }

    //�X�e�[�W���̎擾(�ꍇ�ɂ���Ă�NextWorld�𑫂�)
    public string GetStageName()
    {
        return m_NextStage;
    }

    //�v���C���Ă��邩���Ă��Ȃ����؂�ւ���
    public void ChangeIsPlayed()
    {
        m_IsPlayHide = false;
    }

    //�C���X�^���X��
    private static UIVisibleManager instance;
    public static UIVisibleManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (UIVisibleManager)FindObjectOfType(typeof(UIVisibleManager));

                if (instance == null)
                {
                    Debug.LogError(typeof(UIVisibleManager) + "is nothing");
                }
            }
            return instance;
        }
    }
}
