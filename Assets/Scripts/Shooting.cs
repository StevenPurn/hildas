using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject BulletObj;
    private GameObject PlayerShip;

    void Start()
    {
        PlayerShip = transform.parent.gameObject;
        BulletObj = Resources.Load<GameObject>("Prefabs/Bullet");
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            var bullet = (GameObject)Instantiate(BulletObj, gameObject.transform.position, gameObject.transform.rotation);

            // Give the bullet the ship's velocity so it goes faster if the player is moving
            var shipVelocity = PlayerShip.GetComponent<PlayerMovement>().CurrentVelocity;
            bullet.GetComponent<Bullet>().SetPlayerShipVelocity(shipVelocity);

            // Don't allow bullets to collide with the player
            var bulletCollider = bullet.GetComponent<Collider2D>();
            var shipCollider = PlayerShip.GetComponent<Collider2D>();
            Physics2D.IgnoreCollision(bulletCollider, shipCollider);
        }
    }
}
