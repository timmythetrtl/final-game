using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{

    public CharacterScriptableObject characterData;

    public int currentHealth;
    float currentRecovery;
    float currentMoveSpeed;
    float currentMight;
    float currentProjectileSpeed;

    public float dashDistance;
    public float dashDuration;
    public float dashCooldown;

    [Header("Experience/Level")]
    public int experience = 0;
    public int level = 1;
    public int experienceCap;

    public static int score;

    [System.Serializable]

    public class LevelRange
    {
        public int startLevel;
        public int endLevel;
        public int experienceCapIncrease;
    }

    [Header("I-Frames")]
    public float invincibilityDuration;
    float invincibilityTimer;
    bool isInvincible;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private int flipped = 1;

    public List<LevelRange> levelRanges;

    void Start()
    {
        experienceCap = levelRanges[0].experienceCapIncrease;
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();


    }

    void Update()
    {
        if (invincibilityTimer > 0)
        {
            invincibilityTimer -= Time.deltaTime;
        }
        else if (isInvincible)
        {
            isInvincible = false;
        }

        if (spriteRenderer.flipX)
        {
            flipped = 1;
        }
        else
        {
            flipped = -1;
        }
    }

    public void IncreaseExperience(int amount)
    {
        experience += amount;

        LevelUpChecker();
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
    }

    void LevelUpChecker()
    {
        if (experience >= experienceCap)
        {
            level++;
            experience -= experienceCap;

            int experienceCapIncrease = 0;
            foreach (LevelRange range in levelRanges)
            {
                if (level >= range.startLevel && level <= range.endLevel)
                {
                    experienceCapIncrease = range.experienceCapIncrease;
                    break;
                }
            }
            experienceCap += experienceCapIncrease;
        }
    }

    void Awake()
    {
        currentHealth = characterData.MaxHealth;
        currentRecovery = characterData.Recovery;
        currentMoveSpeed = characterData.MoveSpeed;
        currentMight = characterData.Might;
        currentProjectileSpeed = characterData.ProjectileSpeed;
    }

    public void TakeDamage(int dmg)
    {
        if (!isInvincible)
        {
            currentHealth -= dmg;

            invincibilityTimer = invincibilityDuration;
            isInvincible = true;

            // Start the blinking coroutine on the player's visual component
            StartCoroutine(Blink(transform.Find("Visual").GetComponent<Renderer>()));

            if (currentHealth <= 0)
            {
                Kill();
            }

            //StartCoroutine(Dash());
        }
    }
    IEnumerator Dash()
    {

        Vector2 dashVelocity = new Vector2(flipped * transform.localScale.x * dashDistance / dashDuration, 0f);

        float dashTime = 0f;

        while (dashTime < dashDuration)
        {
            rb.MovePosition(rb.position + dashVelocity * Time.fixedDeltaTime);
            dashTime += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }

        yield return new WaitForSeconds(dashCooldown);

    }


    IEnumerator Blink(Renderer renderer)
    {
        // Blink for the duration of invincibility
        while (isInvincible)
        {
            renderer.enabled = false;
            yield return new WaitForSeconds(0.05f);
            renderer.enabled = true;
            yield return new WaitForSeconds(0.05f);
        }
        renderer.enabled = true; // make sure renderer is visible when invincibility ends
    }


    public void Kill()
    {
        SceneManager.LoadSceneAsync("GameOver");
        SceneManager.UnloadSceneAsync("BasementMain");
    }


    public void RestoreHealth(int amount)
    {
        if (currentHealth < characterData.MaxHealth)
        {
            currentHealth += amount;

            if (currentHealth > characterData.MaxHealth)
            {
                currentHealth = characterData.MaxHealth;
            }
        }
    }

    public GameObject meterPrefab; // Drag the Meter prefab to this field in the Inspector

    public void DrownMeter(bool check)
    {
        Transform meterTransform = transform.Find("Meter");

        if (check)
        {
            if (meterTransform == null)
            {
                // Instantiate the Meter prefab as a child of this object
                GameObject meterObject = Instantiate(meterPrefab, transform);
                meterObject.name = "Meter"; // Rename the object to "Meter"
            }
        }
        else
        {
            if (meterTransform != null)
            {
                // Destroy the Meter object if it exists
                Destroy(meterTransform.gameObject);
            }
        }
    }

}
