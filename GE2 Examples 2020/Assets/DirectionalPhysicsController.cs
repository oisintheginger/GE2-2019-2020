using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalPhysicsController : MonoBehaviour
{
    Rigidbody rb;

    public float power = 100;
    public float rotPower = 30;

    public Vector3 rotatedForward;

    public LayerMask lm;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position + Vector3.up, transform.position + rotatedForward * 5);

    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        RaycastHit rch;
        if (Physics.Raycast(transform.position, Vector3.down, out rch, 1000, lm))
        {
            float angle = Vector3.Angle(Vector3.up, rch.normal);
            Vector3 axis = Vector3.Cross(Vector3.up, rch.normal);
            Quaternion q = Quaternion.AngleAxis(angle, axis);


            rotatedForward = q * transform.forward;
            rb.AddForce(Input.GetAxis("Vertical") * rotatedForward * power);
        }

        rb.AddTorque(Input.GetAxis("Horizontal") * Vector3.up * rotPower * 0.001f);
    }
}
