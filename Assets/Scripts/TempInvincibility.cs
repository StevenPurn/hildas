using UnityEngine;
using System.Collections;

public class TempInvincibility : MonoBehaviour {

    private static float INVINCIBLE_TIMER = 3.0f;
    private static float INVOKE_TIMER = 0.25f;
    private static float invincibilityTime;
    private static float invokeTimer;
	// Use this for initialization
	void Start () {
        invincibilityTime = INVINCIBLE_TIMER;
        invokeTimer = INVOKE_TIMER;
        gameObject.GetComponent<PlayerMovement>().SetInvincibility(true);
	}
	
	// Update is called once per frame
	void Update () {

        invokeTimer -= Time.deltaTime; 

	    if(invincibilityTime >= 0)
        {
            invincibilityTime -= Time.deltaTime;

            if (invokeTimer <= 0)
            {
                invokeTimer = INVOKE_TIMER;
                FlashPlayer();
            }

        }else
        {
            gameObject.GetComponent<PlayerMovement>().SetInvincibility(false);
            Destroy(this);
        }
	}

    void FlashPlayer()
    {
        Renderer[] r = GetComponentsInChildren<Renderer>();

        foreach  (Renderer i in r)
        {
            i.enabled = !i.enabled;
        }

    }
}
