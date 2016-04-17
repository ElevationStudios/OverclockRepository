using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SettingsTranslation : MonoBehaviour {

    public Text back;
    public Text volume;
    public Text brightness;

    void Start() {
        UpdateText();
    }

    public void UpdateText() {
        back.text = Localisation.GetString("Back");
        volume.text = Localisation.GetString("Volume");
        brightness.text = Localisation.GetString("Brightness");
    }
}