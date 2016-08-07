using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

    private static int SCORE = 0;
    private GameObject scoreText;
    public int highScore;

	// Use this for initialization
	void Start () {
        scoreText = GameObject.Find("ScoreText");
        DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ResetScore()
    {
        SCORE = 0;
    }

    public void ChangeScore(int change)
    {
        SCORE += change;
        if(SCORE > highScore)
        {
            highScore = SCORE;
        }
        UpdateGUI();
    }

    void UpdateGUI()
    {
        scoreText = GameObject.Find("ScoreText");
        scoreText.GetComponent<Text>().text = "Score: " + SCORE;
    }
}
