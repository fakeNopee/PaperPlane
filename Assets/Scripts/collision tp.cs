using UnityEngine;
using System.Collections;

public class ExampleClass : MonoBehaviour
{
    AudioSource audioSource;
    public Transform playerStart;

    void Start()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            transform.position = playerStart.position;
        }

    }
}