using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RangeTank : Tank
{
    [Header("Стрельба")]
    [SerializeField] protected string _projectileTag;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] protected float _reloadTime = 0.5f;

    private ObjectPool _objectPool;

    protected override void Start()
    {
        base.Start();
        _objectPool = ObjectPool.Instance;
    }

    protected void Shoot()
    {
        _objectPool.SpawnFromPool(_projectileTag, _shootPoint.position, transform.rotation);
    }
}
