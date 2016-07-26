﻿using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {
	public GameObject BulletObj;
	private GameObject PlayerShip;
	private static float shotTimer = 0.125f;
	private float currentShotTimer;

	// Use this for initialization
	void Start () {
		PlayerShip = GameObject.Find ("Spaceship");
		currentShotTimer = shotTimer;
	}
	
	// Update is called once per frame
	void Update () {

		currentShotTimer -= Time.deltaTime;

		if (currentShotTimer <= 0) {
			if (Input.GetButton ("Fire1")) {
				var shipSpeed = PlayerShip.GetComponent<PlayerMovement> ().CurrentSpeed;
				var bullet = (GameObject)Instantiate (BulletObj, gameObject.transform.position, gameObject.transform.rotation);

				bullet.GetComponent<Bullet> ().SetPlayerShipSpeed (shipSpeed);

				currentShotTimer = shotTimer;
			}
		}
	}
}