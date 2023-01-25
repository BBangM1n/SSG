using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastPortal : MonoBehaviour
{
    public GameObject UIBtn;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Time.timeScale = 0;
            UIBtn.SetActive(true);
        }

        if (col.gameObject.tag == "Player2")
        {
            Time.timeScale = 0;
            UIBtn.SetActive(true);
        }

    }

    
    //닿으면 클리어 뜨고 몇초 후 메인화면으로 이동
}

