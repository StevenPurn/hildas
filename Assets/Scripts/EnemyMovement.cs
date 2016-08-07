using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{

    public Vector3 movementTarget;
    static float SPEED = 2f;
    private Rigidbody2D rigidBody;

    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        SPEED = Random.Range(2f, 5f);
        rigidBody.AddForce(new Vector2(SPEED * (movementTarget.x - transform.position.x), SPEED * (movementTarget.y - transform.position.y)), ForceMode2D.Force);
    }
}
