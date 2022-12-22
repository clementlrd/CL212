using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : Object
{
    public GameObject sphere;
    // Start is called before the first frame update
    public Bubble(Material materialRef, Vector3 floatSpeed)
    {
        sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        //Add physics to the bubble
        Rigidbody currentRb;
        currentRb = sphere.AddComponent<Rigidbody>();
        currentRb.detectCollisions = true;
        currentRb.useGravity = false; //Disable gravity to float
        currentRb.velocity = floatSpeed; //Go to floatSpeed
        //Set material
        sphere.GetComponent<Renderer>().material = materialRef;
        //Generate a random size
        System.Random rd = new System.Random();
        double randomValue = rd.NextDouble() * (1 - 0.1) + 0.1; //To have a float between 0.1 and 1
        Vector3 newScale = new Vector3((float)randomValue, (float)randomValue, (float)randomValue);
        sphere.transform.localScale = newScale;
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.GetComponent<Renderer>().material.name == "BubbleBW" || col.gameObject.GetComponent<Renderer>().material.name == "BubbleC")
        {

        }
        else
        {
            Destroy(col.gameObject);
        };
    }
}

public class Spawner : MonoBehaviour
{
    public Material materialRef;
    public Vector3 floatSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Wait 2 seconds before spawning
        System.Threading.Thread.Sleep(2000);
        Bubble new_bubble = new Bubble(materialRef,floatSpeed);
        GameObject new_object = new_bubble.sphere;
        Instantiate(new_object,new_object.transform.position,Quaternion.identity);
        
    }
}
