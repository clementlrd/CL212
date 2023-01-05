using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : Object
{
    public GameObject sphere;
    // Start is called before the first frame update
    public Bubble(Material materialRef)
    {
        sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        //Add physics to the bubble
        Rigidbody currentRb;
        currentRb = sphere.AddComponent<Rigidbody>();
        currentRb.detectCollisions = true;
        currentRb.useGravity = false; //Disable gravity to float
        //Set material
        sphere.GetComponent<Renderer>().material = materialRef;
        //Generate a random size
        System.Random rd = new System.Random();
        double randomValue = rd.NextDouble() * (1 - 0.1) + 0.1; //To have a double between 0.1 and 1
        Vector3 newScale = new Vector3((float)randomValue, (float)randomValue, (float)randomValue);
        sphere.transform.localScale = newScale;
        double randomSpeed1 = rd.NextDouble() * 2 -1; //To have a double between -1 and 1
        double randomSpeed2 = rd.NextDouble() * (1-0.1) + 0.1; // To have y>0 to not go down
        double randomSpeed3 = rd.NextDouble() * 2 - 1;
        Vector3 newSpeed = new Vector3((float)randomSpeed1, (float)randomSpeed2, (float)randomSpeed3);
        currentRb.velocity = newSpeed ;
    }
    void OnCollisionEnter(Collision col)
    {
        switch (col.gameObject.GetComponent<Renderer>().material.name) {
            case "BubbleBW":
            case "BubbleC":
                break;
            default:
                Destroy(col.gameObject);
                break;
        }
    }
}

public class Spawner : MonoBehaviour
{
    public Material materialRef;
    private int compteur;

    // Start is called before the first frame update
    void Start()
    {
        compteur = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (compteur == 100)
        {
            Bubble new_bubble = new Bubble(materialRef);
            new_bubble.sphere.transform.parent = gameObject.transform;
            compteur = 0;
        }
        else { compteur++; }
        
    }
}
