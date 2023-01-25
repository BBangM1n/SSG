using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Option : MonoBehaviour
{
    static bool isPause;
    public static GameObject OptionPanel;
    public static GameObject QuitPanel;
    // Start is called before the first frame update
    void Start()
    {
       isPause = false;
       OptionPanel = GameObject.Find("OptionPanel");
       OptionPanel.SetActive(false);
       QuitPanel = GameObject.Find("QuitPanel");
       QuitPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex < 3)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
                {
                    if (isPause ==false)
                    {
                        Time.timeScale = 0;
                        QuitPanel.SetActive(true);
                        isPause = true;
                        return;
                    }
                    else if (isPause == true)
                    {
                        Time.timeScale = 1;
                        QuitPanel.SetActive(false);
                        isPause = false;
                        return;
                    }
                }
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.Escape))
                {
                    if (isPause ==false)
                    {
                        Time.timeScale = 0;
                        OptionPanel.SetActive(true);
                        isPause = true;
                        return;
                    }
                    else if (isPause == true)
                    {
                        Time.timeScale = 1;
                        OptionPanel.SetActive(false);
                        isPause = false;
                        return;
                    }
                }
        }
    }

    public void GameContinue()
    {
        Time.timeScale = 1;
        QuitPanel.SetActive(false);
        isPause = false;
        return;
    }
    
}
