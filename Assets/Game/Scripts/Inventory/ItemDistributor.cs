public class ItemDistributor
{
    private readonly Inventory _mainInventory;
    private readonly EquipmentInventory _equipmentInventory;

    public ItemDistributor(Inventory mainInventory, EquipmentInventory equipmentInventory)
    {
        _mainInventory = mainInventory;
        _equipmentInventory = equipmentInventory;
    }


    public void TryEquip(InventoryItem item)
    {
        if (_equipmentInventory.TryAddEquipment(item))
        {
            _mainInventory.RemoveItem(item);
        }
    }

    public void Unequip(InventoryItem item)
    {
        _equipmentInventory.RemoveEquipment(item);
        _mainInventory.AddItem(item);
    }
}
