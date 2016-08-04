using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

    private static int SCORE = 0;

    private GameObject scoreText;

	// Use this for initialization
	void Start () {
        scoreText = GameObject.Find("ScoreText");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ChangeScore(int change)
    {
        SCORE += change;
        UpdateGUI();
    }

    void UpdateGUI()
    {
        scoreText.GetComponent<Text>().text = "Score: " + SCORE;
    }
}
