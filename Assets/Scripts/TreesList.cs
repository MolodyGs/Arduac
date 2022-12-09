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

    //Devuelve un árbol existente si encuentra uno en desuso, o crea un nuevo árbol del tipo necesario
    //treeId: Id del árbol buscado. parent: GameObject padre de los áboles
    public GameObject GetTree(int treeId, GameObject parent)
    {

        foreach(GameObject tree in _trees)
        {

            if(!tree.name.Equals(_trees[treeId].name)){continue;}
            if(tree.activeSelf){continue;}
        
            return tree;

        }

        GameObject newTree = Instantiate(_trees[treeId]);
        newTree.name = _trees[treeId].name;
        newTree.transform.SetParent(parent.transform);
        _trees.Add(newTree);

        return newTree;

    }

}
