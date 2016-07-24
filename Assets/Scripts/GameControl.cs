using UnityEngine;

public class GameControl : MonoBehaviour {
	private EnemySpawner EnemySpawner;

	// Use this for initialization
	void Start () {
		EnemySpawner = new EnemySpawner
		{
			Camera = GameObject.Find("Main Camera").GetComponent<Camera>()a,
			EnemyPrefab = GameObject.Find("Enemy")
		};
	}
	
	// Update is called once per frame
	void Update () {
		EnemySpawner.Update();
	}
}
