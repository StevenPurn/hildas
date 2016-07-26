using UnityEngine;

public class EnemySpawner {
	public GameObject EnemyPrefab;
	public Camera Camera;
	private float currentSpawnTimer;
	public const int ENEMY_SPAWN_MIN = 2;
	public const int ENEMY_SPAWN_MAX = 5;
    private enum Sides {Top = 1, Bottom, Left, Right};

    public EnemySpawner()
    {
        ResetSpawnTimer();
    }
	
	// Update is called once per frame
	public void Update () {
		currentSpawnTimer -= Time.deltaTime;
		if (currentSpawnTimer <= 0) {
			SpawnEnemies();
			ResetSpawnTimer();
		}
	}

	public void ResetSpawnTimer(){
		currentSpawnTimer = (float)Random.Range(ENEMY_SPAWN_MIN, ENEMY_SPAWN_MAX);
	}

	public void SpawnEnemies(){
		var spawnLocation = (Sides)Random.Range (1, 5);
		var worldSpacePosition = new Vector3();

		switch (spawnLocation) {
		case Sides.Top:
			worldSpacePosition = Camera.ViewportToWorldPoint(new Vector3(Random.Range(0f,1f),0,0));
			break;
		case Sides.Right:
			worldSpacePosition = Camera.ViewportToWorldPoint(new Vector3(0,Random.Range(0f,1f),0));
			break;
		case Sides.Bottom:
			worldSpacePosition = Camera.ViewportToWorldPoint(new Vector3(Random.Range(0f,1f),1,0));
			break;
		case Sides.Left:
			worldSpacePosition = Camera.ViewportToWorldPoint(new Vector3(1,Random.Range(0f,1f),0));
			break;
		default:
			break;
		}

		Object.Instantiate(EnemyPrefab, worldSpacePosition, Quaternion.identity);
	}
}
