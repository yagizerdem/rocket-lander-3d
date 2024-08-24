using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    Rigidbody rgBody;
    [SerializeField] public float VerticalThrustForce = 800f;
    [SerializeField] public float gravityForce = 100f;
    [SerializeField] private float HorizontalThrustForce = 200f;
    private void Start()
    {
        rgBody = GetComponent<Rigidbody>(); 
    }
    private void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (!RocketStates.instance.isHit)
        {
            VerticalThrust();
            HorizontalThrust();
            ClearTorque();
        }
    }
    void VerticalThrust()
    {
        Vector3 force = Input.GetAxis("Vertical") * Vector3.up * VerticalThrustForce * Time.deltaTime;
        if (force.y < 0) force = Vector3.zero;
        Vector3 gravity = Vector3.down * gravityForce * Time.deltaTime;
        Vector3 movement = force + gravity;
        rgBody.AddRelativeForce(movement);
    }
    void HorizontalThrust()
    {
        Vector3 rotation = transform.rotation.eulerAngles;
        rotation += new Vector3(0, 0, 1) * Input.GetAxis("Horizontal") * HorizontalThrustForce * Time.deltaTime * 1;
        transform.rotation = Quaternion.Euler(rotation);
    }
    void ClearTorque()
    {
        if(Input.GetAxis("Horizontal") <= Mathf.Epsilon)
        {
            this.rgBody.angularVelocity = Vector3.zero;
        }
    }
}
