using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModelRotator : MonoBehaviour
{
    Rigidbody rb;

//    bool Flag = false;

    Vector3 acceleration;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        
        //acceleration = Input.acceleration;

        ////accelerationz = Input.GetAxis("Horizontal") * 15;

        ////accelerationx = Input.GetAxis("Vertical") * 15;

        //if (acceleration.x > 0.1f || acceleration.y > 0.1f ||
        //   acceleration.x < -0.1f || acceleration.y < -0.1f)
        //{
        //    this.transform.Rotate(acceleration.y, 0.0f, -acceleration.x);
        //}
    }

    private void FixedUpdate()
    {


        //rb.MoveRotation(Quaternion.Euler(acceleration.x, 0.0f, -acceleration.z));
    }

    public void ModelAcceleration()
    {
        //Vector3 acceleration = Input.acceleration;

       

        //this.transform.Rotate(accelerationy, -accelerationx, 0);
    }

//    void OnGUI()
//    {
//        Vector3 acceleration = Input.acceleration;
//
//        //テキストエリアとして、端末にかかる重力の方向（Vector3）をテキストとして表示する
//        GUILayout.TextArea("acceleration.x = " + acceleration.x.ToString());
//        GUILayout.TextArea("acceleration.y = " + acceleration.y.ToString());
//        GUILayout.TextArea("acceleration.z = " + acceleration.z.ToString());
//
//        GUILayout.TextArea("transform.rotation.x = " + this.transform.rotation.x.ToString());
//        GUILayout.TextArea("transform.rotation.y = " + this.transform.rotation.y.ToString());
//        GUILayout.TextArea("transform.rotation.z = " + this.transform.rotation.z.ToString());
//
//        GUILayout.TextArea("nowLayer = " + this.gameObject.layer.ToString());
//
//        //        GUILayout.TextArea(m_Gyro.enabled.ToString());
//        //       if(!SystemInfo.supportsGyroscope)
//        //       { GUILayout.TextArea("Not Use Gyroscope"); }
//        //       if (!SystemInfo.supportsAccelerometer)
//        //       { GUILayout.TextArea("Not Use Accelerometer"); }
//        //       else { GUILayout.TextArea("Can Use Accelerometer"); }
//        GUILayout.TextArea(SystemInfo.operatingSystem);
//    }
}
