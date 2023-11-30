/////////////////////////
// UI表示管理クラス    //
// 製作者：前田裕輝    //
/////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIVisibleManager : MonoBehaviour
{
    //ワールドセレクトUI
    [SerializeField] GameObject m_SWorldCanvas;

    //ステージセレクトUI
    [SerializeField] GameObject m_SStageCanvas;

    //ステージセレクトしたか
    bool m_IsStageSelect = false;

    //プレイ中か
    bool m_IsPlayHide = false;

    //次のワールド
    string m_NextWorld;

    //次のステージ
    string m_NextStage;

    // Start is called before the first frame update
    void Start()
    {
        //繊維後消さない
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        //プレイ中は表示しない
        if(m_IsPlayHide)
        {
            m_SWorldCanvas.SetActive(false);
            m_SStageCanvas.SetActive(false);
            return;
        }

        //ステージセレクトをするか
        if(m_IsStageSelect)
        {
            m_SWorldCanvas.SetActive(false);
            m_SStageCanvas.SetActive(true);
        }
        //ワールドセレクトをするか
        else
        {
            m_SWorldCanvas.SetActive(true);
            m_SStageCanvas.SetActive(false);
        }
    }


    //ボタンの名称を取得し、次のシーンに移行する先を決定
    //ワールド選択は不必要になるので非表示
    public void WorldBottonsClick(GameObject gameObject)
    {
        m_IsStageSelect = true;
        m_NextWorld = gameObject.name;
    }

    //ステージのボタンを押すことでシーンの切り替えを行う
    public void StageBottonsClick(GameObject gameObject)
    {
        m_NextStage = gameObject.name;

        SceneManager.LoadScene(m_NextWorld);

        m_IsStageSelect = false;

        m_IsPlayHide = true;
    }

    //ステージ名の取得(場合によってはNextWorldを足す)
    public string GetStageName()
    {
        return m_NextStage;
    }

    //プレイしているかしていないか切り替える
    public void ChangeIsPlayed()
    {
        m_IsPlayHide = false;
    }

    //インスタンス化
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
