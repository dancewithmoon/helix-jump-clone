using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private TowerBuilder _towerPrefab;
    [SerializeField] private Ball _ballPrefab;

    private void Awake()
    {
        Instantiate(_towerPrefab);
        var startPlatform = FindObjectOfType<StartPlatform>();
        Instantiate(_ballPrefab, startPlatform.SpawnPoint, Quaternion.identity);
    }

}
