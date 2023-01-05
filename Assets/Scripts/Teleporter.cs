using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Vector3 destination;

    void Start() {
        Debug.Log("start");
    }
    void Update() {
    }

    void OnTriggerEnter(Collider entity) {
        Debug.Log("enter");
        Debug.Log(entity.gameObject.tag);
        if (entity.gameObject.tag == "Player") {
            entity.transform.position = destination;
        }
    }
}
