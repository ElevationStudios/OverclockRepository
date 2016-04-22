using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuTranslation : MonoBehaviour {

    public Text newGame;
    public Text credits;
    public Text settings;
    public Text extras;
    public Text quit;
    public static bool loaded = false;
   
    void OnEnable() {
        newGame.text = Localisation.GetString("NewGame");
        credits.text = Localisation.GetString("Credits");
        settings.text = Localisation.GetString("Settings");
        extras.text = Localisation.GetString("Extra");
        quit.text = Localisation.GetString("Quit");
    }

    void Awake() {
        if (!loaded) {
            Localisation.Instance.LoadLanguage(Localisation.Language.English);
            loaded = true;
        }
    }
}