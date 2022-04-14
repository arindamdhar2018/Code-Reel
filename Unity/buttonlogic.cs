using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class buttonlogic : MonoBehaviour
{

    public object_Movement objectmovement;
    public Scene_Load sceneload;
    private bool isArrayEqual = true;
    public GameObject correct;
    public GameObject incorrect;
    public Button L_Button;
    public Button A_Button;
    public Button Pause_Button;
    public Button Help_Button;
    public response_time responsetime;
    public GameObject pauseMenu;
    public GameObject helpMenu;


    void Awake()
    {
        //responsetime = GetComponent<response_time>();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        responsetime = GetComponent<response_time>();
        correct.SetActive(false);
        incorrect.SetActive(false);

        L_Button.interactable = false;
        A_Button.interactable = false;

        pauseMenu.SetActive(false);
        helpMenu.SetActive(false);
        //Help_Button.setacti
        objectmovement = GameObject.FindObjectOfType<object_Movement>();
        sceneload = GameObject.FindObjectOfType<Scene_Load>();

        //Array.Sort(objectmovement.initialID);
        //Array.Sort(objectmovement.endID);

        StartCoroutine(arraySorting(3f));
    }
     
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            if(Game_Manager.instance.GetComponent<buttonlogic>().L_Button.interactable == true)
            {
                buttonpress_L();
            }
            
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (Game_Manager.instance.GetComponent<buttonlogic>().A_Button.interactable == true)
            {
                buttonpress_A();
            }
            
        }              
       

    }

    void button_logic()
    {
        if (objectmovement.initialID.Length == objectmovement.endID.Length)
        {
                        
            for (int i = 0; i < objectmovement.endID.Length; i++)
            {

                if (objectmovement.endID[i] != objectmovement.initialID[i])
                {
                    isArrayEqual = false;
                }
            }
        }
        else
        {

            isArrayEqual = false;
        }


    
    }

    public void buttonpress_L()
    {
        sceneload.timerflag = true;        
        responsetime.stopStopWatch();
        button_logic();
                

        if (isArrayEqual)
        {
            //responsetime.stopStopWatch();
            //Debug.Log("Correct");
            correct_toggle(true);
            incorrect_toggle(false);
            addData(true);
        }
        else
        {
            //responsetime.stopStopWatch();
            //Debug.Log("Incorrect");
            correct_toggle(false);
            incorrect_toggle(true);
            addData(false);

        }

        L_Button.interactable = false;
        A_Button.interactable = false;

        StartCoroutine(disablePopUp(3f));
        

    }

    public void buttonpress_A()
    {
        sceneload.timerflag = true;        
        responsetime.stopStopWatch();
        button_logic();
        

        if (isArrayEqual)
        {
            //responsetime.stopStopWatch();
            //Debug.Log("Incorrect");
            correct_toggle(false);
            incorrect_toggle(true);
            addData(false);
        }
        else
        {
            //responsetime.stopStopWatch();
            //Debug.Log("Correct");
            correct_toggle(true);
            incorrect_toggle(false);
            addData(true);

        }

        L_Button.interactable = false;
        A_Button.interactable = false;

        StartCoroutine(disablePopUp(3f));
        
    }

    public void correct_toggle(bool value)
    {
        correct.SetActive(value);        
        incorrect.SetActive(value);
        
    }

    public void incorrect_toggle(bool value)
    {

        incorrect.SetActive(value);
        incorrect.SetActive(value);
        
    }

    IEnumerator disablePopUp(float time)
    {
        yield return new WaitForSeconds(time);

        correct.SetActive(false);
        incorrect.SetActive(false);
    }

    public void resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        Pause_Button.interactable = true;
        Help_Button.interactable = true;
    }

    public void pause()
    {
        if (Start_Menu.instance.flag == false)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            Pause_Button.interactable = false;
            Help_Button.interactable = false;
        }
        
    }

    public void help()
    {
        if (Start_Menu.instance.flag == false)
        {
            helpMenu.SetActive(true);
            Time.timeScale = 0f;
            Help_Button.interactable = false;
            Pause_Button.interactable = false;
        }
        
    }

    public void helpclose()
    {

        helpMenu.SetActive(false);
        Time.timeScale = 1f;
        Help_Button.interactable = true;
        Pause_Button.interactable = true;
    }

    public void addData(bool value)
    {
        Game_Manager.instance.playlistadd(SceneManager.GetActiveScene().name, responsetime.responseTime, value);      

    }

    IEnumerator arraySorting(float time)
    {
        yield return new WaitForSeconds(time);

        Array.Sort(objectmovement.initialID);
        Array.Sort(objectmovement.endID);
    }
}
