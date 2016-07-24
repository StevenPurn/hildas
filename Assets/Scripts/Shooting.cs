using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {
	public GameObject BulletObj;
	private GameObject PlayerShip;

	// Use this for initialization
	void Start () {
		PlayerShip = GameObject.Find ("Spaceship");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			var shipSpeed = PlayerShip.GetComponent<PlayerMovement> ().CurrentSpeed;
			var bullet = (GameObject)Instantiate(BulletObj, gameObject.transform.position, gameObject.transform.rotation);

			bullet.GetComponent<Bullet>().SetPlayerShipSpeed(shipSpeed);
			Debug.Log (shipSpeed);
		}
	}
}
