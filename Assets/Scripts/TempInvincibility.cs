using System;
using UnityEngine;
using System.Collections;

public class TempInvincibility : MonoBehaviour
{
    public Func<bool> IsInvincible;
    private const float INVOKE_TIMER = 0.25f;
    private static float invokeTimer;

    public void Reset()
    {
        invokeTimer = INVOKE_TIMER;
    }

    void Start()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    void Update()
    {
        invokeTimer -= Time.deltaTime;

        if (IsInvincible()) {
            if (invokeTimer <= 0)
            {
                invokeTimer = INVOKE_TIMER;
                FlashPlayer();
            }
        }
        else {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            Destroy(this);
        }
    }

    void FlashPlayer()
    {
        Renderer[] r = GetComponentsInChildren<Renderer>();

        foreach (Renderer i in r)
        {
            i.enabled = !i.enabled;
        }
    }
}
