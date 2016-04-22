using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LivesDisplay: MonoBehaviour {

    [SerializeField] private Text lives;
    GameObject player;
    // Use this for initialization
    void Start () {
        lives = GetComponent<Text>();
        player = GameObject.Find("Carlos");
    }

    // Update is called once per frame
    void Update () {
        lives.text = "Carlos Count: " + player.GetComponent<Player>().lives.ToString();
    }
}
