using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSlider : MonoBehaviour
{
    [SerializeField] private Image _levelFeel;
    [SerializeField] private Tower _tower;
    private int _maxTowerSize;

    private void Start()
    {
        _maxTowerSize = _tower.TowerSize;
    }

    private void OnEnable()
    {
        _tower.UpdateTowerSize += OnUpdateTowerSize;
    }

    private void OnDisable()
    {
        _tower.UpdateTowerSize -= OnUpdateTowerSize; 
    }

    private void OnUpdateTowerSize(int towerSize)
    {
        _levelFeel.fillAmount = (float)towerSize / (float)_maxTowerSize;
    }
}
