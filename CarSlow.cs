using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSlow : MonoBehaviour
{
    public float velocidad = 2f;

    public float puntoInicio = -16.9f;
    public float puntoFin = 34.5f;

    void Update()
    {
        transform.position += Vector3.forward * velocidad * Time.deltaTime;

        if (transform.position.z >= puntoFin)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, puntoInicio);
        }
    }
}


