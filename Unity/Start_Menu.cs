using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Start_Menu : MonoBehaviour
{
    public static Start_Menu instance;
    public GameObject levelDisplay;
    public Text levelIndex;
    public GameObject forcequitPanel;
    public GameObject info;
    public bool flag;
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

       
    }
    // Start is called before the first frame update
    void Start()
    {
        forcequitPanel.SetActive(false);
        info.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void close()
    {
        forcequitPanel.SetActive(true);
        Time.timeScale = 0f;
        flag = true;
    }

    public void quit_yes()
    {
        forcequitPanel.SetActive(false);
        SceneManager.LoadScene(8);
        //forecquitload(1f);
    }

    public void quit_no()
    {
        forcequitPanel.SetActive(false);
        Time.timeScale = 1f;
        flag = false;
    }

    IEnumerator forecquitload(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(8);
    }
}
