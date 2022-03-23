using UnityEngine;

public class RangeEnemyTank : RangeTank
{
    [SerializeField] private float _distanceToPlayer = 5f;

    private Transform _target;
    private float _currentDistanceToPlayer;

    protected override void Start()
    {
        base.Start();
        _target = Player.Instance.transform;
    }

    private void Update()
    {
        _currentDistanceToPlayer = Vector2.Distance(transform.position, _target.position);
        if (_currentDistanceToPlayer > _distanceToPlayer)
            Move();

        SetAngle(_target.position);

        if (_currentTime <= 0)
        {
            if (_currentDistanceToPlayer < _distanceToPlayer)
            {
                Shoot();
                _currentTime = _reloadTime;
            }
        }
        else
        {
            _currentTime -= Time.deltaTime;
        }
    }
}
