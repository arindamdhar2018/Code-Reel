using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{

    private Vector3 forceDir;
    public float Speed = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Ball")
            {
                //Debug.Log("collision");
                forceDir = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
                collision.gameObject.GetComponent<Rigidbody>().AddForce(forceDir * Speed);
                collision.gameObject.GetComponent<Rigidbody>().AddTorque(forceDir * Speed);
            }   

    }
}
