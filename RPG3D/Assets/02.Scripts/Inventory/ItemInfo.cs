using UnityEngine;

[CreateAssetMenu(fileName = "new ItemInfo", menuName = "RPG/Create itemInfo")]
public class ItemInfo : ScriptableObject
{
    public int id;
    public Sprite icon;
    new public string name;
    public string description;
}