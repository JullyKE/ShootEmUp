using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
	public void OpenLevel(string name)
	{
		SceneManager.LoadScene(name);
	}
}
