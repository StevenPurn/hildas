using UnityEngine;

public class Health : MonoBehaviour {

	public int currentHealth = 20;

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
		Destroy (gameObject);
	}
}