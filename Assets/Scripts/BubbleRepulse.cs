using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleRepulse : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    
    public float floatRepulseCoefficient = 1;
    public float controlerMass = 2;
    
    private GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        Player = GameObject.FindGameObjectsWithTag("Player")[0];
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 left_controller_pos = Player.transform.TransformPoint(OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch));
        //Quaternion left_controller_rot = OVRInput.GetLocalControllerRotation(OVRInput.Controller.LTouch);
        
        Vector3 right_controller_pos = Player.transform.TransformPoint(OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch));
        //Quaternion right_controller_rot = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch);
        
        
        Vector3 closest_controller_pos = left_controller_pos;
        //Quaternion closest_controller_rot = left_controller_rot
        
        if (Vector3.Distance(closest_controller_pos, m_Rigidbody.position) > Vector3.Distance(right_controller_pos, m_Rigidbody.position)) {
            closest_controller_pos = right_controller_pos;
            //closest_controller_rot = right_controller_rot
        }
        
        float distance = Vector3.Distance(m_Rigidbody.position, closest_controller_pos);
        Vector3 direction = m_Rigidbody.position - closest_controller_pos;
        direction = direction.normalized;
        
        m_Rigidbody.AddForce(floatRepulseCoefficient * controlerMass * m_Rigidbody.mass / distance / distance * direction);
    }
}

