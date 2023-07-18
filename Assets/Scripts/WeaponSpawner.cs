using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    public List<GameObject> weaponsList;
    public List<Transform> spawnPoints;
    public float minSpawnTime = 3f;
    public float maxSpawnTime = 7f;

    private void Start()
    {
        StartCoroutine(SpawnWeapon());
    }

    private IEnumerator SpawnWeapon()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));

            int weaponIndex = Random.Range(0, weaponsList.Count);
            GameObject weaponPrefab = weaponsList[weaponIndex];

            int spawnIndex = Random.Range(0, spawnPoints.Count);
            Transform spawnPoint = spawnPoints[spawnIndex];

            Instantiate(weaponPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
