using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header ("Zombie")]
    [SerializeField] private bool _isSpawnZombie;
    [SerializeField] private GameObject _spawnZombies;
    [SerializeField] private List<Zombie> _zombies;
    [SerializeField] private int _maxZombies;
    [HideInInspector] public List<GameObject> zombiesList;

    [Header ("Bars")]
    public Texture2D textureMaxHealthbar;
    public Texture2D textureHealth;    

    void Start() 
    {
        if(_isSpawnZombie)
        {
            float spawnPositionX = _spawnZombies.gameObject.transform.position.x;
            float spawnPositionY = _spawnZombies.gameObject.transform.position.y;
            float spawnPositionZ = _spawnZombies.gameObject.transform.position.z;
            Vector3 enemySpawnPosition = new Vector3(spawnPositionX, spawnPositionY, spawnPositionZ);

            StartCoroutine(SpawningEnemy(enemySpawnPosition));
        }
    }

    /// <summary>
    /// Бесконченый спавн зомби
    /// </summary>
    /// <param name="spawnPosition"></param>
    /// <returns></returns>
    IEnumerator SpawningEnemy(Vector3 spawnPosition)
    {
        while(true)
        {
            while(zombiesList.Count < _maxZombies)
            {
                GameObject zombie = Instantiate(_zombies[Random.Range(0, _zombies.Count)].gameObject, spawnPosition, Quaternion.identity);
                zombiesList.Add(zombie);
                yield return new WaitForSecondsRealtime(1f);
            }
            yield return new WaitForSecondsRealtime(0.001f);
        }
    }
}
