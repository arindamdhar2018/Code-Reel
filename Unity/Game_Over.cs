using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using dataClass;
using UnityEngine.UI;

public class Game_Over : MonoBehaviour
{

    public int loadindex = 1;
    public Data playerData;
    public Text playtime;
    public Text[] LevelName= new Text[5];
    public Text[] Responsetime = new Text[5];
    public Toggle[] Value = new Toggle[5];
    public Image[] Level_1_Color = new Image[3];
    public Image[] Level_2_Color = new Image[3];
    public Image[] Level_3_Color = new Image[3];
    public Image[] Level_4_Color = new Image[3];
    public Image[] Level_5_Color = new Image[3];
    private GameInfo resetGameInfo;
    public GameObject Thankyou;
    public GameObject Quitmenu;
    public float timer = 0.0f;
    public float waitTime = 5.0f;
    private int colorIndex;
    

    // Start is called before the first frame update
    void Start()
    {

        Game_Manager.instance.GetComponent<response_time>().GlobalstopStopWatch();
        Thankyou.SetActive(false);
        Quitmenu.SetActive(true);
        Game_Manager.instance.mainui.SetActive(false);
        resetGameInfo = new GameInfo();
        playtime.text =(Game_Manager.instance.GetComponent<response_time>().GlobalresponseTime).ToString();
        

    // user score
       /* for (int item = 0; item < Game_Manager.instance.gameInfo.Userscore.Count; item ++)
        {
            LevelName[item].text = Game_Manager.instance.gameInfo.Userscore[item].levelName;
        }
        */
        for (int item = 0; item < Game_Manager.instance.gameInfo.Userscore.Count; item++)
        {
            Responsetime[item].text = Game_Manager.instance.gameInfo.Userscore[item].responseTime;
        }

        for (int item = 0; item < Game_Manager.instance.gameInfo.Userscore.Count; item++)
        {
            Value[item].isOn = Game_Manager.instance.gameInfo.Userscore[item].result;
        }

        //Color       
        colorIndex = Game_Manager.instance.gameInfo.Userscore.Count;        


        for (int itemCount = 0; itemCount < colorIndex; itemCount++)
        {
            if (itemCount == 0)
            {
                if (Game_Manager.instance.gameInfo.Userscore[itemCount].result == true)
                {
                    for (int colitem = 0; colitem < 3; colitem++)
                    {
                        Level_1_Color[colitem].color = Color.green;
                    }
                }

                else if (Game_Manager.instance.gameInfo.Userscore[itemCount].result == false)
                {
                    for (int colitem = 0; colitem < 3; colitem++)
                    {
                        Level_1_Color[colitem].color = Color.red;
                    }
                }
                else
                {
                    for (int colitem = 0; colitem < 3; colitem++)
                    {
                        Level_1_Color[colitem].color = Color.gray;
                    }
                }
            }

            if (itemCount == 1)
            {
                if (Game_Manager.instance.gameInfo.Userscore[itemCount].result == true)
                {
                    for (int colitem = 0; colitem < 3; colitem++)
                    {
                        Level_2_Color[colitem].color = Color.green;
                    }
                }
                else if (Game_Manager.instance.gameInfo.Userscore[itemCount].result == false)
                {
                    for (int colitem = 0; colitem < 3; colitem++)
                    {
                        Level_2_Color[colitem].color = Color.red;
                    }
                }

                else
                {
                    for (int colitem = 0; colitem < 3; colitem++)
                    {
                        Level_2_Color[colitem].color = Color.gray;
                    }
                }
            }

            if (itemCount == 2)
            {
                if (Game_Manager.instance.gameInfo.Userscore[itemCount].result == true)
                {
                    for (int colitem = 0; colitem < 3; colitem++)
                    {
                        Level_3_Color[colitem].color = Color.green;
                    }
                }
                else if (Game_Manager.instance.gameInfo.Userscore[itemCount].result == false)
                {
                    for (int colitem = 0; colitem < 3; colitem++)
                    {
                        Level_3_Color[colitem].color = Color.red;
                    }
                }

                else
                {
                    for (int colitem = 0; colitem < 3; colitem++)
                    {
                        Level_3_Color[colitem].color = Color.gray;
                    }
                }
            }

            if (itemCount == 3)
            {
                if (Game_Manager.instance.gameInfo.Userscore[itemCount].result == true)
                {
                    for (int colitem = 0; colitem < 3; colitem++)
                    {
                        Level_4_Color[colitem].color = Color.green;
                    }
                }
                else if (Game_Manager.instance.gameInfo.Userscore[itemCount].result == false)
                {
                    for (int colitem = 0; colitem < 3; colitem++)
                    {
                        Level_4_Color[colitem].color = Color.red;
                    }
                }

                else
                {
                    for (int colitem = 0; colitem < 3; colitem++)
                    {
                        Level_4_Color[colitem].color = Color.gray;
                    }
                }
            }

            if (itemCount == 4)
            {
                if (Game_Manager.instance.gameInfo.Userscore[itemCount].result == true)
                {
                    for (int colitem = 0; colitem < 3; colitem++)
                    {
                        Level_5_Color[colitem].color = Color.green;
                    }
                }
                else if (Game_Manager.instance.gameInfo.Userscore[itemCount].result == false)
                {
                    for (int colitem = 0; colitem < 3; colitem++)
                    {
                        Level_5_Color[colitem].color = Color.red;
                    }
                }

                else
                {
                    for (int colitem = 0; colitem < 3; colitem++)
                    {
                        Level_5_Color[colitem].color = Color.gray;
                    }
                }
            }

        }     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void restart()
    {
        SceneManager.LoadSceneAsync(loadindex);
        Game_Manager.instance.sceneIndex.text = loadindex.ToString();
        Start_Menu.instance.levelIndex.text = loadindex.ToString();
        Game_Manager.instance.mainui.SetActive(true);
        savedatalist();
        //resetGameInfo.Userscore.Clear();
        Game_Manager.instance.gameInfo = new GameInfo();

    }


    public void quit()
    {
        
        savedatalist();        
        Quitmenu.SetActive(false);
        Thankyou.SetActive(true);
        Time.timeScale = 1f;
        StartCoroutine(quit(3f));
        Debug.Log("aaa");

    }

    public void savedatalist()
    {
        Game_Manager.instance.saveDataList.Add(Game_Manager.instance.gameInfo);
        
    }

    IEnumerator quit(float time)
    {

        yield return new WaitForSeconds(time);        
        Application.Quit();
        Debug.Log("quit");

    }

}
