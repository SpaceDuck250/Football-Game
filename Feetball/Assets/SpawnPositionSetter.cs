using UnityEngine;

public class SpawnPositionSetter : MonoBehaviour
{
    public Vector2 spawnPosition;

    private void Start()
    {
        spawnPosition = transform.position;
    }
}
