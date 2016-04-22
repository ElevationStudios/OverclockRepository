using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CreditsTranslation : MonoBehaviour {

	public Text back;
	public Text projectby;
	public Text studioLead;
	public Text scripter;
	public Text artist;
	public Text animationArtist;
	public Text audioDesigner;
	public Text localization;
	public Text qaTester;
	public Text specialThanks;

	public static bool loaded = false;
	
	void Awake() {
		if (!loaded) {
			Localisation.Instance.LoadLanguage(Localisation.Language.English);
			loaded = true;
		}
	}
	
	void OnEnable() {
		back.text = Localisation.GetString("Back");
        projectby.text = Localisation.GetString("Project By");
        studioLead.text = Localisation.GetString("Studio Lead");
        scripter.text = Localisation.GetString("Scripters");
		artist.text = Localisation.GetString("Artist");
		animationArtist.text = Localisation.GetString("Animation Artists");
		audioDesigner.text = Localisation.GetString("Audio Designer");
		localization.text = Localisation.GetString("Localization");
		qaTester.text = Localisation.GetString("QA Testers");
		specialThanks.text = Localisation.GetString("Special Thanks");
    }
}
