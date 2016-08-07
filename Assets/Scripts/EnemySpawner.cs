using UnityEngine;

public class EnemySpawner
{
    public GameObject EnemyPrefab;
    public Camera Camera;
    private float currentSpawnTimer;
    public const int ENEMY_SPAWN_MIN = 2;
    public const int ENEMY_SPAWN_MAX = 5;
    private enum Sides { Top = 1, Bottom, Left, Right };
    private float[] asteroidRadiuses = { 0.5f, 0.55f, 0.445f, 0.49f };

    public EnemySpawner()
    {
        ResetSpawnTimer();

    }

    // Update is called once per frame
    public void Update()
    {
        currentSpawnTimer -= Time.deltaTime;
        if (currentSpawnTimer <= 0)
        {
            SpawnEnemies();
            ResetSpawnTimer();
        }
    }

    public void ResetSpawnTimer()
    {
        currentSpawnTimer = (float)Random.Range(ENEMY_SPAWN_MIN, ENEMY_SPAWN_MAX);
    }

    public void SpawnEnemies()
    {
        var spawnLocation = (Sides)Random.Range(1, 5);
        var worldSpacePosition = new Vector3();
        var directionToMove = new Vector3();

        switch (spawnLocation)
        {
            case Sides.Top:
                worldSpacePosition = Camera.ViewportToWorldPoint(new Vector3(Random.Range(0f, 1f), 1, Camera.nearClipPlane));
                worldSpacePosition += new Vector3(0, 1, 0);
                directionToMove = Camera.ViewportToWorldPoint(new Vector3(.5f, .5f, 0f));
                break;
            case Sides.Right:
                worldSpacePosition = Camera.ViewportToWorldPoint(new Vector3(1, Random.Range(0f, 1f), Camera.nearClipPlane));
                worldSpacePosition += new Vector3(1, 0, 0);
                directionToMove = Camera.ViewportToWorldPoint(new Vector3(.5f, .5f, 0f));
                break;
            case Sides.Bottom:
                worldSpacePosition = Camera.ViewportToWorldPoint(new Vector3(Random.Range(0f, 1f), 0, Camera.nearClipPlane));
                worldSpacePosition += new Vector3(0, -1, 0);
                directionToMove = Camera.ViewportToWorldPoint(new Vector3(.5f, .5f, 0f));
                break;
            case Sides.Left:
                worldSpacePosition = Camera.ViewportToWorldPoint(new Vector3(0, Random.Range(0f, 1f), Camera.nearClipPlane));
                worldSpacePosition += new Vector3(-1, 0, 0);
                directionToMove = Camera.ViewportToWorldPoint(new Vector3(.5f, .5f, 0f));
                break;
            default:
                break;
        }

        worldSpacePosition.z = 0;

        GameObject instantiatedEnemy = (GameObject)Object.Instantiate(EnemyPrefab, worldSpacePosition, Quaternion.Euler(0, 0, Random.Range(0f, 360f)));
        instantiatedEnemy.GetComponent<EnemyMovement>().movementTarget = directionToMove;
        int rand = Random.Range(1, 5);
        Texture2D spr = (Texture2D)Resources.Load("Prefabs/Enemies" + rand.ToString());
        instantiatedEnemy.GetComponent<SpriteRenderer>().sprite = Sprite.Create(spr, new Rect(0, 0, spr.width, spr.height), new Vector2(0.5f, 0.5f));
        instantiatedEnemy.GetComponent<CircleCollider2D>().radius = asteroidRadiuses[rand - 1];
    }
}
