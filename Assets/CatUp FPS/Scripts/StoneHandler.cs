using UnityEngine;

namespace CatUp
{
    public class StoneHandler : MonoBehaviour
    {
        [SerializeField]
        private GameObject stome;

        [SerializeField]
        private Transform spawnPosition;

        private Transform target;
        float multiplayer;

        public void Throw()
        {
            target ??= GetComponent<Machine>().data.target;

            Rigidbody body = Instantiate(stome, spawnPosition.position, Quaternion.identity, null).GetComponent<Rigidbody>();

            if (spawnPosition.position.y - target.position.y < 0) multiplayer = -0.3f;
            if (spawnPosition.position.y - target.position.y > 0) multiplayer = -0.1f;

            Vector3 throwVector = target.position - spawnPosition.position + Vector3.up * 5 + new Vector3(0, (spawnPosition.position.y - target.position.y),0) * multiplayer;
            throwVector = throwVector.normalized;

            float throwDistance = Vector3.Distance(target.position, spawnPosition.position) * 63;
            if(throwDistance < 530) throwDistance = 530;

            body.AddForce(throwVector * throwDistance);
            body.AddTorque(new Vector3(1,1,1));
        }
    }
}