using UnityEditor;
using UnityEngine;

class UpdatePrefab
{
       const string menuTitle2 = "Cards/Update Cards From Selected";

    /// <summary>
    /// Creates a prefab from the selected game object.
    /// </summary>
    
    static void CreatePrefab(GameObject o = null)
    {
        GameObject obj;
        if (o == null)
            obj = Selection.activeGameObject;
        else
            obj = o;

        string name = obj.name;

        Object prefab = PrefabUtility.CreateEmptyPrefab("Assets/Prefabs/Cards/Minion/" + name + ".prefab");
        PrefabUtility.ReplacePrefab(obj, prefab);
        AssetDatabase.Refresh();
    }

    [MenuItem(menuTitle2)]
    static void UpdatePrefabs()
    {
        GameObject[] objs = Selection.gameObjects;

        foreach (GameObject o in objs)
        {
            CreatePrefab(o);
        }

    }

    /// <summary>
    /// Validates the menu.
    /// </summary>
    /// <remarks>The item will be disabled if no game object is selected.</remarks>
    
    [MenuItem(menuTitle2, true)]
    static bool ValidateUpdateCreatePrefab()
    {
        return Selection.activeGameObject != null;
    }
}