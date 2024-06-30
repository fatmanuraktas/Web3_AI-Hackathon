using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class ShipController : MonoBehaviour
{
    public Transform shipTransform;
    public float speed = 5.0f;
    public Transform target;
    public int acceleratedSpeed;
    private void Awake()
    {
        shipTransform = transform;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical")>0)
        {
            shipTransform.position += transform.forward * Time.deltaTime * speed*Input.GetAxis("Vertical");
        }
        float roll = speed * Time.deltaTime*Input.GetAxis("Roll");
        transform.Rotate(0,0,roll);
    }
    IEnumerator MovingTowards() { 
        yield return new WaitForSeconds(10);
        transform.position = Vector3.MoveTowards(transform.position, target.position, acceleratedSpeed);
    }
}
