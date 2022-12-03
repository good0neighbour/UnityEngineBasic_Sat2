using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAssets : MonoBehaviour
{
    private static TowerAssets _instance;
    public static TowerAssets Instance
    {
        get
        {
            if (_instance == null)
                _instance = Instantiate(Resources.Load<TowerAssets>("TowerAssets"));
            return _instance;
        }
    }

    [SerializeField] private List<Tower> _towers = new List<Tower>();
    [SerializeField] private List<GameObject> _previewTowers = new List<GameObject>();

    public bool TryGetTower(TowerInfo info, out Tower tower)
    {
        tower = _towers.Find(t => t.Info.Equals(info));
        return tower;
    }

    public bool TryGetPreviewTower(TowerInfo info, out GameObject previewTower)
    {
        previewTower = _previewTowers.Find(t => t.name.Contains(info.name));
        return previewTower;
    }
}
