using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class astreoidController : MonoBehaviour
{

    public Transform rocketPoint;
    public float speed;
    public Animator animator;
    
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, rocketPoint.position, speed);

    }

    /*private void OnTriggerEnter(Collider other)
    {
        animator.SetTrigger("Bang");
    }*/
}
