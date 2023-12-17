using UnityEngine;

namespace CatUp
{
    public class DollySwitcher : MonoBehaviour
    {
        [Tooltip("Новая вагонетка, на которую мы переключаемся")]
        [SerializeField]
        private GameObject cart;

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

}