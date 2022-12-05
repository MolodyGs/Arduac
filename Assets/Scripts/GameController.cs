using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    
    [SerializeField] private GameObject _arduac;
    [SerializeField] private TextMeshProUGUI _countTreesText;
    [SerializeField] private GameObject treeParent;
    private int _countTrees;
    Vector3 aux1 = new Vector3();

    private WaitForSeconds _waitForFive;

    private void Awake()
    {
        
        Initialization();
        
    }

    private void Initialization()
    {

        _waitForFive = new WaitForSeconds(5);
        this._countTreesText.text = "Trees: " + PlayerPrefs.GetInt("countTrees", 0);

    }

    private void Update()
    {
        //Vector3 aux1 = new Vector3();
        if(Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            float distance = 100f;
            Debug.DrawRay(ray.origin, ray.direction*distance, Color.black);

            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, distance))
            {

                if(hit.collider != null)
                {
                    if(!hit.transform.name.Equals("Arduac"))
                    {
                        return;
                    }
                    GameObject tree =  TreesList.Instance.GetTree(Random.Range(0, 6), treeParent);

                    tree.transform.position = hit.point;
                    tree.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
                    tree.SetActive(true);

                    MusicController.Instance.TreeFx();

                    StartCoroutine(WaitTree(tree));

                    PlayerPrefs.SetInt("countTrees", PlayerPrefs.GetInt("countTrees", 0) + 1);
                    this._countTreesText.text = "Trees: " + PlayerPrefs.GetInt("countTrees", 0);
                
                }

            }

        }

    }

    IEnumerator WaitTree(GameObject tree)
    {
        yield return _waitForFive;
        tree.SetActive(false);
    }

    public void OnEnterTarget()
    {
        MusicController.Instance.UnpauseMusic();
    }

    public void OnExitTarget()
    {
        MusicController.Instance.PauseMusic();
    }
   
}
