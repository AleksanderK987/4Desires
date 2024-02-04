using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Bars : MonoBehaviour
{
    public Slider HungerSlider;
    public Slider MoodSlider;
    public Slider ToiletSlider;
    public Slider SleepSlider;

    public float Hunger;
    public float Mood;
    public float Sleep;
    public float Toilet;

    int maxHunger = 100;
    int maxMood = 100;
    int maxSleep = 100;
    int maxToilet = 100;

    public int HungerDecrease = 1;
    public int MoodDecrease = 1;
    public int ToiletDecrease = 1;
    public int SleepDecrease = 1;

    public int HungerN = 1;
    public int MoodN = 1;
    public int ToiletN = 1;
    public int SleepN = 1;

    
    void Start()
    {
        Hunger = maxHunger;
        Mood = maxMood;
        Toilet = maxToilet;
        Sleep = maxSleep;
    }

    void Update()
    {
        HungerSlider.value = Hunger;
        MoodSlider.value = Mood;
        SleepSlider.value = Sleep;
        ToiletSlider.value = Toilet;

        if (Hunger > 0f)
        {
            Hunger -= 1 * Time.deltaTime * HungerDecrease * HungerN;
        }
        if (Mood > 0)
        {
            Mood -= 1 * Time.deltaTime * MoodDecrease * MoodN;
        }
        if (Sleep > 0)
        {
            Sleep -= 1 * Time.deltaTime * SleepDecrease * SleepN;
        }
        if (Toilet > 0)
        {
            Toilet -= 1 * Time.deltaTime * ToiletDecrease * ToiletN;
        }
    }

    private void OnTriggerEnter(Collider other)
    {

    }
}
