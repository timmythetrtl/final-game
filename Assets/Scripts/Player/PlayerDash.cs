using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public float dashDistance;
    public float dashDuration;
    public float dashCooldown;

    private bool canDash = true;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private int flipped = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {

        if (!PauseMenu.isPaused) { 
            if (Input.GetKeyDown(KeyCode.X) && canDash)
            {
                    StartCoroutine(Dash());
            }

            if (spriteRenderer.flipX)
            {
                Debug.Log("Weeheehee");
                flipped = -1;
            }
            else
            {
                flipped = 1;
            }
        }
    }

    IEnumerator Dash()
    {
        canDash = false;

        Vector2 dashVelocity = new Vector2(flipped * transform.localScale.x * dashDistance / dashDuration, 0f);

        float dashTime = 0f;

        while (dashTime < dashDuration)
        {
            rb.MovePosition(rb.position + dashVelocity * Time.fixedDeltaTime);
            dashTime += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }

        yield return new WaitForSeconds(dashCooldown);

        canDash = true;
    }
}
