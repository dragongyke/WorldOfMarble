using UnityEngine;
using System;
using System.Collections;

/// <summary>
/// 游戏入口
/// </summary>
public class ClientMain : MonoBehaviour {

    private static ClientMain m_cClientMain;
    private Camera m_cCamera3D;
    private GameObject m_cSphereOne;
    private GameObject m_cSphereTwo;

    private Quaternion m_qInitRotation;
    private float m_fTimeControl;

    void Awake()
    {
        if (m_cClientMain == null)
            m_cClientMain = this;
        else
        {
            Debug.LogError("ClientMain is only one instance!");
            return;
        }
    }
	// Use this for initialization
	void Start()
    {
        GameObject camera = GameObject.Find("Main Camera");
        m_cCamera3D = camera.GetComponent<Camera>();
        m_cSphereOne = GameObject.Find("Sphere1");
        m_cSphereOne.transform.localPosition = new Vector3(5, 1f, 0);
        m_cSphereTwo = GameObject.Find("Sphere2");
        m_cSphereTwo.transform.localPosition = new Vector3(-4, 0.6f, 0);
        
        Rigidbody sphere = m_cSphereOne.GetComponent<Rigidbody>();
        sphere.useGravity = true;
        sphere.isKinematic = false;
        m_fTimeControl = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        
    }

    private void OnCollisionEnter(Collision col)
    {
        Debug.Log("Begin Touch");
    }

    void OnGUI()
    {
        Rigidbody sphere_1 = m_cSphereOne.GetComponent<Rigidbody>();
        Rigidbody sphere_2 = m_cSphereTwo.GetComponent<Rigidbody>();

        bool is_reset = GUI.Button(new Rect(1024 - 120, 576 - 50, 50, 50), "Reset");
        if (is_reset)
        {
            m_cSphereOne.transform.localPosition = new Vector3(5, 1f, 0);
            m_cSphereTwo.transform.localPosition = new Vector3(-4, 0.6f, 0);

            sphere_1.freezeRotation = true;
            sphere_2.freezeRotation = true;
            
            sphere_1.velocity = Vector3.zero;
            sphere_2.velocity = Vector3.zero;
        }

        bool is_shoot = GUI.Button(new Rect(1024 - 50, 576 - 50, 50, 50), "弹出");
        if (is_shoot)
        {
            sphere_1.freezeRotation = false;
            sphere_2.freezeRotation = false;
            sphere_1.AddForce(new Vector3(-1, 0, 0.05f) * 400);
        }



    }
}
