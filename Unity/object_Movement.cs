using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class object_Movement : MonoBehaviour
{

    Rigidbody rb;
    private Vector3 forceDir;
    public float Speed = 4f;
    public GameObject[] animobjects;
    public GameObject objecttype;
    public int arraylength = 5;
    public float startanimationdelay = 5;
    public float startspawndelay = 2;
    private float timer = 0.0f;
    public float waitTime = 15.0f;
    public Material startmaterial;
    public Material animtmaterial;
    public int[] initialID;
    public int[] endID;
    public int colorchangeno = 1;
    public Game_Manager gamemanager;
    private response_time responsetime;
    public bool stopwatchflag;
    public float ScrrenYOffset = 100f;
    public float ScrrenXOffset = 100f;


    void Awake()
    {
        gamemanager = GameObject.FindObjectOfType<Game_Manager>();
        //responsetime = gamemanager.GetComponent<response_time>();
        responsetime = Game_Manager.instance.GetComponent<response_time>();


    }

    // Start is called before the first frame update
    void Start()
    {

        stopwatchflag = false;
        animobjects = new GameObject[arraylength];


        StartCoroutine(Startspawn(startspawndelay));
        StartCoroutine(Startmotion(startanimationdelay));

        gamemanager = GameObject.FindObjectOfType<Game_Manager>();


    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > waitTime)
        {            
            stopanim();
        }
               
    }

    void FixedUpdate()
    {
        //rb.AddForce(forceDir * Speed);
        //rb.AddForce(Random.Range(-50.0f, 50.0f) * Speed, Random.Range(-50.0f, 50.0f) * Speed, Random.Range(-1.0f, 1.0f) * Speed);
        //rb.MovePosition(transform.position + forceDir * Time.deltaTime * Speed);
    }

    /*void OnCollisionEnter(Collision collision)
    {
        //rb.AddForce(Random.Range(-50.0f, 50.0f) * Speed, Random.Range(-50.0f, 50.0f) * Speed, Random.Range(-1.0f, 1.0f) * Speed, ForceMode.Impulse);
        //rb.AddForce(Random.Range(-1.0f, 1.0f) * Speed, Random.Range(-1.0f, 1.0f) * Speed, Random.Range(-1.0f, 1.0f) * Speed, ForceMode.Impulse);
    }
    */



    IEnumerator Startspawn(float time)
    {
        yield return new WaitForSeconds(time);

        for (int i = 0; i < animobjects.Length; i++)
        {
            float spawnY = Random.Range
                (Camera.main.ScreenToWorldPoint(new Vector2(0, 0 + ScrrenYOffset)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height - ScrrenYOffset)).y);
            float spawnX = Random.Range
                (Camera.main.ScreenToWorldPoint(new Vector2(0 + ScrrenXOffset, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width - ScrrenXOffset, 0)).x);

            Vector3 spawnPosition = new Vector3(spawnX, spawnY, Random.Range(-2.5f,2.5f));
            Quaternion spawnrotation = Quaternion.Euler(Random.Range(-350.0f, 360.0f), Random.Range(-350.0f, 360.0f), 0);
            GameObject go = Instantiate(objecttype, spawnPosition, spawnrotation) as GameObject;
            float scalerange = (float)Random.Range(0.4f, 0.5f);
            go.gameObject.transform.localScale = new Vector3(scalerange, scalerange, scalerange);
            animobjects[i] = go;
           
        }

        foreach (GameObject item in animobjects)
        {
            rb = item.GetComponent<Rigidbody>();
            rb.isKinematic = true;
        }


        initialID = new int[colorchangeno];
        endID = new int[colorchangeno];

        for (int i = 0; i < colorchangeno; i++)
        {
            initialID[i] = Random.Range(0, animobjects.Length);
            endID[i] = Random.Range(0, animobjects.Length);
        }

        foreach (int item in initialID)
        {
            animobjects[item].GetComponent<Renderer>().material = startmaterial;
        }



    }

    IEnumerator Startmotion(float time)
    {
       
        yield return new WaitForSeconds(time);

        foreach (GameObject item in animobjects)
        {
            rb = item.GetComponent<Rigidbody>();
            rb.isKinematic = false;
        }

        foreach (int item in initialID)
        {
            animobjects[item].GetComponent<Renderer>().material = animtmaterial;
        }
                
        foreach (GameObject item in animobjects)
        {
            rb = item.GetComponent<Rigidbody>();
            forceDir = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
            rb.AddForce(forceDir * Speed, ForceMode.Impulse);
            rb.AddTorque(forceDir  * Speed, ForceMode.Acceleration);
        }

    }

    void stopanim()
    {
        foreach (GameObject item in animobjects)
        {
            rb = item.GetComponent<Rigidbody>();
            rb.isKinematic = true;
        }

        foreach (int item in endID)
        {
            animobjects[item].GetComponent<Renderer>().material = startmaterial;
        }

        if (stopwatchflag == false)
        {
            responsetime.startStopWatch();
            Game_Manager.instance.GetComponent<buttonlogic>().L_Button.interactable = true;
            Game_Manager.instance.GetComponent<buttonlogic>().A_Button.interactable = true;
            stopwatchflag = true;
        }
    }
        

}



