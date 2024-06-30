using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMoment : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Collactables collactables = other.GetComponent<Collactables>();
        if (collactables != null) {
            collactables.Collected();
            gameObject.SetActive(false);
        }
    }
}
