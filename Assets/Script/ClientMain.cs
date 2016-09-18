using UnityEngine;
using System;
using System.Collections;

/// <summary>
/// 游戏入口
/// </summary>
public class ClientMain : MonoBehaviour 
{
    public UIInGame m_cUIInGame;

    private static ClientMain m_cClientMain;
    private GameObject m_cSphereOne;
    private GameObject m_cSphereTwo;


    private Quaternion m_qInitRotation;

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
        m_cSphereOne = GameObject.Find("Sphere1");
        m_cSphereOne.transform.localPosition = new Vector3(5, 1f, 0);
        m_cSphereTwo = GameObject.Find("Sphere2");
        m_cSphereTwo.transform.localPosition = new Vector3(-4, 0.6f, 0);
        
        Rigidbody sphere = m_cSphereOne.GetComponent<Rigidbody>();
        sphere.useGravity = true;
        sphere.isKinematic = false;

        m_cUIInGame.Init(m_cSphereOne,m_cSphereTwo);
	}
}
