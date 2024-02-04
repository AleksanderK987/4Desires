using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StopMood : MonoBehaviour
{
    public Bars bars;
    private void OnTriggerEnter(Collider other)
    {
        bars.MoodN = 0;
    }
    private void OnTriggerStay(Collider other)
    {
        if (bars.Mood < 100)
        {
            bars.Mood += 1 * Time.deltaTime * 20f;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        bars.MoodN = 1;
    }
}
