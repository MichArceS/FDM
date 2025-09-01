using System.Collections;
using UnityEngine;
using static Oculus.Interaction.OptionalAttribute;

public class SpawnBombController : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public GameObject prefabExplosion;
    public bool flag;

    public int numberOfPrefabsToSpawn = 100;
    public Vector2 areaSize;

    private void Start()
    {
        flag = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && flag)
        {
            StartBombs();
            flag = false;
        }
    }

    public void StartBombs()
    {
        StartCoroutine(SpawnPrefabs());
    }

    IEnumerator SpawnPrefabs()
    {
        Vector3 spawnerPosition = transform.position;

        for (int i = 0; i < numberOfPrefabsToSpawn; i++)
        {
            float randomX = Random.Range(-areaSize.x / 2f, areaSize.x / 2f);
            float randomZ = Random.Range(-areaSize.y / 2f, areaSize.y / 2f);

            Vector3 spawnPosition = new Vector3(spawnerPosition.x + randomX, 15, spawnerPosition.z + randomZ);

            GameObject go = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
            go.GetComponent<BombController>().explosionPrefab = prefabExplosion;
            yield return new WaitForSeconds(1);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector3(areaSize.x, 0f, areaSize.y));
    }
}
