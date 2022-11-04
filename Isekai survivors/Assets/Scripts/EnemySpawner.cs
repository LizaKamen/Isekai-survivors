using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies;
    [SerializeField]
    private float externalR = 100f;
    [SerializeField]
    private float internalR = 80f;
    [SerializeField]
    private float spawnRate;
    [SerializeField]
    private float amountOfENemiesSpawn;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateEnemy());
    }

    // Update is called once per frame
    void Update()
    {
    }
    IEnumerator CreateEnemy()
    {
        var q = new Quaternion();
        var switcher = true;
        while (true)
        {
            var posX = 0f;
            var posY = 0f;
            var enemy = enemies[Random.Range(0, enemies.Length - 1)];
            if (switcher)
            {
                posX = Random.Range(-externalR, externalR);
                if (System.Math.Abs(posX) < internalR)
                {
                    while (posY == 0)
                    {
                        posY = Random.Range(internalR, externalR) * Random.Range(-1, 2);
                    }
                }
                else
                {
                    posY = Random.Range(-externalR, externalR);
                }
            }
            else
            {
                posY = Random.Range(-externalR, externalR);
                if (System.Math.Abs(posY) < internalR)
                {
                    while (posX == 0)
                    {
                        posX = Random.Range(internalR, externalR) * Random.Range(-1, 2);
                    }
                }
                else
                {
                    posX = Random.Range(-externalR, externalR);
                }
            }
            var spawnPos = new Vector3(posX, posY) + transform.position;
            Instantiate(enemy, spawnPos, q);
            switcher = !switcher;
            yield return new WaitForSeconds(spawnRate);
        }
    }
}
