using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class EquipmentInventoryPresenter : MonoBehaviour, IEquipmentObserver
{
    [SerializeField] private ViewSlot _weapon;
    [SerializeField] private ViewSlot _shield;
    [SerializeField] private ViewSlot _helm;
    [SerializeField] private ViewSlot _armour;
    [SerializeField] private ViewSlot _gloves;
    [SerializeField] private ViewSlot _boots;

    private Dictionary<EquipmentTypes, ViewSlotPresenter> _slotPresenters;

    private ItemDistributor _distributor;


    [Inject]
    public void Construct(ItemDistributor distributor, EquipmentInventory equipmentInventory)
    {
        _distributor = distributor;
        equipmentInventory.AddObserver(this);
    }

    private void Awake()
    {
        _slotPresenters = new()
        {
            {EquipmentTypes.WEAPON,  new ViewSlotPresenter(_weapon, _distributor, SlotPresenterType.Unequipe)},
            {EquipmentTypes.SHIELD,  new ViewSlotPresenter(_shield, _distributor, SlotPresenterType.Unequipe)},
            {EquipmentTypes.HELM,  new ViewSlotPresenter(_helm, _distributor, SlotPresenterType.Unequipe)},
            {EquipmentTypes.ARMOUR,  new ViewSlotPresenter(_armour, _distributor, SlotPresenterType.Unequipe)},
            {EquipmentTypes.GLOVES,  new ViewSlotPresenter(_gloves, _distributor, SlotPresenterType.Unequipe)},
            {EquipmentTypes.BOOTS,  new ViewSlotPresenter(_boots, _distributor, SlotPresenterType.Unequipe)},
        };
    }

    public void OnItemAdded(InventoryItem item, EquipmentTypes equipmentType)
    {
        ViewSlotPresenter slotPresenter = _slotPresenters[equipmentType];
        slotPresenter.SetItem(item);
    }

    public void OnItemRemoved(InventoryItem _, EquipmentTypes equipmentType)
    {
        ViewSlotPresenter slotPresenter = _slotPresenters[equipmentType];
        slotPresenter.RemoveItem();
    }
}