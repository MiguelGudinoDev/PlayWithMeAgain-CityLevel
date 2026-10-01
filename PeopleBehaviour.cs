using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleBehaviour : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 direction;
    private Bounds bounds;

    void Start()
    {
        // Definir los límites del área usando un objeto vacío con BoxCollider (sin isTrigger)
        GameObject boundary = GameObject.Find("Boundary");
        if (boundary != null)
        {
            bounds = boundary.GetComponent<Collider>().bounds;
        }
        else
        {
            Debug.LogError("No se encontró un objeto Boundary con un Collider.");
        }

        // Asignar una dirección aleatoria inicial
        direction = Random.insideUnitSphere;
        direction.y = 0; // Mantener el movimiento en el plano horizontal
    }

    void Update()
    {
        // Mover la cápsula
        transform.position += direction * speed * Time.deltaTime;

        // Verificar si la cápsula toca los límites del área
        if (!bounds.Contains(transform.position))
        {
            // Reflejar la dirección cuando toca el límite
            direction = Vector3.Reflect(direction, GetClosestBoundaryNormal(transform.position));
            direction.y = 0; // Mantener el movimiento en el plano horizontal
        }
    }

    private Vector3 GetClosestBoundaryNormal(Vector3 position)
    {
        // Determinar la dirección del rebote en función de qué límite se ha tocado
        Vector3 normal = Vector3.zero;
        if (position.x >= bounds.max.x) normal = Vector3.left;
        else if (position.x <= bounds.min.x) normal = Vector3.right;
        if (position.z >= bounds.max.z) normal = Vector3.back;
        else if (position.z <= bounds.min.z) normal = Vector3.forward;

        return normal;
    }
}

