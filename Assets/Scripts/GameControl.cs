using UnityEngine;
using System.Collections;

enum Sides {top = 1, bottom, left, right};
	
public class GameControl : MonoBehaviour {

	public GameObject enemy;
	public GameObject camera;
	static float currentSpawnTimer;
	public int enemySpawnMin = 2;
	public int enemySpawnMax = 5;

	// Use this for initialization
	void Start () {
		camera = GameObject.Find ("Main Camera");
		ResetSpawnTimer ();
	}
	
	// Update is called once per frame
	void Update () {
		currentSpawnTimer -= Time.deltaTime;
		if (currentSpawnTimer <= 0) {
			SpawnEnemies ();
			ResetSpawnTimer ();
		}
	}

	public void ResetSpawnTimer(){
		currentSpawnTimer = (float)Random.Range (enemySpawnMin, enemySpawnMax);
	}

	public void SpawnEnemies(){

		//
		var spawnLocation = (Sides)Random.Range (1, 5);
		var worldSpacePosition = new Vector3();

		switch (spawnLocation) {
		case Sides.top:
			worldSpacePosition = camera.GetComponent<Camera> ().ViewportToWorldPoint (new Vector3(Random.Range(0f,1f),0,0));
			Instantiate(enemy,worldSpacePosition,Quaternion.identity);
			break;
		case Sides.right:
			worldSpacePosition = camera.GetComponent<Camera> ().ViewportToWorldPoint (new Vector3(0,Random.Range(0f,1f),0));
			Instantiate(enemy,worldSpacePosition,Quaternion.identity);
			break;
		case Sides.bottom:				
			worldSpacePosition = camera.GetComponent<Camera> ().ViewportToWorldPoint (new Vector3(Random.Range(0f,1f),1,0));
			Instantiate(enemy,worldSpacePosition,Quaternion.identity);
			break;
		case Sides.left:
			worldSpacePosition = camera.GetComponent<Camera> ().ViewportToWorldPoint (new Vector3(1,Random.Range(0f,1f),0));
			Instantiate(enemy,worldSpacePosition,Quaternion.identity);
			break;

		default:
			break;
		}
				
	}
}
