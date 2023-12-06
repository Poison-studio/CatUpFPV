using Cinemachine;
using UnityEngine;

public class DollySwitcher : MonoBehaviour
{
    [SerializeField]
    private GameObject cart;


    void Start()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cart")
        {
            GetComponent<BoxCollider>().enabled = false;
            cart.SetActive(true);
            other.gameObject.SetActive(false);
        }
    }
}
