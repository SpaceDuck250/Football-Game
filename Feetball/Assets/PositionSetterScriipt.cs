using UnityEngine;
using System.Collections.Generic;

public class PositionSetterScript : MonoBehaviour
{
    public List<Transform> objectList = new List<Transform>();

    public void SetAllObjectPositions()
    {
        if (objectList.Count == 0)
        {
            return;
        }

        foreach (Transform obj in objectList)
        {
            Vector2 spawnPos = obj.GetComponent<SpawnPositionSetter>().spawnPosition;
            SetObjectPosition(obj, spawnPos);
        }
    }

    private void SetObjectPosition(Transform obj, Vector2 position)
    {
        if (obj == null)
        {
            return;
        }

        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;

            rb.freezeRotation = true;

            Quaternion noRotation = Quaternion.Euler(0, 0, 0);
            obj.rotation = noRotation;

            rb.freezeRotation = false;

        }

        obj.position = position;
    }
}
