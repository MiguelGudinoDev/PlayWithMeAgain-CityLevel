using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMedium : MonoBehaviour
{
    public float velocidad = 4f;

    public float puntoInicio = -5f;
    public float puntoFin = 5f;

    void Update()
    {
        transform.position += Vector3.forward * velocidad * Time.deltaTime;

        if (transform.position.z >= puntoFin)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, puntoInicio);
        }
    }
}
