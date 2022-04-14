using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using dataClass;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager instance;
    public Text sceneIndex;
    public GameObject mainui;
    public GameObject levelDisplay;
    public Text levelIndex;
    public GameInfo gameInfo;
    public List<GameInfo> saveDataList;    
    

    void Awake()
    {

        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        SceneManager.LoadSceneAsync(2,LoadSceneMode.Additive);
        //SceneManager.LoadSceneAsync(1);
    }

    // Start is called before the first frame update
    void Start()
    {
        saveDataList = new List<GameInfo>();
        gameInfo = new GameInfo();
        mainui.SetActive(true);
        Start_Menu.instance.levelDisplay.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playlistadd(string name, string time, bool value)
    {

        Data _newPlaylist = gameInfo.addToLevelData(name, time, value);
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            _newPlaylist.levelName = "Level 1";
        }
        gameInfo.Userscore.Add(_newPlaylist);        
        
    }

    

}
