using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {
	private EnemySpawner EnemySpawner;
    private GameObject gameGUI;
    private GameObject gameOverGUI;

	// Use this for initialization
	void Start () {

        if(GameObject.Find("Score Manager") == null)
        {
            GameObject sm = (GameObject)Instantiate(Resources.Load("Prefabs/Score Manager"),Vector3.zero,Quaternion.identity);
            sm.transform.name = "Score Manager";
        }

        gameOverGUI = GameObject.Find("Game Over Panel");
        gameOverGUI.SetActive(false);
        EnemySpawner = new EnemySpawner
		{
			Camera = GameObject.Find("Main Camera").GetComponent<Camera>(),
			EnemyPrefab = (GameObject)Resources.Load("Prefabs/Enemy")
        };
	}

	// Update is called once per frame
	void Update () {
		EnemySpawner.Update();
	}

    public void RestartLevel()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        gameGUI = GameObject.Find("Score & Life Panel");
        string highScore = GameObject.Find("Score Manager").GetComponent<ScoreManager>().highScore.ToString();
        gameGUI.SetActive(false);
        gameOverGUI.SetActive(true);
        ScoreManager.ResetScore();
        GameObject.Find("High Score Text").GetComponent<Text>().text = "High Score: " + highScore;
    }
}
