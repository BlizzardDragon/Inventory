using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;

public class Inventory
{
    [ShowInInspector, ReadOnly]
    private readonly List<InventoryItem> _items;
    private readonly List<IInventoryObserver> _observers = new();

    public Inventory()
    {
        _items = new List<InventoryItem>();
    }


    public void AddItem(InventoryItem item)
    {
        if (!_items.Contains(item))
        {
            _items.Add(item);
            OnItemAdded(item);
        }
    }

    public void TryRemoveItem(string name)
    {
        if (FindItem(name, out var item))
        {
            RemoveItem(item);
        }
    }

    public void RemoveItem(InventoryItem item)
    {
        if (_items.Remove(item))
        {
            OnItemRemoved(item);
        }
    }

    public InventoryItem GetItem(InventoryItem item)
    {
        if (!_items.Remove(item))
        {
            throw new Exception($"Item {item.Name} not found!");
        }

        OnItemRemoved(item);
        return item;
    }

    public void AddObserver(IInventoryObserver observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(IInventoryObserver observer)
    {
        _observers.Remove(observer);
    }

    public IReadOnlyList<InventoryItem> GetItems()
    {
        return _items;
    }

    public int GetItemsCount()
    {
        return _items.Count;
    }

    public bool IsItemExists(string name)
    {
        foreach (var intentoryItem in _items)
        {
            if (intentoryItem.Name == name)
            {
                return true;
            }
        }
        return false;
    }

    private bool FindItem(string name, out InventoryItem result)
    {
        foreach (var intentoryItem in _items)
        {
            if (intentoryItem.Name == name)
            {
                result = intentoryItem;
                return true;
            }
        }

        result = null;
        return false;
    }

    private void OnItemAdded(InventoryItem item)
    {
        foreach (var observer in _observers)
        {
            observer.OnItemAdded(item);
        }
    }

    private void OnItemRemoved(InventoryItem item)
    {
        foreach (var observer in _observers)
        {
            observer.OnItemRemoved(item);
        }
    }
}
