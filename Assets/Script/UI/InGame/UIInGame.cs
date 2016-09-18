using System;
using UnityEngine;

public class UIInGame : MonoBehaviour
{
    private GameObject m_cSphereOne;
    private GameObject m_cSphereTwo;

    private Rigidbody m_RigidbodyOne;
    private Rigidbody m_RigidbodyTwo;

    public void Init(GameObject obj1, GameObject Obj2)
    {
        m_cSphereOne = obj1;
        m_cSphereTwo = Obj2;
        m_RigidbodyOne = m_cSphereOne.GetComponent<Rigidbody>();
        m_RigidbodyTwo = m_cSphereTwo.GetComponent<Rigidbody>();
    }

    public void OnClickShoot()
    {
        m_RigidbodyOne.freezeRotation = false;
        m_RigidbodyTwo.freezeRotation = false;
        m_RigidbodyOne.AddForce(new Vector3(-1, 0, 0.02f) * 800);
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
