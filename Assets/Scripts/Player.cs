/////////////////////////
// プレイヤークラス    //
// 製作者：前田裕輝    //
/////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    //落ちているか
    private bool m_IsFalling;
    //開始、再開位置
    [SerializeField] private GameObject m_StartPos;
    //リジッドボディ
    [SerializeField] private Rigidbody rb;
    //ボールのスピード
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        //初期化
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 acceleration;

        //  キーボード操作
        acceleration.x = Input.GetAxis("Horizontal") * speed;

        acceleration.z = Input.GetAxis("Vertical") * speed;

        ////  加速度センサー
        //acceleration.x = Input.acceleration.x * 2;

        //acceleration.z = Input.acceleration.y * 2;

        //rb.AddForce(new Vector3(acceleration.x, rb.velocity.y, acceleration.z));


        rb.velocity = new Vector3(acceleration.x, rb.velocity.y, acceleration.z);

    }

    private void OnTriggerEnter(Collider other)
    {
        //ゴール穴に落ちたら
        if(other.gameObject.tag == "Finish")
        {
            //リザルトシーンに遷移
            SceneManager.LoadScene("New Scene");
        }

        //穴に落ちてDeathLineに触れたら位置リセット
        if (other.gameObject.tag == "DeathLine")
        {
            Reset();
        }
    }


    private void Reset()
    {
        //位置、速度リセット
        this.gameObject.transform.position = m_StartPos.transform.position;

        rb.velocity = Vector3.zero;

    }

    void OnGUI()
    {
        //GUILayout.TextArea("nowLayer = " + this.gameObject.layer.ToString());

        //Vector3 acceleration = Input.acceleration;

        ////テキストエリアとして、端末にかかる重力の方向（Vector3）をテキストとして表示する
        //GUILayout.TextArea("acceleration.x = " + acceleration.x.ToString());
        //GUILayout.TextArea("acceleration.y = " + acceleration.y.ToString());
        //GUILayout.TextArea("acceleration.z = " + acceleration.z.ToString());
    }
}
