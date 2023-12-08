public interface IEquipmentObserver
{
    void OnItemAdded(InventoryItem item, EquipmentTypes equipmentType);
    void OnItemRemoved(InventoryItem item, EquipmentTypes equipmentType);
}