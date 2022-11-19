using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindClosestGO : MonoBehaviour
{
    public List<Transform> enemyTransforms;
    [SerializeField]
    public float sqrClosestDistance = Mathf.Infinity;
    [SerializeField]
    GameObject closestEnemy;
    public GameObject FindClosest()
    {
        foreach (var item in enemyTransforms)
        {
            var distance = item.position - transform.position;
            var lenght = distance.sqrMagnitude;
            if (lenght < sqrClosestDistance)
            {
                sqrClosestDistance = lenght;
                closestEnemy = item.gameObject;
            }
        }
        return closestEnemy;
    }
}
