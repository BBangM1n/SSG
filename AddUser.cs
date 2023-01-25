using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AddUser : MonoBehaviour{

	public InputField IDInputField;
	public InputField PWInputField;
    public InputField NameInputField;
 	// string inputUserName;
	// string inputPassword;

	string AddURL = "http://52.79.139.236/AddUser.php";
    
    public void Add_user () {
		StartCoroutine (AddToDB (IDInputField.text, PWInputField.text, NameInputField.text));
	}

    IEnumerator AddToDB(string userID,string password,string userName)
	{
		WWWForm form = new WWWForm ();
		form.AddField ("userIDPost", userID);
		form.AddField ("passwordPost", password);
        form.AddField ("userNamePost", userName);

		WWW www = new WWW (AddURL, form);
		Debug.Log (www.text);
        
		yield return www;
		if(www.text == "Add User"){
			SceneManager.LoadScene("로그인화면");
		}
		
	}
	
}

