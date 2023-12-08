using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/InventoryItem", order = 0)]
public class InventoryItemConfig : ScriptableObject
{
    public InventoryItem Prototype => _prototype;
    [SerializeField] private InventoryItem _prototype;


    [ContextMenu(nameof(SaveData))]
    public void SaveData()
    {
#if UNITY_EDITOR
        EditorUtility.SetDirty(this);
#endif
    }
}