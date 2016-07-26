using UnityEngine;

public class Bullet : MonoBehaviour {
	static float SPEED = 14f;
	static float LIFETIME = 4f;
	static int DAMAGE = 10;

	private Vector2 ShipVelocity = Vector2.zero;

	// Use this for initialization
	void Start () {
		Destroy(gameObject, LIFETIME);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(0, SPEED * Time.deltaTime, 0);
		transform.Translate(ShipVelocity * Time.deltaTime, Space.World);
	}

	public void SetPlayerShipVelocity(Vector2 velocity) {
		ShipVelocity = velocity;
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Enemy") {
			other.GetComponent<Health> ().TakeDamage (DAMAGE);
			Destroy (gameObject);
		}
	}
}
