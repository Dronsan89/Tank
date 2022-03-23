using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : RangeTank
{
    [SerializeField] private List<GunPlayer> _guns;

    private bool _isFirstGun = true;
    private Spawner _spawner;

    #region Singleton
    public static Player Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    protected override void Start()
    {
        base.Start();
        _ui.UpdateHealth(_currentHealth);
        _spawner = FindObjectOfType<Spawner>();
    }

    private void Update()
    {
        Move();
        SetAngle(Camera.main.ScreenToWorldPoint(Input.mousePosition));

        if (_currentTime <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                Shoot();
            }
            _currentTime = _reloadTime;
        }
        else
        {
            _currentTime -= Time.deltaTime;
        }
    }

    public override void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        _ui.UpdateHealth(_currentHealth);
        if(_currentHealth <= 0)
        {
            DataLevel.ResetAllStats();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    protected override void Move()
    {
        Vector2 direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _rigidbody.velocity = direction.normalized * _movementSpeed;
    }

    public void SwitchGun()
    {
        if(_isFirstGun)
        {
            _projectileTag = _guns[1].projectileTag;
            _reloadTime = _guns[1].reloadTime;
            _isFirstGun = false;
        }
        else
        {
            _projectileTag = _guns[0].projectileTag;
            _reloadTime = _guns[0].reloadTime;
            _isFirstGun = true;
        }
    }
}
