using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;

public class Joystick : MonoBehaviour
{
    public float speed;
    
    void Update()
    {
        var joystickAxis = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick, OVRInput.Controller.LTouch);
        
        float fixedY = gameObject.transform.position.y;
        
        gameObject.transform.position += (transform.right * joystickAxis.x + transform.forward * joystickAxis.y) * Time.deltaTime * speed;
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, fixedY, gameObject.transform.position.z);
        
    }
    
}