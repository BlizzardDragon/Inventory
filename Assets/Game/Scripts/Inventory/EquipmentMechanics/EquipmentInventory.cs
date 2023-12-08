using System;
using System.Collections.Generic;

public sealed class EquipmentInventory
{
    private readonly List<IEquipmentObserver> _observers = new();
    private readonly Dictionary<EquipmentTypes, InventoryItem> _items = new()
    {
        {EquipmentTypes.HELM, null},
        {EquipmentTypes.ARMOUR, null},
        {EquipmentTypes.GLOVES, null},
        {EquipmentTypes.BOOTS, null},
        {EquipmentTypes.WEAPON, null},
        {EquipmentTypes.SHIELD, null},
    };


    public bool TryAddEquipment(InventoryItem item)
    {
        if (!item.HasFlag(InventoryItemFlags.EQUIPPABLE)) return false;

        var type = item.GetComponent<EquipmentTypeComponent>().GetEquipmentType();

        CheckForException(type);

        if (_items[type] == null)
        {
            OnAddEquipment(type, item);
            return true;
        }
        else
        {
            return false;
        }
    }

    public InventoryItem RemoveEquipment(string name)
    {
        foreach (var item in _items)
        {
            if (item.Value.Name == name)
            {
                OnRemoveEquipment(item.Key, item.Value);
                return item.Value;
            }
        }

        throw new Exception($"Item with name {name} not found!");
    }

    public void RemoveEquipment(InventoryItem item)
    {
        var type = item.GetComponent<EquipmentTypeComponent>().GetEquipmentType();

        CheckForException(type);

        if (_items[type] == item)
        {
            OnRemoveEquipment(type, item);
        }
        else
        {
            throw new Exception($"Item {item.Name} not found!");
        }
    }

    public void AddObserver(IEquipmentObserver observer) => _observers.Add(observer);
    public void RemoveObserver(IEquipmentObserver observer) => _observers.Remove(observer);

    private void CheckForException(EquipmentTypes type)
    {
        if (!_items.ContainsKey(type))
        {
            throw new Exception($"Type {type} is missing!");
        }
    }

    private void OnAddEquipment(EquipmentTypes key, InventoryItem value)
    {
        _items[key] = value;

        foreach (var observer in _observers)
        {
            observer.OnItemAdded(value, key);
        }
    }

    private void OnRemoveEquipment(EquipmentTypes key, InventoryItem value)
    {
        _items[key] = null;
        
        foreach (var observer in _observers)
        {
            observer.OnItemRemoved(value, key);
        }
    }
}