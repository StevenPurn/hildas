using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {
	public GameObject Bullet;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			var bullet = Instantiate(Bullet, gameObject.transform.position, gameObject.transform.rotation);
//			Debug.Log (bullet.transform.position);
		}
	}
}
