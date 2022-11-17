using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DistanceTracker : MonoBehaviour
{
    public TMP_Text distanceCounter;

    public float speedModifier = 1f;

    public float distanceTraveled;
    bool traveling;

    private void OnEnable()
    {
        BirdController.onBirdDie += GameOver;
    }

    private void OnDisable()
    {
        BirdController.onBirdDie -= GameOver;
    }

    private void Start()
    {
        traveling = true;
        StartCoroutine(Travel());
    }

    private void Update()
    {
        if (traveling)
        {
            distanceCounter.text = "Distance: " + distanceTraveled.ToString("N1");
        }
    }

    IEnumerator Travel()
    {
        while (traveling)
        {
            yield return new WaitForSeconds(1);
            distanceTraveled += 1f * speedModifier;
        }
    }

    void GameOver()
    {
        traveling = false;
        StopCoroutine(Travel());
        GameManager.totalDistance = distanceTraveled;
        distanceTraveled = 0f;
    }
}
