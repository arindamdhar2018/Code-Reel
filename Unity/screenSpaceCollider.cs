using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenSpaceCollider : MonoBehaviour
{
    public float colDepth = 4f;
    public float zPosition = 0f;
    private Vector2 screenSize;
    private Transform topCollider;
    private Transform bottomCollider;
    private Transform leftCollider;
    private Transform rightCollider;
    private Transform backCollider;
    private Transform frontCollider;
    private Vector3 cameraPos;
    public PhysicMaterial physicsMaterial;
    public float ScrrenYOffset = 1f;
    public float ScrrenXOffset = 1f;

    // Start is called before the first frame update
    void Start()
    {
        //Generate our empty objects
        topCollider = new GameObject().transform;
        bottomCollider = new GameObject().transform;
        rightCollider = new GameObject().transform;
        leftCollider = new GameObject().transform;
        backCollider = new GameObject().transform;
        frontCollider = new GameObject().transform;

        //Name our objects 
        topCollider.name = "TopCollider";
        bottomCollider.name = "BottomCollider";
        rightCollider.name = "RightCollider";
        leftCollider.name = "LeftCollider";
        backCollider.name = "backCollider";
        frontCollider.name = "frontCollider";

        //Add the colliders
        topCollider.gameObject.AddComponent<BoxCollider>();
        bottomCollider.gameObject.AddComponent<BoxCollider>();
        rightCollider.gameObject.AddComponent<BoxCollider>();
        leftCollider.gameObject.AddComponent<BoxCollider>();
        backCollider.gameObject.AddComponent<BoxCollider>();
        frontCollider.gameObject.AddComponent<BoxCollider>();

        //Add the Collision Detection
        topCollider.gameObject.AddComponent<CollisionDetection>();
        bottomCollider.gameObject.AddComponent<CollisionDetection>();
        rightCollider.gameObject.AddComponent<CollisionDetection>();
        leftCollider.gameObject.AddComponent<CollisionDetection>();
        backCollider.gameObject.AddComponent<CollisionDetection>();
        frontCollider.gameObject.AddComponent<CollisionDetection>();

        //Make them the child of whatever object this script is on, preferably on the Camera so the objects move with the camera without extra scripting
        topCollider.parent = transform;
        bottomCollider.parent = transform;
        rightCollider.parent = transform;
        leftCollider.parent = transform;
        backCollider.parent = transform;
        frontCollider.parent = transform;           
        

        //Generate world space point information for position and scale calculations
        cameraPos = Camera.main.transform.position;
        screenSize.x = Vector2.Distance(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)), Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0))) * 0.5f;
        screenSize.y = Vector2.Distance(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)), Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height))) * 0.5f;

        //Change our scale and positions to match the edges of the screen...   
        rightCollider.localScale = new Vector3(colDepth, screenSize.y * 2, colDepth);
        rightCollider.position = new Vector3(cameraPos.x + screenSize.x + (rightCollider.localScale.x * 0.5f) - ScrrenXOffset, cameraPos.y, zPosition);
        leftCollider.localScale = new Vector3(colDepth, screenSize.y * 2, colDepth);
        leftCollider.position = new Vector3(cameraPos.x - screenSize.x - (leftCollider.localScale.x * 0.5f) + ScrrenXOffset, cameraPos.y, zPosition);
        topCollider.localScale = new Vector3(screenSize.x * 2, colDepth, colDepth);
        topCollider.position = new Vector3(cameraPos.x, cameraPos.y + screenSize.y + (topCollider.localScale.y * 0.5f) - ScrrenYOffset, zPosition);
        bottomCollider.localScale = new Vector3(screenSize.x * 2, colDepth, colDepth);
        bottomCollider.position = new Vector3(cameraPos.x, cameraPos.y - screenSize.y - (bottomCollider.localScale.y * 0.5f) + ScrrenYOffset - 0.5f, zPosition);
        backCollider.localScale = new Vector3(screenSize.x * 2, screenSize.y * 2, colDepth);
        backCollider.position = new Vector3(cameraPos.x,cameraPos.y, colDepth);
        frontCollider.localScale = new Vector3(screenSize.x * 2, screenSize.y * 2, colDepth);
        frontCollider.position = new Vector3(cameraPos.x, cameraPos.y, -colDepth);

        //Change Physics Material...   
        rightCollider.GetComponent<Collider>().material = physicsMaterial;
        leftCollider.GetComponent<Collider>().material = physicsMaterial;
        topCollider.GetComponent<Collider>().material = physicsMaterial;
        bottomCollider.GetComponent<Collider>().material = physicsMaterial;
        frontCollider.GetComponent<Collider>().material = physicsMaterial;
        backCollider.GetComponent<Collider>().material = physicsMaterial;

       
    }

    // Update is called once per frame
    void Update()
    {
        
    }   
    
}
