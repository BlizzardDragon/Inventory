using Sirenix.OdinInspector;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/InventoryItem", order = 0)]
public class InventoryItemConfig : ScriptableObject
{
    public InventoryItem Prototype => _prototype;
    [SerializeField] private InventoryItem _prototype;


[Button]
    public void SaveChanges()
    {
#if UNITY_EDITOR
        EditorUtility.SetDirty(this);
        EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
        EditorSceneManager.SaveScene(EditorSceneManager.GetActiveScene());
        Debug.Log("Changes saved!");
#endif
    }
}