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
    private bool m_bStartCountTime = false;
    private float m_fPressTime = 0;
    public void Init(InGameMain main)
    {
        m_cInGameMain = main;
        m_SliderForce.value = 0;
        UIEventListener.Get(m_ButtonShoot).onPress += OnPressShoot;
    }
    
    private void OnPressShoot(GameObject go, bool state)
    {
        if (m_cInGameMain.GetCurGameState() != GameStates.PrepareForShoot) return;
        if (state)
        {
            m_bStartCountTime = true;
        }
        else
        {
            // calculate force and direction
            float shoot_force = m_fPressTime / MAX_PRESS_TIME * MAX_SHOOT_FORCE;
            Vector3 shoot_dirction = m_cInGameMain.CurDirction.normalized;
            // if the force greater than max force, it should be a fail shoot
            if (shoot_force > MAX_SHOOT_FORCE)
            {
                shoot_force = UnityEngine.Random.Range(10, 100);
                m_SliderForce.value = shoot_force / MAX_SHOOT_FORCE;
            }

            m_cInGameMain.ShootShpere(shoot_dirction * shoot_force);

            m_bStartCountTime = false;
            m_fPressTime = 0;
        }
    }

    public void OnClickReset()
    {
        if (m_cInGameMain.GetCurGameState() == GameStates.Moving) return;
        m_cInGameMain.InitGameState();
        m_SliderForce.value = 0;
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
