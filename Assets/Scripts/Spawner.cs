using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : Object
{
    public GameObject sphere;
    // Start is called before the first frame update
    public Bubble(Material materialRef, float scale,float minSpeed, float maxSpeed)
    {
        sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.gameObject.tag = "Bubble";
        // sphere.AddComponent<BubbleRepulse>();
        CollisionDest destroyer;
        destroyer = sphere.AddComponent<CollisionDest>();
        var myref= sphere;
        destroyer.bubble = myref;
        //Add physics to the bubble
        Rigidbody currentRb;
        currentRb = sphere.AddComponent<Rigidbody>();
        currentRb.detectCollisions = true;
        currentRb.useGravity = false; //Disable gravity to float
        SphereCollider spherecol;
        spherecol = sphere.GetComponent<SphereCollider>();
        spherecol.isTrigger = true;
        //Set material
        sphere.GetComponent<Renderer>().material = materialRef;
        //Generate a random size
        System.Random rd = new System.Random();
        double randomValue = scale*(rd.NextDouble() * (0.75 - 0.05) + 0.05); //To have a double between 0.1 and 1
        Vector3 newScale = new Vector3((float)randomValue, (float)randomValue, (float)randomValue);
        sphere.transform.localScale = newScale;
        double randomSpeed1 = rd.NextDouble() * (maxSpeed-minSpeed) +minSpeed; //To have a double between -1 and 1
        double randomSpeed2 = rd.NextDouble() * (maxSpeed-0.05) + 0.05; // To have y>0 to not go down
        double randomSpeed3 = rd.NextDouble() * (maxSpeed - minSpeed) + minSpeed;
        Vector3 newSpeed = new Vector3((float)randomSpeed1, (float)randomSpeed2, (float)randomSpeed3);
        currentRb.velocity = newSpeed ;

    }
}

public class Spawner : MonoBehaviour
{
    public Material materialRef;
    private int compteur;
    public float scale=1;
    public int delay;
    public float minSpeed;
    public float maxSpeed;
    public float radius;
    public float height;

    // Start is called before the first frame update
    void Start()
    {
        compteur = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (compteur == delay)
        {
            Bubble new_bubble = new Bubble(materialRef,scale,minSpeed,maxSpeed);
            new_bubble.sphere.transform.parent = gameObject.transform;
            System.Random rd = new System.Random();
            double randomPos1 = rd.NextDouble() * radius; 
            double randomPos2 = rd.NextDouble() * height; 
            double randomPos3 = rd.NextDouble() * radius;
            new_bubble.sphere.transform.position = transform.position + new Vector3((float)randomPos1,(float)randomPos2,(float)randomPos3);
            compteur = 0;
        }
        else { compteur++; }
        
    }
}
