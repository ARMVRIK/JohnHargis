using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    [SerializeField] Vector3 mainDir;
    Vector3 dir;
    [SerializeField, Range(0, 0.3f)] float windCoof;
    [SerializeField] float mainForce;
    [SerializeField, Range(0, 1)] float turbulence;
    float wind;
    [SerializeField] List<Rigidbody> rbList = new List<Rigidbody>();
    void Start()
    {

    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        wind = mainForce + mainForce * Random.Range(-turbulence, turbulence);
        dir = mainDir + mainDir * Random.Range(-windCoof, windCoof);
        print(wind);
        print(dir);
        foreach (var rb in rbList)
        {
            rb.AddForce(dir * wind, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb && !rb.isKinematic)
        {
            rbList.Add(other.GetComponent<Rigidbody>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb)
        {
            rbList.Remove(other.GetComponent<Rigidbody>());
        }

    }
}
