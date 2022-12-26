using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerTracker : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    
    public GameObject Player;
    
    public Vector3 left_controller_pos;
    public Vector3 right_controller_pos;
    
    public Quaternion left_controller_rot;
    public Quaternion right_controller_rot;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        left_controller_pos = Player.transform.TransformPoint(OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch));
        left_controller_rot = OVRInput.GetLocalControllerRotation(OVRInput.Controller.LTouch);
        
        right_controller_pos = Player.transform.TransformPoint(OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch));
        right_controller_rot = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch);
        
        Debug.Log(left_controller_pos);
        
        m_Rigidbody.position = left_controller_pos;
        m_Rigidbody.rotation = left_controller_rot;
    }
}

