using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    private GameObject[] EnemySpawnPoints;
    [SerializeField]
    private GameObject[] Enemies;
    // Start is called before the first frame update
    void Start()
    {
        EnemySpawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");

        StartCoroutine(SpawnEnemyCoroutine(5.0f));
    }

    IEnumerator SpawnEnemyCoroutine(float waitTime)
    {
        if (GameManager.Instance != null)
        {
            while (!GameManager.Instance.GameOver)
            {
                yield return new WaitForSeconds(waitTime);
                SpawnEnemy();
            }
        }
    }

    public void SpawnEnemy()
    {
        System.Random random = new System.Random();
        GameObject spawnPoint = EnemySpawnPoints[random.Next(0, EnemySpawnPoints.Length)];
        GameObject enemy = Enemies[random.Next(0, Enemies.Length)];

        RaycastHit hit;
        if (Physics.Raycast(spawnPoint.transform.position, Vector3.down, out hit))
        {
            Vector3 spawnLocation = new Vector3(hit.point.x, hit.point.y + 1.0f, hit.point.z);
            Instantiate(enemy, spawnLocation, hit.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
