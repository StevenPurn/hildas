using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public const float ROTATION_MULTIPLIER = 270f;
	public const float ENGINE_FORCE = 100f;
	public const float MAX_SPEED = 7f;
	public Vector2 CurrentVelocity = Vector2.zero;
    private ParticleSystem thrusterParticles;
    private ParticleSystem.EmissionModule em;

    void Start()
    {
        thrusterParticles = GameObject.Find("thrusterParticles").GetComponent<ParticleSystem>();
        em = thrusterParticles.emission;
        em.enabled = false;
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
}
