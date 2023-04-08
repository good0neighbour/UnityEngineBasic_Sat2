using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDataModel : DataModelBase<ItemPair, InventoryDataModel>
{
    private string _path;

    protected override void Init()
    {
        base.Init();
        _path = Application.persistentDataPath + "/InventoryData.json";
        Load();
    }

    public override void Add(ItemPair item)
    {
        int index = IndexOf(x => x.id == item.id);
        if (index < 0)
        {
            base.Add(item);
        }
        else
        {
            this[index] = new ItemPair(item.id, item.num + data[index].num);
        }
    }

    public override void Save()
    {
        System.IO.File.WriteAllText(_path, JsonUtility.ToJson(new Data(data)));
    }

    public override void Load()
    {
        if (System.IO.File.Exists(_path) == false)
        {
            System.IO.File.WriteAllText(_path, JsonUtility.ToJson(new Data(data)));
        }
        
        data = JsonUtility.FromJson<Data>(System.IO.File.ReadAllText(_path)).items;
    }
}
