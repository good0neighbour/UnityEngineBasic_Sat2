using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryView : MonoBehaviour
{
    [SerializeField] private Transform _contenct;
    [SerializeField] private InventoryViewSlot _slotPrefab;
    private List<InventoryViewSlot> _slots = new List<InventoryViewSlot>();
    private InventoryPresenter _presenter;

    private void Awake()
    {
        _presenter = new InventoryPresenter();
        _presenter.source.itemChanged += (index, item) =>
        {
            _slots[index].Set(ItemAssets.instance[item.id].icon, item.num);
        };

        InventoryViewSlot slot;
        for (int i = 0; i < 36; i++)
        {
            slot = Instantiate(_slotPrefab, _contenct);

            if (i < _presenter.source.Count)
                slot.Set(ItemAssets.instance[_presenter.source[i].id].icon,
                         _presenter.source[i].num);
            else
                slot.Set(ItemAssets.instance[ItemPair.empty.id].icon,
                         ItemPair.empty.num);
            _slots.Add(slot);
        }
    }
}