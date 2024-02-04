using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StopHunger : MonoBehaviour
{
    public Bars bars;
    private void OnTriggerEnter(Collider other)
    {
        bars.HungerN = 0;
    }

    private void OnTriggerStay(Collider other)
    {
        if (bars.Hunger < 100)
        {
            bars.Hunger += 1 * Time.deltaTime * 20f;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        bars.HungerN = 1;
    }
}
