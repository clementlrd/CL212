using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Vector3 destination;

    void OnTriggerEnter(Collider entity) {
        if (entity.gameObject.tag == "Player") {
            entity.transform.position = destination;
        }
    }
}
