using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Localisation {

	public static Dictionary<string, string> strings = new Dictionary<string, string>();
    private static Localisation instance;
    public Localisation.Language currentLang = Localisation.Language.English;

    public static Localisation Instance {
        get {
            if (instance == null) {
                Debug.Log("Being called");
                instance = new Localisation();
            }
            return instance;
        }
    }

	public enum Language {
		English, Russian
	}

	public void LoadLanguage(Language language) {
        currentLang = language;
        Debug.Log("Loading Language: " + language.ToString());
		strings.Clear ();
		string line;
		string[] splitLine = new string[2];
		Debug.Log(Application.dataPath);
		System.IO.StreamReader file = new System.IO.StreamReader(Application.dataPath + "/Translation/" + language.ToString() + ".txt");
		Debug.Log (file == null);
		while((line = file.ReadLine()) != null) {
			if (line.StartsWith ("#") || line.Length == 0) {
				continue;
			}
			splitLine = line.Split('=');
			strings.Add(splitLine[0], splitLine[1]);
		}
		file.Close();
       // PrintMap();
    }

	public static string GetString(string line) {
		return strings [line];
	}

    public void PrintMap() {
        Debug.Log("Now Printing Map");
        foreach (KeyValuePair<string, string> con in strings) {
            Debug.Log(string.Format("Key = {0}, Value = {1}", con.Key, con.Value));
        }
    }
}