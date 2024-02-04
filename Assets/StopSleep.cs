using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StopSleep : MonoBehaviour
{
    public Bars bars;
    private void OnTriggerEnter(Collider other)
    {
        bars.SleepN = 0;
    }
    private void OnTriggerStay(Collider other)
    {
        if (bars.Sleep < 100)
        {
            bars.Sleep += 1 * Time.deltaTime * 20f;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        bars.SleepN = 1;
    }
}
