using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float acceleration = 1;
    public float rotationSpeed = 1;
    public bool Drift;
    Rigidbody rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float InputVertical = Input.GetAxis("Vertical");
        float inputHorizontal = Input.GetAxis("Horizontal");

        rigid.AddForce(transform.forward * InputVertical * Time.deltaTime * acceleration);
        transform.Rotate(new Vector3(0, inputHorizontal * Time.deltaTime * rotationSpeed));


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Drift = !Drift;
        }
        if (Drift == false)
        {
            Vector3 velocity = rigid.velocity;
            velocity = transform.forward * velocity.magnitude;
            rigid.velocity = velocity;
        }

    }
}
