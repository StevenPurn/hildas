using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public const float ROTATION_MULTIPLIER = 270f;
	public const float ENGINE_FORCE = 100f;
	public const float MAX_SPEED = 7f;
	public Vector2 CurrentVelocity = Vector2.zero;
    private ParticleSystem thrusterParticles;
    private ParticleSystem.EmissionModule em;
    private GameObject gameManager;
    private static bool IS_INVINCIBLE;

    void Start()
    {
        thrusterParticles = transform.FindChild("thrusterParticles").GetComponent<ParticleSystem>();
        em = thrusterParticles.emission;
        em.enabled = false;
        gameManager = GameObject.Find("GameManager");

    }

	void FixedUpdate () {
		if (Input.GetButton("Horizontal")) {
			var rotationDelta = Input.GetAxisRaw("Horizontal") * -ROTATION_MULTIPLIER * Time.deltaTime;
			transform.Rotate(0f, 0f, transform.rotation.z + rotationDelta);
		}

		var rigidBody = gameObject.GetComponent<Rigidbody2D>();
		if (Input.GetButton ("Vertical") && Input.GetAxis("Vertical") > 0) {
			rigidBody.AddRelativeForce(new Vector2(0, ENGINE_FORCE * Time.deltaTime));
			rigidBody.velocity = Vector2.ClampMagnitude(rigidBody.velocity, MAX_SPEED);
            em.enabled = true;
        }
        else
        {
            em.enabled = false;
        }

		CurrentVelocity = rigidBody.velocity;
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!IS_INVINCIBLE)
        {
            if (other.tag == "Enemy")
            {
                other.GetComponent<Health>().Death();
                GameObject.Find("PlayerObject").GetComponent<PlayerManager>().DecreaseLives();
                SendMessageUpwards("RespawnPlayer");
                this.gameObject.SetActive(false);
            }
        }
    }

    public void SetInvincibility(bool invincibility)
    {
        IS_INVINCIBLE = invincibility;
    }
}
