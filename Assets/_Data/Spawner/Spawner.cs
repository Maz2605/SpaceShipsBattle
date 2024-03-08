
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MazMonobehaviour
{
    [SerializeField] protected List<Transform> Prefabs;

    protected override void loadCompoments()
    {
        base.loadCompoments();
        this.loadPrefabs();
    }

    protected virtual void loadPrefabs()
    {
        Transform prefabsObject = transform.Find("Prefabs");
        foreach (Transform prefabs in prefabsObject)
        {
            this.Prefabs.Add(prefabs);
        }
        this.HidePrefab();
    }

    protected virtual void HidePrefab()
    {
        foreach (Transform prefab in this.Prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }

    public virtual Transform Spawn(string prefabName,Vector3 spawnPos, Quaternion rolation)
    {
        Transform prefab = this.getPrefabByName(prefabName);
        if (prefab == null)
        {
            Debug.LogWarning("Prefab not found: " + prefabName);
            return null;
        }

        Transform newPrefab = Instantiate(prefab, spawnPos, rolation);
        return newPrefab; 
    }

    protected Transform getPrefabByName(string prefabName)
    {
        foreach (Transform prefab in Prefabs)
        {
            if (prefab.name.Equals(prefabName))
                return prefab;
        }

        return null;
    }
    
}
