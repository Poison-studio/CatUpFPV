using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject skeletonPrefab;

    [SerializeField]
    private Transform spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            GameObject emeny = Instantiate(skeletonPrefab,spawnPosition);
            emeny.transform.parent = null;
        }
    }

}
