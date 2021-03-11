using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _bounceForce;
    [SerializeField] private float _bounceRadius;

    private Vector3 _mooveDirection;

    private void Awake()
    {
        _mooveDirection = transform.forward;
    }

    private void Update()
    {
        transform.Translate(_mooveDirection * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Block>(out Block block))
        {
            block.BreakeBlock();
            Destroy(gameObject);
        }
        if (other.TryGetComponent<BarrierAcr>(out BarrierAcr barrier))
        {
            Bounce();
            Destroy(gameObject, 5f);
        }
    }

    private void Bounce()
    {
        _mooveDirection = Vector3.up + Vector3.back;
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddExplosionForce(_bounceForce, new Vector3(0, -0.2f, 1), _bounceRadius);
    }
}
