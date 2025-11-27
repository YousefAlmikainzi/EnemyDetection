using UnityEngine;

public class Swing : MonoBehaviour
{
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            rb.AddTorque(transform.forward * 10);
        }
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Right Click");
        }
        if (Input.GetMouseButtonDown(2))
        {
            Debug.Log("Middle Click");
        }
    }
}
