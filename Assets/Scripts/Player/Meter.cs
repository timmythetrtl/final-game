using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meter : MonoBehaviour
{
    private float timeToShrink = 3f;
    private float originalScaleX;

    void Start()
    {
        originalScaleX = transform.localScale.x;
    }

    void Update()
    {
        if (timeToShrink > 0f)
        {
            timeToShrink -= Time.deltaTime;
            float newScaleX = Mathf.Lerp(0f, originalScaleX, timeToShrink / 5f);
            transform.localScale = new Vector3(newScaleX, transform.localScale.y, transform.localScale.z);
        }
    }
}
