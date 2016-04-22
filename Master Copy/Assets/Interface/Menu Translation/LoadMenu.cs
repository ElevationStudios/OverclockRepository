using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenu : MonoBehaviour {

	public string level;

	public void LoadScene() {
		SceneManager.LoadScene (level);
	}
}