using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private int _towerHight;
    [SerializeField] private Block _block;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Color[] _colors;

    private List<Block> _blocks = new List<Block>();

    public List<Block> BuildTower()
    {
        Transform blockSpawnPoint = _spawnPoint;
        for (int i = 0; i < _towerHight; i++)
        {
            Block newBlock = BuildBlock(blockSpawnPoint);
            newBlock.SetColor(_colors[Random.Range(0, _colors.Length)]);
            _blocks.Add(newBlock);
            blockSpawnPoint = newBlock.transform;
        }
        return _blocks;
    }

    private Block BuildBlock(Transform spawnPoint)
    {
        return Instantiate(_block, GetSpawnPosition(spawnPoint), Quaternion.identity, transform);
    }

    private Vector3 GetSpawnPosition(Transform spawnPoint)
    {
        return new Vector3(spawnPoint.position.x, spawnPoint.position.y + spawnPoint.localScale.y / 2 + _block.transform.localScale.y / 2, spawnPoint.position.z);
    }
}
