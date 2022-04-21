using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class DoorSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject door;
    [SerializeField] public float range = 100.0f;
    Vector3 point;


    bool DoorSpawn(Vector3 center, float range, out Vector3 result)
    {

        Vector3 randomPoint = center + Random.insideUnitSphere * range;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
        {
            result = hit.position;

            return true;
        }

        result = Vector3.zero;
        return false;
    }

    void Update()
    {
        int numberOfDoors = FindObjectsOfType<Door>().Length;
        if (DoorSpawn(transform.position, range, out point) && numberOfDoors < 1)
        {
            point.y = point.y + 1f;
            Instantiate(door, point, transform.rotation);
            Debug.Log("I spawned");
        }
    }
}
