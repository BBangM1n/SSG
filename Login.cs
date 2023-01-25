using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Login : MonoBehaviour {

	public InputField IDInputField;
	public InputField PWInputField;

	string LoginURL = "http://52.79.139.236/login.php";

	public void login () {
		StartCoroutine (LoginToDB (IDInputField.text, PWInputField.text));
	}

	IEnumerator LoginToDB(string userID,string password)
	{
		WWWForm form = new WWWForm ();
		form.AddField ("userIDPost", userID);
		form.AddField ("passwordPost", password);

		WWW www = new WWW (LoginURL, form);

		yield return www;
		if(www.text == "login success"){
			SceneManager.LoadScene("캐릭터 선택");
			Userinfo.userinfoID = userID;
		}
		
	}
}