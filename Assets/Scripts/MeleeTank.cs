using UnityEngine;

public class MeleeTank : Tank
{
    [SerializeField] private int _damage = 5;

    private Transform _target;
    private float _hitCooldown = 1f;

    protected override void Start()
    {
        base.Start();
        _target = Player.Instance.transform;
    }

    void Update()
    {
        if (_target != null)
        {
            if (_currentTime <= 0)
            {
                Move();
                SetAngle(_target.position);
            }
            else
            {
                _currentTime -= Time.deltaTime;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null && _currentTime <= 0)
        {
            player.TakeDamage(_damage);
            _currentTime = _hitCooldown;
        }
    }
}
