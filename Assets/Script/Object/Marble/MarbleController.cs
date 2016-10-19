using System;
using System.Collections.Generic;
using UnityEngine;

public class MarbleController : MonoBehaviour
{
    [SerializeField]
    private GameObject m_Marble;
    private Rigidbody m_RigidBody;

    void Awake()
    {
        if (m_Marble != null)
        {
            m_RigidBody = m_Marble.GetComponent<Rigidbody>();
        }
    }

    void Update()
    {
        if (m_RigidBody == null || m_RigidBody.velocity == Vector3.zero) return;

        if (m_RigidBody.velocity.magnitude < 0.1f)
        {
            m_RigidBody.velocity = Vector3.zero;
            m_RigidBody.angularVelocity = Vector3.zero;
        }
    }

}
