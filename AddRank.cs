using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AddRank : MonoBehaviour
{
	// string inputPassword;
	string AddURL = "http://52.79.139.236/AddRank.php";
	string clearURL = "http://52.79.139.236/clear.php";
    public string Name = Userinfo.userinfoID;
	public int score;

    public void Add_Rank () 
    {
		if(SceneManager.GetActiveScene().buildIndex == 4)
		{
			score = 1;
			StartCoroutine (AddToRank(Name));
			StartCoroutine (Chap1Clear(Name,score));
			Userinfo.UserScore = score;
		}
		else if (SceneManager.GetActiveScene().buildIndex == 5)
		{
			score = 2;
			StartCoroutine (AddToRank(Name));
			StartCoroutine (Chap2Clear(Name,score));
			Userinfo.UserScore = score;
		}
	}


    IEnumerator AddToRank(string userName)
	{
		WWWForm form = new WWWForm ();
        form.AddField ("userNamePost", Userinfo.userinfoID);

		WWW www = new WWW (AddURL, form);
		yield return www;

		// if(www.text == "Connection Success")
        // {
        //     Debug.Log ("DB올라감");
		//     // Time.timeScale = 1;
        //     // SceneManager.LoadScene(3);
		// }
	}

	IEnumerator Chap1Clear(string userName,int num)
	{
		
		WWWForm form = new WWWForm ();
        form.AddField("userNamePost", Userinfo.userinfoID);
		form.AddField("ChapClearPost", score);

		WWW www = new WWW (clearURL, form);
		yield return www;
		
		// if(www.text == "Connection Success")
        // {
        //     Debug.Log ("DB올라감");
		//     // Time.timeScale = 1;
        //     // SceneManager.LoadScene(3);
		// }
	}

	IEnumerator Chap2Clear(string userName,int num)
	{
		
		WWWForm form = new WWWForm ();
        form.AddField("userNamePost", Userinfo.userinfoID);
		form.AddField("ChapClearPost", score);

		WWW www = new WWW (clearURL, form);
		yield return www;

		// if(www.text == "Connection Success")
        // {
        //     Debug.Log ("DB올라감");
		//     // Time.timeScale = 1;
        //     // SceneManager.LoadScene(3);
		// }
	}
}
