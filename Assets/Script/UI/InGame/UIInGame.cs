using System;
using UnityEngine;

public class UIInGame : MonoBehaviour
{
    private const float MAX_PRESS_TIME = 2.0f;
    private const float MAX_SHOOT_FORCE = 800f;

    [SerializeField]
    private UISlider m_SliderForce;
    [SerializeField]
    private GameObject m_ButtonShoot;

    private InGameMain m_cInGameMain;
    private GameObject m_cSphereOne;
    private GameObject m_cSphereTwo;

    private Rigidbody m_RigidbodyOne;
    private Rigidbody m_RigidbodyTwo;

    private bool m_bStartCountTime = false;
    private float m_fPressTime = 0;
    public void Init(InGameMain main)
    {
        m_cInGameMain = main;
        m_cSphereOne = main.SphereOne;
        m_cSphereTwo = main.SphereTwo;
        m_RigidbodyOne = m_cSphereOne.GetComponent<Rigidbody>();
        m_RigidbodyTwo = m_cSphereTwo.GetComponent<Rigidbody>();
        m_SliderForce.value = 0;
        UIEventListener.Get(m_ButtonShoot).onPress += OnPressShoot;
    }
    
    private void OnPressShoot(GameObject go, bool state)
    {
        if (m_cInGameMain.m_CurGameStatus != GameStatus.PrepareForShoot) return;
        if (state)
        {
            m_bStartCountTime = true;
            Debug.Log("OnPressShoot");
        }
        else
        {
            m_RigidbodyOne.freezeRotation = false;
            m_RigidbodyTwo.freezeRotation = false;

            // calculate force and direction
            float shoot_force = m_fPressTime / MAX_PRESS_TIME * MAX_SHOOT_FORCE;
            Vector3 shoot_dirction = m_cInGameMain.CurDirction.normalized;
            // if the force greater than max force, it should be a fail shoot
            if (shoot_force > MAX_SHOOT_FORCE)
            {
                shoot_force = UnityEngine.Random.Range(10, 100);
                m_SliderForce.value = shoot_force / MAX_SHOOT_FORCE;
            }

            m_RigidbodyOne.AddForce(shoot_dirction * shoot_force);
            m_cInGameMain.m_CurGameStatus = GameStatus.Shoot;
            m_bStartCountTime = false;
            m_fPressTime = 0;
            Debug.Log("OnClickShoot");
        }
    }

    public void OnClickReset()
    {
        m_cSphereOne.transform.localPosition = new Vector3(5, 1f, 0);
        m_cSphereTwo.transform.localPosition = new Vector3(-4, 0.6f, 0);

        m_RigidbodyOne.freezeRotation = true;
        m_RigidbodyTwo.freezeRotation = true;
        m_RigidbodyOne.velocity = Vector3.zero;
        m_RigidbodyTwo.velocity = Vector3.zero;

        m_SliderForce.value = 0;
        m_cInGameMain.m_CurGameStatus = GameStatus.PrepareForShoot;
    }

    void Update()
    {
        if (m_bStartCountTime)
        {
            m_fPressTime += Time.deltaTime;
            m_SliderForce.value = m_fPressTime / MAX_PRESS_TIME;
            if (m_fPressTime > MAX_PRESS_TIME)
            {
                OnPressShoot(null, false);
            }
        }
    }

}
