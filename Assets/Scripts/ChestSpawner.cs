using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ChestSpawner : MonoBehaviour
{
    [SerializeField] GameObject chest;
    [SerializeField] public float range = 100.0f;
    Vector3 point;

    
    bool ChestSpawn(Vector3 center, float range, out Vector3 result)
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

   private void Update()
    {
       int numberOfChests = FindObjectsOfType<Chest>().Length;
        if (ChestSpawn(transform.position, range, out point) &&  numberOfChests<1)
        {
            point.y = point.y + 0.5f;
            Instantiate(chest, point, transform.rotation);
            Debug.Log("I spawned");
        }
    }
}

