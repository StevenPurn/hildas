using UnityEngine;

public enum AsteriodSize { large, medium, small };

public class Health : MonoBehaviour {

	public int currentHealth = 10;
    public AsteriodSize asteriodSize = AsteriodSize.large;
    private float[] asteroidRadiuses = { 0.215f, 0.225f, 0.14f, 0.14f, 0.09f, 0.08f };

    // Use this for initialization
    void Start () {
        currentHealth = 10;
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void TakeDamage(int damageReceived){
		currentHealth -= damageReceived;
		if (currentHealth <= 0) {
			Death ();
		}
	}

	public void Death(){
        if (asteriodSize == AsteriodSize.large)
        {
            CreateChildAsteroid(AsteriodSize.medium);
            CreateChildAsteroid(AsteriodSize.medium);
        }
        else if(asteriodSize == AsteriodSize.medium)
        {
            CreateChildAsteroid(AsteriodSize.small);
            CreateChildAsteroid(AsteriodSize.small);
        }

        GameObject particles = (GameObject)Resources.Load("Prefabs/AsteroidExplosion");

        Destroy(GameObject.Instantiate(particles, transform.position, Quaternion.identity),0.5f);
		Destroy (gameObject);
	}

    void CreateChildAsteroid(AsteriodSize aSize)
    {
        GameObject instantiatedAsteroid = (GameObject)Instantiate(Resources.Load("Prefabs/Enemy"), transform.position, Quaternion.Euler(0, 0, Random.Range(0f, 360f)));
        instantiatedAsteroid.GetComponent<EnemyMovement>().movementTarget = new Vector2(Random.Range(-5f, 5f), Random.Range(-5f, 5f));
        int rand;
        if (aSize == AsteriodSize.medium)
        {
            rand = Random.Range(5, 9);
        }
        else
        {
            rand = Random.Range(9, 11);
        }
        Texture2D spr = (Texture2D)Resources.Load("Prefabs/Enemies" + rand.ToString());
        instantiatedAsteroid.GetComponent<SpriteRenderer>().sprite = Sprite.Create(spr, new Rect(0, 0, spr.width, spr.height), new Vector2(0.5f, 0.5f));
        instantiatedAsteroid.GetComponent<CircleCollider2D>().radius = asteroidRadiuses[rand - 5];
        instantiatedAsteroid.GetComponent<Health>().asteriodSize = aSize;
    }
}