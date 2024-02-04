using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StopToilet : MonoBehaviour
{
    public Bars bars;
    private void OnTriggerEnter(Collider other)
    {
        bars.ToiletN = 0;
    }
    private void OnTriggerStay(Collider other)
    {
        if (bars.Toilet < 100)
        {
            bars.Toilet += 1 * Time.deltaTime * 40f;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        bars.ToiletN = 1;
    }
}
