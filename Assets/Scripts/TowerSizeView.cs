using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerSizeView : MonoBehaviour
{
    [SerializeField] private TMP_Text _towerSize;
    [SerializeField] private Tower _tower;
    
    private void OnEnable()
    {
        _tower.UpdateTowerSize += OnUpdateTowerSize;
    }

    private void OnDisable()
    {
        _tower.UpdateTowerSize -= OnUpdateTowerSize;
    }   

    private void OnUpdateTowerSize(int size)
    {
        _towerSize.text = size.ToString();
    }
}
