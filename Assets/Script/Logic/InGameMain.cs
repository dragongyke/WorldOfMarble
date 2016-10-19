using UnityEngine;
using System;
using System.Collections;

/// <summary>
/// 游戏入口
/// </summary>
public class InGameMain : MonoBehaviour 
{
    public UIInGame m_cUIInGame;

    private static InGameMain m_cInGameMain;
    private Camera m_MainCamera;
    private GameObject m_cSphereOne;
    private GameObject m_cSphereTwo;
    private GameStatus m_CurGameStatus = GameStatus.None;

    private Quaternion m_qInitRotation;

    void Awake()
    {
        if (m_cInGameMain == null)
            m_cInGameMain = this;
        else
        {
            Debug.LogError("InGameMain is only one instance!");
            return;
        }
    }
	// Use this for initialization
	void Start()
    {
        m_MainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        if (m_MainCamera == null)
        {
            Debug.LogError("Main Camera is null");
        }
        m_cSphereOne = GameObject.Find("Sphere1");
        m_cSphereOne.transform.localPosition = new Vector3(5, 1f, 0);
        m_cSphereTwo = GameObject.Find("Sphere2");
        m_cSphereTwo.transform.localPosition = new Vector3(-4, 0.6f, 0);
        
        m_cUIInGame.Init(m_cSphereOne,m_cSphereTwo);
        m_CurGameStatus = GameStatus.PrepareForShoot;

        if (m_cSphereOne)
        {
            m_MainCamera.transform.localPosition = m_cSphereOne.transform.localPosition + Vector3.one * 2;
            SetCameraLookAt(m_cSphereOne.transform);
        }
	}

    void Update()
    {
        if (m_CurGameStatus == GameStatus.None) return;
        else if (m_CurGameStatus == GameStatus.PrepareForShoot)
        {
            // adjust shoot angle, change shooter, adjust force
            // angle 

            
        }
        else if (m_CurGameStatus == GameStatus.Shoot)
        {

        }
        else if (m_CurGameStatus == GameStatus.WaitingForOthers)
        {

        }

    }

    private void SetCameraLookAt(Transform target)
    {
        m_MainCamera.transform.forward = Vector3.Normalize(target.position - m_MainCamera.transform.position);
    }

}
