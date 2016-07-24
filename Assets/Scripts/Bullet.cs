using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public float SPEED = 0.05f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(0, SPEED * Time.deltaTime, 0);
	}
}
