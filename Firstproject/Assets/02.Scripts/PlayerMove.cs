using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public float rotateSpeed = 200.0f;
    private float h => Input.GetAxis("Horizontal");
    private float v => Input.GetAxis("Vertical");

    private float r => Input.GetAxis("Mouse X");
    void Update()
    {
        //transform.position += new Vector3(h, 0.0f, v).normalized * moveSpeed * Time.deltaTime;
        transform.Translate(new Vector3(h, 0.0f, v).normalized * moveSpeed * Time.deltaTime);

        Vector3 deltaRotate = Vector3.up * r * rotateSpeed * Time.deltaTime;
        transform.Rotate(deltaRotate);
    }
}
