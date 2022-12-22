using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    public Material materialRef;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Wait 2 seconds before spawning
        System.Threading.Thread.Sleep(2000);
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        //Add physics to the bubble
        Rigidbody currentRb;
        currentRb = sphere.AddComponent<Rigidbody>();
        currentRb.detectCollisions = true;
        currentRb.useGravity = false; //Disable gravity to float
        currentRb.velocity = new Vector3(0.0f, 1.0f, 0.0f); //Go up with speed of 1
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
        //Set material
        sphere.GetComponent<Renderer>().material = materialRef;
        //Generate a random size
        System.Random rd = new System.Random();
        double randomValue = rd.NextDouble() * (1-0.1)+0.1; //To have a float between 0.1 and 1
        Vector3 newScale = new Vector3((float)randomValue, (float)randomValue, (float)randomValue);
        sphere.transform.localScale = newScale;

        Instantiate(sphere, sphere.transform.position, Quaternion.identity);
        
    }
}
