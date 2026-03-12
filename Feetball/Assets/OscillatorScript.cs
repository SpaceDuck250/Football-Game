using UnityEngine;
using System;

public class OscillatorScript : MonoBehaviour
{
    public GameObject waveCircleObject;
    public Transform container;

    public float timer;
    public float timePerWaveStartValue;
    public float timePerWave;

    public float increaseRate;

    public bool canCreateWaveCircles;

    private void Start()
    {
        timePerWave = timePerWaveStartValue;
    }

    private void Update()
    {
        if (!canCreateWaveCircles)
        {
            return;
        }

        Oscillate();
        IncreaseTimePerWave(); 
    }

    private void Oscillate()
    {
        timer += Time.deltaTime;
        if (timer >= timePerWave)
        {
            CreateWaveCircle();
            timer = 0;
        }
    }

    public void CreateWaveCircle()
    {
        Instantiate(waveCircleObject, transform.position, Quaternion.identity, container);
    }

    public void ActivateWaves(bool value)
    {
        timePerWave = timePerWaveStartValue;
        timer = 0;
        canCreateWaveCircles = value;
    }

    private void IncreaseTimePerWave()
    {
        timePerWave += Time.deltaTime * increaseRate;
    }
}
