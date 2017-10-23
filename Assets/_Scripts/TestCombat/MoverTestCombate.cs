using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverTestCombate : MonoBehaviour {
    public float speed;
    private Vector3 inputKeyboard = new Vector3(0, 0, 0);
    private Vector3 movementVector = new Vector3(0, 0, 0);
    private float angularSpeed = 60; //degrees
    private Vector3 angularVector = new Vector3(0, 0, 0);

    // Use this for initialization
    void Start()
    {
        angularVector = new Vector3(0, angularSpeed * Time.deltaTime, 0);
    }

    // Update is called once per frame
    void Update()
    {
        inputKeyboard.x = Input.GetAxis("Horizontal");
        inputKeyboard.z = Input.GetAxis("Vertical");

        inputKeyboard = inputKeyboard.normalized;
        movementVector = inputKeyboard * speed * Time.deltaTime;

        // transform.position += movementVector;
        transform.Translate(movementVector);
        //        transform.forward = movementVector.normalized;

        if (Input.GetKey(KeyCode.Z))
        {
            transform.eulerAngles -= angularVector;
        }
        if (Input.GetKey(KeyCode.X))
        {
            transform.eulerAngles += angularVector;
        }

    }
}
