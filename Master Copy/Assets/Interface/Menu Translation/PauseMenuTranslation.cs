using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseMenuTranslation : MonoBehaviour {

	public Text pause;
	public Text resume;
	public Text mainMenu;
	public Text quit;

	void Start () {
		pause.text = Localisation.GetString ("Pause");
		resume.text = Localisation.GetString ("Resume");
		mainMenu.text = Localisation.GetString ("MainMenu");
		quit.text = Localisation.GetString ("Quit");
	}
}