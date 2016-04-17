using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChangeLanguage : MonoBehaviour {
   
    public Dropdown dropdown;

    void Awake() {
        dropdown.value = (Localisation.Instance.currentLang == Localisation.Language.English ? 0 : 1);
        dropdown.onValueChanged.AddListener(delegate {
            OnOptionChange(dropdown);
        });
    }

    void OnOptionChange(Dropdown d) {
        if (d.value == 0) { 
            Localisation.Instance.LoadLanguage(Localisation.Language.English);
        } else {
            Localisation.Instance.LoadLanguage(Localisation.Language.Russian);
        }
        GetComponentInParent<SettingsTranslation>().UpdateText();
    }
}