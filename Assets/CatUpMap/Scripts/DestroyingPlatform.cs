using System.Collections.Generic;
using UnityEngine;

namespace CatUp
{
    public class DestroyingPlatform : MonoBehaviour
    {
        [SerializeField]
        private List<DestroyingPlatform> connected;

        private bool WasInitialized;
        private bool destroyable;

        void Start()
        {
            if (!WasInitialized && connected.Count != 0)
            {
                Setup();
            }
        }

        private void Setup()
        {
            connected.Add(this);

            int destroyableNumber = Random.Range(0, connected.Count);

            for (int i = 0; i < connected.Count; i++)
            {
                if (i == destroyableNumber)
                {
                    connected[i].Initialize(true);
                }
                else
                {
                    connected[i].Initialize(false);
                }
            }
        }

        public void Initialize(bool Destroyable)
        {
            WasInitialized = true;

            this.destroyable = Destroyable;
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player" && destroyable)
            {
                gameObject.AddComponent<Rigidbody>();
            }

            if (other.gameObject.tag != "Water" && other.gameObject.tag != "Player")
            {
                //Destroy(gameObject.GetComponent<Rigidbody>());
                gameObject.SetActive(false);
            }
        }
    }

}