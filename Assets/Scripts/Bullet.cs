using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	static float SPEED = 8f;
	static float LIFETIME = 4f;

	private float ShipSpeed = 0f;

	// Use this for initialization
	void Start () {
		Destroy(gameObject, LIFETIME);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(0, (SPEED + ShipSpeed) * Time.deltaTime, 0);
	}

	public void SetPlayerShipSpeed(float speed) {
		ShipSpeed = speed;
	}
}
