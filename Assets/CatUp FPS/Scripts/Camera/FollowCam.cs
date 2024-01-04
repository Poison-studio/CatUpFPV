using Cinemachine;
using UnityEngine;

namespace CatUp
{
    public class FollowCam : MonoBehaviour
    {
        [SerializeField]
        private Transform target;

        [SerializeField]
        private Health health;

        public void Start()
        {
            health.death.AddListener(OnDeath);
        }

        private void OnDeath(GameObject gameObject)
        {
            GetComponent<Camera>().fieldOfView = target.GetComponent<CinemachineVirtualCamera>().m_Lens.FieldOfView;
        }

        void Update()
        {
            transform.position = target.position;
            transform.rotation = target.rotation;
        }
    }

}