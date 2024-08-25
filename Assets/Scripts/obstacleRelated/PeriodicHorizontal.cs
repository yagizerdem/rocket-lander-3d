using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PerioadicForward : MonoBehaviour
{
    Rigidbody rigidbody;
    [SerializeField] public float angleIncrementStep = 1.0f;
    private float minAngle = Mathf.PI / 2;
    private float maxAngle = Mathf.PI * 3 / 2;
    private float angle;
   
    
    [SerializeField] public float Horizontal = 10f;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        angle = Mathf.Floor((this.maxAngle + this.minAngle) / 2);
    }


    // Update is called once per frame
    void Update()
    {
        angle += angleIncrementStep;
        if(angle >= maxAngle || angle <= minAngle)
        {
            angleIncrementStep = -angleIncrementStep;
        }
        
        angle = Mathf.Clamp(angle, minAngle, maxAngle);
        Vector3 movement = new Vector3(1, 0, 0) * Mathf.Sin(angle) * Time.deltaTime * Horizontal;
        this.transform.position += movement;

    }
}
