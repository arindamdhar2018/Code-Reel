using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using dataClass;
using System.IO;


public class Savejson : MonoBehaviour
{
    string filename = "Score.json";
    string path;
    SaveData gameData = new SaveData();
    //private int totalCount = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        
        path = Application.persistentDataPath + "/" + filename;
        Debug.Log(Game_Manager.instance.saveDataList.Count);
    }
       

    public void SaveData()
    {
        gameData.TotalPlayTime = (Game_Manager.instance.GetComponent<response_time>().GlobalresponseTime).ToString();

        if (Game_Manager.instance.saveDataList.Count < 5)
        {
            for (int item = Game_Manager.instance.gameInfo.Userscore.Count; item < 5; item++)
            {
                GameInfo info = new GameInfo();  
                
                if (item == 0)
                {
                    Game_Manager.instance.gameInfo.Userscore.Add(info.addDefaultData("Level 1"));
                }

                if (item == 1)
                {
                    Game_Manager.instance.gameInfo.Userscore.Add(info.addDefaultData("Level 2"));
                }

                if (item == 2)
                {
                    Game_Manager.instance.gameInfo.Userscore.Add(info.addDefaultData("Level 3"));
                }

                if (item == 3)
                {
                    Game_Manager.instance.gameInfo.Userscore.Add(info.addDefaultData("Level 4"));
                }

                if (item == 4)
                {
                    Game_Manager.instance.gameInfo.Userscore.Add(info.addDefaultData("Level 5"));
                }
            }
        }


        for (int item = 0 ; item < Game_Manager.instance.saveDataList.Count; item++)
        {
            gameData.saveDataList.Add(Game_Manager.instance.saveDataList[item]);
        }       
       

        string Content= JsonUtility.ToJson(gameData,true);
        File.WriteAllText(path, Content);
    }


}
