using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    Rigidbody rigidBody;
    [SerializeField] float angularSpeed = 1f;
    void Start()
    {
        this.rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 angle = rigidBody.rotation.eulerAngles;
        angle += new Vector3(0, 0, 1) * angularSpeed * Time.deltaTime;
        rigidBody.rotation = Quaternion.Euler(angle);   
    }
}
