using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMraker : MonoBehaviour
{
    RaycastHit hit;

    void OnDrawGizmos()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            Debug.DrawLine(transform.position, hit.point, Color.magenta);
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(hit.point, 1.0f);
        }
    }
}
