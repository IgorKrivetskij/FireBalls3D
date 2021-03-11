using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Tank : MonoBehaviour
{
    [SerializeField] private Transform _bulletStartPosition;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private float _recoilDistance;

    private float _timeBetweenShoot;
    private float _timeDelay;

    private void Awake()
    {
        _timeDelay = 0.25f;
    }

    private void Update()
    {
        _timeBetweenShoot += Time.deltaTime;
        if (Input.GetMouseButton(0) && _timeBetweenShoot >= _timeDelay)
        {
            CreateBullet();
            transform.DOMoveZ(transform.position.z - _recoilDistance, _timeBetweenShoot / 2).SetLoops(2, LoopType.Yoyo);
            _timeBetweenShoot = 0;
        }
    }

    private void CreateBullet()
    {
        Instantiate(_bullet, _bulletStartPosition.position, Quaternion.identity);
    }
}
