/////////////////////////
// �v���C���[�N���X    //
// ����ҁF�O�c�T�P    //
/////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    //�����Ă��邩
    private bool m_IsFalling;
    //�J�n�A�ĊJ�ʒu
    [SerializeField] private GameObject m_StartPos;
    //���W�b�h�{�f�B
    [SerializeField] private Rigidbody rb;
    //�{�[���̃X�s�[�h
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        //������
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 acceleration;

        //  �L�[�{�[�h����
        acceleration.x = Input.GetAxis("Horizontal") * speed;

        acceleration.z = Input.GetAxis("Vertical") * speed;

        ////  �����x�Z���T�[
        //acceleration.x = Input.acceleration.x * 2;

        //acceleration.z = Input.acceleration.y * 2;

        //rb.AddForce(new Vector3(acceleration.x, rb.velocity.y, acceleration.z));


        rb.velocity = new Vector3(acceleration.x, rb.velocity.y, acceleration.z);

    }

    private void OnTriggerEnter(Collider other)
    {
        //�S�[�����ɗ�������
        if(other.gameObject.tag == "Finish")
        {
            //���U���g�V�[���ɑJ��
            SceneManager.LoadScene("New Scene");
        }

        //���ɗ�����DeathLine�ɐG�ꂽ��ʒu���Z�b�g
        if (other.gameObject.tag == "DeathLine")
        {
            Reset();
        }
    }


    private void Reset()
    {
        //�ʒu�A���x���Z�b�g
        this.gameObject.transform.position = m_StartPos.transform.position;

        rb.velocity = Vector3.zero;

    }

    void OnGUI()
    {
        //GUILayout.TextArea("nowLayer = " + this.gameObject.layer.ToString());

        //Vector3 acceleration = Input.acceleration;

        ////�e�L�X�g�G���A�Ƃ��āA�[���ɂ�����d�͂̕����iVector3�j���e�L�X�g�Ƃ��ĕ\������
        //GUILayout.TextArea("acceleration.x = " + acceleration.x.ToString());
        //GUILayout.TextArea("acceleration.y = " + acceleration.y.ToString());
        //GUILayout.TextArea("acceleration.z = " + acceleration.z.ToString());
    }
}
