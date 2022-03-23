using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Tank : MonoBehaviour
{
    [Header ("Общие характеристики")]
    [SerializeField] private int _maxHealth = 30;
    [SerializeField] protected float _movementSpeed = 3f;
    [SerializeField] protected float _angleOffset = 90f;
    [SerializeField] protected float _rotationSpeed = 7f;
    [SerializeField] private int _points = 20;
    [SerializeField] private string _myTag = "";

    protected UI _ui;
    protected Rigidbody2D _rigidbody;
    protected int _currentHealth;
    protected float _currentTime;

    protected virtual void Start()
    {
        _currentHealth = _maxHealth;
        _rigidbody = GetComponent<Rigidbody2D>();
        _ui = FindObjectOfType<UI>();
    }

    private void OnEnable()
    {
        _currentHealth = _maxHealth;
    }

    public virtual void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        if(_currentHealth<=0)
        {
            DataLevel.Score += _points;
            _ui.UpdateScoreAndLevel();
            gameObject.SetActive(false);
        }
    }

    protected virtual void Move()
    {
        transform.Translate(Vector2.down * _movementSpeed * Time.deltaTime);
    }

    protected void SetAngle(Vector3 target)
    {
        Vector3 deltaPosition = target - transform.position;
        float angleZ = Mathf.Atan2(deltaPosition.y, deltaPosition.x) * Mathf.Rad2Deg;
        Quaternion angle = Quaternion.Euler(0, 0, angleZ + _angleOffset);
        transform.rotation = Quaternion.Lerp(transform.rotation, angle, Time.deltaTime * _rotationSpeed);
    }
}
