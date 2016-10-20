using UnityEngine;
using System;
using System.Collections;

/// <summary>
/// 游戏入口
/// </summary>
public class InGameMain : MonoBehaviour 
{
    [SerializeField]
    private UIInGame m_cUIInGame;
    [SerializeField]
    private Transform m_Arrow;

    private Camera m_MainCamera;
    private GameObject m_cSphereOne;
    private GameObject m_cSphereTwo;

    private Vector3 m_CurDirction;

    public GameStatus m_CurGameStatus = GameStatus.None;
    public GameObject SphereOne { get { return m_cSphereOne; } }
    public GameObject SphereTwo { get { return m_cSphereTwo; } }
    public Vector3 CurDirction { get { return m_CurDirction; } }

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

        m_Arrow.position = new Vector3(m_cSphereOne.transform.position.x, 0.01f, m_cSphereOne.transform.position.z);
        
        m_cUIInGame.Init(this);
        m_CurGameStatus = GameStatus.PrepareForShoot;

        if (m_cSphereOne)
        {
            m_MainCamera.transform.localPosition = m_cSphereOne.transform.localPosition + Vector3.one * 2;
            SetCameraLookAt(m_cSphereOne.transform);
            UpdateDirectionArrow();
        }
	}

    void Update()
    {
        if (m_CurGameStatus == GameStatus.None) return;
        else if (m_CurGameStatus == GameStatus.PrepareForShoot)
        {
            // adjust shoot angle, change shooter, adjust force
            // angle 
#if UNITY_EDITOR
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                m_MainCamera.transform.RotateAround(m_cSphereOne.transform.position, Vector3.up, 1);
                UpdateDirectionArrow();
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                m_MainCamera.transform.RotateAround(m_cSphereOne.transform.position, Vector3.up, -1);
                UpdateDirectionArrow();
            }
#endif
            
        }
        else if (m_CurGameStatus == GameStatus.Shoot)
        {
            m_CurGameStatus = GameStatus.Moving;
        }
        else if (m_CurGameStatus == GameStatus.Moving)
        {
           
            if (m_cSphereOne.GetComponent<Rigidbody>().velocity == Vector3.zero)
            {
                m_CurGameStatus = GameStatus.WaitingForOthers;
            }
            else
            {
                if (m_cSphereOne.GetComponent<Rigidbody>().velocity.magnitude < 0.25f)
                {
                    m_cSphereOne.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    m_cSphereOne.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                }
            }
        }
        else if (m_CurGameStatus == GameStatus.WaitingForOthers)
        {

        }

    }

    private void SetCameraLookAt(Transform target)
    {
        m_MainCamera.transform.forward = Vector3.Normalize(target.position - m_MainCamera.transform.position);
    }

    private void UpdateDirectionArrow()
    {
        m_CurDirction = m_cSphereOne.transform.position - m_MainCamera.transform.position;
        m_CurDirction.y = 0;
        float angle = Vector3.Angle(m_CurDirction, Vector3.right);
        float dirction = Vector3.Dot(m_CurDirction, Vector3.forward);
        //Debug.Log("angle = " + angle + ", dirction = " + dirction);
        if (dirction < 0) angle = angle + 90;
        if (dirction > 0) angle = 90 - angle;
        m_Arrow.localRotation = Quaternion.Euler(90, angle, 0);
    }

}
