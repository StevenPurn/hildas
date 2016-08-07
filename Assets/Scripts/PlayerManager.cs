using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerManager : MonoBehaviour
{
    private static float INVINCIBLE_TIMER = 3.0f;

    public int currentLives;
    public List<GameObject> spaceships = new List<GameObject>();
    public const float WIGGLE_ROOM = 2;
    private GameObject spaceshipPrefab;
    private Vector2 topLeft;
    private Vector2 bottomRight;
    private float worldWidth;
    private float worldHeight;
    public bool isInvincible;

	// Use this for initialization
	void Start () {
        currentLives = 3;
        spaceshipPrefab = (GameObject)Resources.Load("Prefabs/Spaceship");
        AddSpaceship(0, 0);
	}

    void Update() {
        topLeft = ViewportUtility.GetViewportTopLeft();
        bottomRight = ViewportUtility.GetViewportBottomRight();
   
        worldWidth = bottomRight.x - topLeft.x;
        worldHeight = topLeft.y - bottomRight.y;

        KillOffscreenShips();
        SpawnNewShips();
    }

    void KillOffscreenShips()
    {
        foreach (GameObject spaceship in new List<GameObject>(spaceships))
        {
            Vector3 pos = spaceship.transform.position;

            if (
                pos.x <= topLeft.x - WIGGLE_ROOM ||
                pos.x >= bottomRight.x + WIGGLE_ROOM ||
                pos.y >= topLeft.y + WIGGLE_ROOM ||
                pos.y <= bottomRight.y - WIGGLE_ROOM
            )
            {
                spaceships.Remove(spaceship);
                Destroy(spaceship);
            }
        }
    }
 
    void SpawnNewShips()
    {
        foreach (GameObject spaceship in new List<GameObject>(spaceships))
        {
            var pos = spaceship.transform.position;

            if (pos.x <= topLeft.x + WIGGLE_ROOM && !isShipToRightOf(spaceship))
            {
                AddSpaceship(pos.x + worldWidth, pos.y);
            }
            if (pos.x >= bottomRight.x - WIGGLE_ROOM && !isShipToLeftOf(spaceship))
            {
                AddSpaceship(pos.x - worldWidth, pos.y);
            }
            if (pos.y >= topLeft.y - WIGGLE_ROOM && !isShipBelow(spaceship))
            {
                AddSpaceship(pos.x, pos.y - worldHeight);
            }
            if (pos.y <= bottomRight.y + WIGGLE_ROOM && !isShipAbove(spaceship))
            {
                AddSpaceship(pos.x, pos.y + worldHeight);
            }
        }
	}

    bool isShipToRightOf(GameObject spaceship)
    {
        return spaceships.FindAll(curSpaceship => {
            return curSpaceship.transform.position.x - spaceship.transform.position.x >= worldWidth - WIGGLE_ROOM &&
                Mathf.Abs(curSpaceship.transform.position.y - spaceship.transform.position.y) < WIGGLE_ROOM;
        }).Count > 0;
    }

    bool isShipToLeftOf(GameObject spaceship)
    {
        return spaceships.FindAll(curSpaceship => {
            return spaceship.transform.position.x - curSpaceship.transform.position.x >= worldWidth - WIGGLE_ROOM &&
                Mathf.Abs(curSpaceship.transform.position.y - spaceship.transform.position.y) < WIGGLE_ROOM;
        }).Count > 0;
    }

    bool isShipAbove(GameObject spaceship)
    {
        return spaceships.FindAll(curSpaceship => {
            return curSpaceship.transform.position.y - spaceship.transform.position.y >= worldHeight - WIGGLE_ROOM &&
                Mathf.Abs(curSpaceship.transform.position.x - spaceship.transform.position.x) < WIGGLE_ROOM;
        }).Count > 0;
    }

    bool isShipBelow(GameObject spaceship)
    {
        return spaceships.FindAll(curSpaceship => {
            return spaceship.transform.position.y - curSpaceship.transform.position.y >= worldHeight - WIGGLE_ROOM &&
                Mathf.Abs(curSpaceship.transform.position.x - spaceship.transform.position.x) < WIGGLE_ROOM;
        }).Count > 0;
    }

    void AddSpaceship(float x, float y)
    { 
        var spaceship = (GameObject)Object.Instantiate(spaceshipPrefab);
        spaceship.GetComponent<PlayerMovement>().IsInvincible = () => this.isInvincible;
        spaceship.GetComponent<TempInvincibility>().IsInvincible = () => this.isInvincible;

        spaceship.transform.SetParent(this.transform);
        spaceship.transform.position = new Vector3(x, y, 0);
        if (spaceships.Count > 0)
        {
            var spaceshipPrime = spaceships[0];
            spaceship.transform.rotation = spaceshipPrime.transform.rotation;
            spaceship.GetComponent<Rigidbody2D>().velocity= spaceshipPrime.GetComponent<Rigidbody2D>().velocity;
        }

        spaceships.Add(spaceship);

        if (isInvincible)
        {
            spaceship.GetComponent<TempInvincibility>().Reset();
        }
    }

    public void IncreaseLives()
    {
        currentLives += 1;
    }

    public void DecreaseLives()
    {
        currentLives -= 1;
        if(currentLives <= 0)
        {
            Debug.Log("YOU DONE AND ALSO YOU SUCK YOU ARE LITERALLY THE WORST");
        }
    }

    public void RespawnPlayer()
    {
        foreach (GameObject spaceship in new List<GameObject>(spaceships))
        {
            Destroy(spaceship);
        }

        spaceships.Clear();
        StartCoroutine(SpawnDelay(2));
    }


    IEnumerator SpawnDelay(int secondsToWait)
    {
        yield return new WaitForSeconds(secondsToWait);
        isInvincible = true;
        AddSpaceship(0, 0);
        yield return new WaitForSeconds(INVINCIBLE_TIMER);
        isInvincible = false;
    }
}
