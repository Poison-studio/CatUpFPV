using UnityEngine;

namespace CatUp
{
    public class DestroyTimer : MonoBehaviour
    {
        float timer = 0f;

        [SerializeField]
        private float destroyTime;

        void Update()
        {
            timer += Time.deltaTime;

            if(timer > destroyTime)
            {
                Destroy(gameObject);
            }
        }
    }

}