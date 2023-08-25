using UnityEngine;
using UnityEngine.Pool;

public class GameSpawn : MonoBehaviour
{
    #region SingleTon
    public static GameSpawn instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    public int maxEnemy;
    public int count;
    public GameObject[] prefabs;
    public Transform EnemyHolder;
    public Transform[] SpawnPoint;
    private float spawnTimer = 4;

    public ObjectPool<GameObject> pool;



    private void Start()
    {
        Init();
        InvokeRepeating(nameof(SpawnEnemy), 0, spawnTimer);
    }

    private void Init()
    {
        pool = new ObjectPool<GameObject>(
            () => Instantiate(prefabs[Random.Range(0, prefabs.Length)], EnemyHolder),
            prefab => prefab.SetActive(true),
            prefab => prefab.SetActive(false),
            prefab => Destroy(prefab)
        );
    }

    private void SpawnEnemy()
    {
        GameObject enemy = pool.Get();
        Health enemyHealth = enemy.GetComponent<Health>();
        enemyHealth.SetData();
        enemy.transform.position = SpawnPoint[Random.Range(0, SpawnPoint.Length)].position;
        enemy.SetActive(true);
    }
}
