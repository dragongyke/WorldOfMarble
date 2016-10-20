using System;
using UnityEngine;

public class UIInGame : MonoBehaviour
{
    private InGameMain m_cInGameMain;
    private GameObject m_cSphereOne;
    private GameObject m_cSphereTwo;

    private Rigidbody m_RigidbodyOne;
    private Rigidbody m_RigidbodyTwo;

    public void Init(InGameMain main)
    {
        m_cInGameMain = main;
        m_cSphereOne = main.SphereOne;
        m_cSphereTwo = main.SphereTwo;
        m_RigidbodyOne = m_cSphereOne.GetComponent<Rigidbody>();
        m_RigidbodyTwo = m_cSphereTwo.GetComponent<Rigidbody>();
    }

    public void OnClickShoot()
    {
        m_RigidbodyOne.freezeRotation = false;
        m_RigidbodyTwo.freezeRotation = false;
        m_RigidbodyOne.AddForce(m_cInGameMain.CurDirction.normalized * 500);
        m_cInGameMain.m_CurGameStatus = GameStatus.Shoot;
    }

    public void OnClickReset()
    {
        m_cSphereOne.transform.localPosition = new Vector3(5, 1f, 0);
        m_cSphereTwo.transform.localPosition = new Vector3(-4, 0.6f, 0);

        m_RigidbodyOne.freezeRotation = true;
        m_RigidbodyTwo.freezeRotation = true;
        m_RigidbodyOne.velocity = Vector3.zero;
        m_RigidbodyTwo.velocity = Vector3.zero;
    }
}
