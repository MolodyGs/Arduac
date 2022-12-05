using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreesList : MonoBehaviour, ITreesList
{

    private static TreesList _instance;
    public static ITreesList Instance => _instance;

    [Header("Trees List")]
    [SerializeField] private List<GameObject> _trees;

    private void Awake()
    {
        
        Initialization();

    }

    private void Initialization()
    {
        _instance = this;
    }

    public GameObject GetTree(int treeId, GameObject parent)
    {
        string treeName = "";
        switch(treeId)
        {
            case 0:
                treeName = "autumn_pine_01";
                break;
            case 1:
                treeName = "burned_pine_01";
                break;
            case 2:
                treeName = "fire_pine_01";
                break;
            case 3:
                treeName = "green_pine_01";
                break;
            case 4:
                treeName = "ice_pine_01";
                break;
            case 5:
                treeName = "Magical_pine_01";
                break;
            case 6:
                treeName = "winter_pine_01";
                break;

        }

        return Find(treeName, parent);

    }

    private GameObject Find(string name, GameObject parent)
    {

        Debug.Log("Longitud |" + _trees.Count+ "|");
        Debug.Log("Buscando |" + name + "|");
        GameObject treeAux = null;

        foreach(GameObject tree in _trees)
        {
            Debug.Log("Seleccionado |" + tree.name + "|");
            if(tree.name.Equals(name))
            {
                Debug.Log(!tree.activeSelf);
                if(!tree.activeSelf)
                {
                    return tree;
                }
                treeAux = tree;

            }

        }

        GameObject newTree = Instantiate(treeAux);
        newTree.name = treeAux.name;
        newTree.transform.SetParent(parent.transform);

        _trees.Add(newTree);
        return newTree;

    }

}
