using UnityEngine;

public enum AsteriodSize { large, medium, small };

public class Health : MonoBehaviour {

	public int currentHealth = 10;
    public AsteriodSize asteriodSize = AsteriodSize.large;

	// Use this for initialization
	void Start () {
       
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

        
		Destroy (gameObject);
	}

    void CreateChildAsteroid(AsteriodSize aSize)
    {
        GameObject instantiatedAsteroid = (GameObject)Instantiate(Resources.Load("Prefabs/Enemy"), transform.position, Quaternion.Euler(0, 0, Random.Range(0f, 360f)));
        instantiatedAsteroid.GetComponent<EnemyMovement>().movementTarget = new Vector2(Random.Range(-5f, 5f), Random.Range(-5f, 5f));
        float scale = aSize == AsteriodSize.medium ? 0.5f : 0.25f;
        instantiatedAsteroid.GetComponent<Health>().asteriodSize = aSize;
        instantiatedAsteroid.transform.localScale = new Vector3(scale, scale,1);
    }
}