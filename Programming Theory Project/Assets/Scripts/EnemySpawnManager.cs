using System.Collections;
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
        // Enemies = GameObject.FindGameObjectsWithTag("Enemy");

        StartCoroutine(SpawnEnemyCoroutine(5.0f));
    }

    IEnumerator SpawnEnemyCoroutine(float waitTime)
    {
        while (!GameManager.Instance.GameOver)
        {
            yield return new WaitForSeconds(waitTime);
            SpawnEnemy();
        }
    }

    public void SpawnEnemy()
    {
        System.Random random = new System.Random();
        GameObject spawnPoint = EnemySpawnPoints[random.Next(0, EnemySpawnPoints.Length)];
        GameObject enemy = Enemies[random.Next(0, Enemies.Length)];

        Instantiate(enemy, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
