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
    private Rigidbody m_cRigidOne;
    private Rigidbody m_cRigidTwo;

    private Vector3 m_CurDirction;
    private float m_fCameraTimeControl;
    private Vector3 m_v3Distance;
    private float m_fCameraPosY;
    private GameStates m_CurGameState = GameStates.None;

    public GameObject SphereOne { get { return m_cSphereOne; } }
    public GameObject SphereTwo { get { return m_cSphereTwo; } }
    public Vector3 CurDirction { get { return m_CurDirction; } }

    public GameStates GetCurGameState()
    {
        return m_CurGameState;
    }

	// Use this for initialization
	void Start()
    {
        m_MainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        if (m_MainCamera == null) Debug.LogError("Main Camera is null");
        m_cSphereOne = GameObject.Find("Sphere1");
        if (m_cSphereOne == null) Debug.LogError("Shpere1 is null");
        m_cSphereTwo = GameObject.Find("Sphere2");
        if (m_cSphereTwo == null) Debug.LogError("Sphere2 is null");
        m_cRigidOne = m_cSphereOne.GetComponent<Rigidbody>();
        m_cRigidTwo = m_cSphereTwo.GetComponent<Rigidbody>();
        if (m_cRigidOne == null) Debug.LogError("m_cRigidOne is null");
        if (m_cRigidTwo == null) Debug.LogError("m_cRigidTwo is null");
        
        InitGameState();
        m_cUIInGame.Init(this);

        
	}

    void Update()
    {
        if (m_CurGameState == GameStates.None) return;
        else if (m_CurGameState == GameStates.PrepareForShoot)
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
        else if (m_CurGameState == GameStates.Shoot)
        {
            m_CurGameState = GameStates.Moving;
            m_fCameraTimeControl = 0.3f;
            m_v3Distance = m_cSphereOne.transform.localPosition - m_MainCamera.transform.localPosition;
            m_v3Distance.y = 0;
            m_fCameraPosY = m_MainCamera.transform.localPosition.y;
        }
        else if (m_CurGameState == GameStates.Moving)
        {
            if (m_cSphereOne.GetComponent<Rigidbody>().velocity == Vector3.zero)
            {
                m_CurGameState = GameStates.WaitingForOthers;
                Debug.Log("Change game state to WaitingForOthers");
            }
            else
            {
                if (m_cSphereOne.GetComponent<Rigidbody>().velocity.magnitude < 0.25f)
                {
                    m_cSphereOne.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    m_cSphereOne.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                }
            }

            UpdateCameraPosition();
        }
        else if (m_CurGameState == GameStates.WaitingForOthers)
        {

        }

    }

    /// <summary>
    /// init object's states in game
    /// </summary>
    public void InitGameState()
    {
        m_cSphereOne.transform.localPosition = new Vector3(5, 1f, 0);
        m_cSphereTwo.transform.localPosition = new Vector3(-4, 0.6f, 0);

        m_cRigidOne.freezeRotation = true;
        m_cRigidTwo.freezeRotation = true;
        m_cRigidOne.velocity = Vector3.zero;
        m_cRigidTwo.velocity = Vector3.zero;

        m_CurGameState = GameStates.PrepareForShoot;

        m_Arrow.position = new Vector3(m_cSphereOne.transform.position.x, 0.01f, m_cSphereOne.transform.position.z);

        if (m_cSphereOne)
        {
            m_MainCamera.transform.localPosition = m_cSphereOne.transform.localPosition + Vector3.one * 2;
            SetCameraLookAt(m_cSphereOne.transform);
            UpdateDirectionArrow();
        }

    }

    
    public void ShootShpere(Vector3 force)
    {
        m_cRigidOne.freezeRotation = false;
        m_cRigidTwo.freezeRotation = false;

        m_cRigidOne.AddForce(force);
        m_CurGameState = GameStates.Shoot;
    }


    private void SetCameraLookAt(Transform target)
    {
        m_MainCamera.transform.forward = Vector3.Normalize(target.position - m_MainCamera.transform.position);
    }

    /// <summary>
    /// use an arrow to show current shoot direction
    /// </summary>
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
    
    /// <summary>
    /// make the camera flow player's bubble
    /// </summary>
    private void UpdateCameraPosition()
    {
        if (m_fCameraTimeControl > 0)
        {
            m_fCameraTimeControl -= Time.deltaTime;
        }
        else
        {
            Vector3 cur_cam_pos = Vector3.MoveTowards(m_MainCamera.transform.localPosition, m_cSphereOne.transform.localPosition - m_v3Distance, 0.05f);
            cur_cam_pos.y = m_fCameraPosY;
            m_MainCamera.transform.localPosition = cur_cam_pos;
        }
    }
}
