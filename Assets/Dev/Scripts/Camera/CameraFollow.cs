using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject Male;
    Vector3 mesafe;

    private void Start()
    {
        mesafe = transform.position - Male.transform.position;
    }

    private void Update()
    {
        transform.position = Male.transform.position + mesafe;

    }
}
