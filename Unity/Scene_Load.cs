using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class Scene_Load : MonoBehaviour
{
    
    public float timer = 0.0f;    
    public bool timerflag;    
    public float sceneLoadTime = 3.0f;   
    public int index;
    private int CurrentSceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        CurrentSceneIndex = currenSceneIndex();
        timerflag = false;        
        timer = 0.0f;
        Game_Manager.instance.GetComponent<buttonlogic>().L_Button.interactable = false;
        Game_Manager.instance.GetComponent<buttonlogic>().A_Button.interactable = false;
        Game_Manager.instance.GetComponent<buttonlogic>().objectmovement = GameObject.FindObjectOfType<object_Movement>();
        Game_Manager.instance.GetComponent<buttonlogic>().sceneload = GameObject.FindObjectOfType<Scene_Load>();

        StartCoroutine(disablelevelwindow(2f));
        //Game_Manager.instance.levelDisplay.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (timerflag == true)
        {
            timer += Time.deltaTime;
            if (timer > sceneLoadTime)
            {
                SceneManager.LoadSceneAsync(index);
                timerReset();
                Game_Manager.instance.sceneIndex.text = (index-1).ToString();
                //Game_Manager.instance.levelDisplay.SetActive(true);
                //Game_Manager.instance.levelIndex.text = (index - 1).ToString();
                if(index == 7)
                {
                    Start_Menu.instance.levelDisplay.SetActive(false);
                }
                else
                {
                    Start_Menu.instance.levelDisplay.SetActive(true);
                    Start_Menu.instance.levelIndex.text = (index - 1).ToString();
                }
                
                timerflag = false;
                
            }

        }     
        
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            Game_Manager.instance.GetComponent<response_time>().GlobalstartStopWatch();
        }
        

    }

    void timerReset()
    {
        Game_Manager.instance.GetComponent<response_time>().currentTime = 0f;
        
    }

    private int currenSceneIndex()
    {
        int buildindex = SceneManager.GetActiveScene().buildIndex;
        return buildindex;
    }

    IEnumerator disablelevelwindow(float time)
    {
        yield return new WaitForSeconds(time);
        //Game_Manager.instance.levelDisplay.SetActive(false);
        Start_Menu.instance.levelDisplay.SetActive(false);
    }

}

