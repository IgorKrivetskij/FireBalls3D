using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierBuilder : MonoBehaviour
{
    [SerializeField] private Barrier[] _barriers;
    private int _barrierType;

    private void Awake()
    {
        _barrierType = Random.Range(0, _barriers.Length);
    }

    private void Start()
    {
        Instantiate(_barriers[_barrierType], transform.position, Quaternion.identity);
    }
}
