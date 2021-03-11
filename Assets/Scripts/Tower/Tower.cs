using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TowerBuilder))]
public class Tower : MonoBehaviour
{
    private TowerBuilder _towerBuilder;
    private List<Block> _blocks;

    public event UnityAction<int> UpdateTowerSize;
    public int TowerSize => _blocks.Count;

    private void Awake()
    {
        _towerBuilder = GetComponent<TowerBuilder>();
        _blocks= _towerBuilder.BuildTower();
    }

    private void Start()
    {
        foreach (var block in _blocks)
        {
            block.BlockHit += OnBlockHit;
        }
        UpdateTowerSize?.Invoke(_blocks.Count);
    }

    private void OnBlockHit(Block hitBlock)
    {
        hitBlock.BlockHit -= OnBlockHit;
        _blocks.Remove(hitBlock);
        MooveBlocksInTower();
        UpdateTowerSize?.Invoke(_blocks.Count);
    }

    private void MooveBlocksInTower()
    {
        foreach (var block in _blocks)
        {
            block.transform.position = new Vector3(block.transform.position.x, block.transform.position.y - block.transform.localScale.y , block.transform.position.z);
        }
    }
}
