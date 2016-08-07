using System;
using UnityEngine;
using System.Collections;

public class TempInvincibility : MonoBehaviour
{
    public Func<bool> IsInvincible;
    private const float INVOKE_TIMER = 0.25f;
    private static float invokeTimer;
    private SpriteRenderer[] r;

    public void Reset()
    {
        invokeTimer = INVOKE_TIMER;
    }

    void Start()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        r = GetComponentsInChildren<SpriteRenderer>();
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
            foreach (SpriteRenderer i in r)
            {
                i.color = new Color(1, 1, 1, 1);
            }

            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            Destroy(this);
        }
    }

    void FlashPlayer()
    {
        foreach (SpriteRenderer i in r)
        {
            if (i.color.a == 1)
            {
                i.color = new Color(1, 1, 1, 0.5f);
            }else
            {
                i.color = new Color(1, 1, 1, 1);
            }
        }
    }
}
