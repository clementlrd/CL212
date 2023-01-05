using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDest : MonoBehaviour
{
    public GameObject bubble;
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        switch (col.gameObject.tag)
        {
            case "Bubble":
                break;
            default:
                Destroy(this.bubble);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
