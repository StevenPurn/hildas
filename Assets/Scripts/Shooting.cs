using UnityEngine;

public class Shooting : MonoBehaviour {
	public GameObject BulletObj;
	private GameObject PlayerShip;

	// Use this for initialization
	void Start () {
		PlayerShip = transform.parent.parent.gameObject;
		BulletObj = Resources.Load<GameObject>("Prefabs/Bullet");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			var shipVelocity = PlayerShip.GetComponent<PlayerMovement>().CurrentVelocity;
			var bullet = (GameObject)Instantiate (BulletObj, gameObject.transform.position, gameObject.transform.rotation);

			bullet.GetComponent<Bullet>().SetPlayerShipVelocity(shipVelocity);
			var bulletCollider = bullet.GetComponent<Collider2D>();
			var shipCollider = PlayerShip.GetComponent<Collider2D>();
			Physics2D.IgnoreCollision(bulletCollider, shipCollider);
		}
	}
}
