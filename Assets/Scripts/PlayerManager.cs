using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

    public int currentLives;

	// Use this for initialization
	void Start () {
        currentLives = 3;
	}
	
	// Update is called once per frame
	void Update () {
	
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

        }
    }
}
