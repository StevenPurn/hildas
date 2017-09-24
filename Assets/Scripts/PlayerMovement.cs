using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    public const float ROTATION_MULTIPLIER = 270f;
    public const float ENGINE_FORCE = 100f;
    public const float MAX_SPEED = 7f;
    public Vector2 CurrentVelocity = Vector2.zero;
    public Func<bool> IsInvincible;
    private ParticleSystem thrusterParticles;
    private ParticleSystem.EmissionModule em;
    private Vector2 HitPoint;

    void Start()
    {
        thrusterParticles = transform.Find("thrusterParticles").GetComponent<ParticleSystem>();
        em = thrusterParticles.emission;
        em.enabled = false;
    }

    void FixedUpdate()
    {
        if (Input.GetButton("Horizontal"))
        {
            var rotationDelta = Input.GetAxisRaw("Horizontal") * -ROTATION_MULTIPLIER * Time.deltaTime;
            transform.Rotate(0f, 0f, transform.rotation.z + rotationDelta);
        }

        var rigidBody = gameObject.GetComponent<Rigidbody2D>();
        if (Input.GetButton("Vertical") && Input.GetAxis("Vertical") > 0)
        {
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

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (!IsInvincible())
        {
            var other = collider;
            var layerMask = ~LayerMask.NameToLayer("Enemy");
            RaycastHit2D hit = Physics2D.Raycast(transform.position, other.transform.position - transform.position, 5f, layerMask);

            bool isCollisionOnScreen = ViewportUtility.IsInView(hit.point);

            if (other.tag == "Enemy" && isCollisionOnScreen)
            {
                other.GetComponent<Health>().Death();
                GameObject.Find("PlayerObject").GetComponent<PlayerManager>().DecreaseLives();
                SendMessageUpwards("RespawnPlayer");
                GameObject.Find("GameManager").GetComponent<LivesManager>().UpdateLives(-1);
                this.gameObject.SetActive(false);
            }
        }
    }
}
