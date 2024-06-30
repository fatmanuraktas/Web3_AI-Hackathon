using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Collactables : MonoBehaviour
{
    // Start is called before the first frame update
    
    public int numInput { get; private set; }

   public UnityEvent<Collactables> collactablesChanged;
    public void  Collected(){
    numInput++;
        collactablesChanged.Invoke(this);
   }
}
