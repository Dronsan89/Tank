using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private string[] _tanksTag;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _spawnTime = 3f;

    private ObjectPool _objectPool;

    private void Start()
    {
        _objectPool = ObjectPool.Instance;
        StartCoroutine(SpawnTank());
    }

    IEnumerator SpawnTank()
    {
        while (DataLevel.Level != 30)
        {
            int limit;
            if (DataLevel.Level < _tanksTag.Length)
                limit = DataLevel.Level;
            else
                limit = _tanksTag.Length;
            _objectPool.SpawnFromPool(_tanksTag[Random.Range(0, limit)], _spawnPoints[Random.Range(0, _spawnPoints.Length)].position, Quaternion.identity);
            yield return new WaitForSeconds(_spawnTime - DataLevel.Level*0.05f);
        }
    }

    public void StopCoroutine()
    {
        StopAllCoroutines();
    }
}
