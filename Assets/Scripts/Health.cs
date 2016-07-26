using UnityEngine;

public class Health : MonoBehaviour {

	public int currentHealth = 20;
    private Vector3 instantiatedScale = new Vector3(0.5f, 0.5f, 0.5f);

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

         for(var i = 0; i<4; i++)
        {
            GameObject instantiatedAsteroid = (GameObject)Instantiate(Resources.Load("Prefabs/Enemy"), transform.position, Quaternion.Euler(0, 0, Random.Range(0f, 360f)));
            instantiatedAsteroid.transform.localScale = instantiatedScale;
            instantiatedAsteroid.GetComponent<EnemyMovement>().movementTarget = new Vector2(Random.Range(-5f, 5f), Random.Range(-5f,5f));
        }


		Destroy (gameObject);
	}
}