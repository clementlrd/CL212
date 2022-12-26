using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundRepulse : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public float m_Thrust = 20f;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (m_Rigidbody.position.y > 0) {
            m_Rigidbody.AddForce(m_Thrust/m_Rigidbody.position.y * - m_Rigidbody.velocity.normalized);
        } 
        
    }
}

