using UnityEngine;

namespace CatUp
{
    public class Stone : MonoBehaviour
    {
        [SerializeField]
        private GameObject stome;

        [SerializeField]
        private Transform spawnPosition;

        [SerializeField]
        private Transform player;
        float multiplayer;

        public void Throw()
        {
            Rigidbody body = Instantiate(stome, spawnPosition.position, Quaternion.identity, null).GetComponent<Rigidbody>();

            if (spawnPosition.position.y - player.position.y < 0) multiplayer = -0.3f;
            if (spawnPosition.position.y - player.position.y > 0) multiplayer = -0.1f;

            Vector3 throwVector = player.position - spawnPosition.position + Vector3.up * 5 + new Vector3(0, (spawnPosition.position.y - player.position.y),0) * multiplayer;
            throwVector = throwVector.normalized;

            float throwDistance = Vector3.Distance(player.position, spawnPosition.position) * 63;
            Debug.Log(throwDistance);
            if(throwDistance < 530) throwDistance = 530;

            //Debug.Log(Vector3.Distance(player.position, spawnPosition.position));

            //if(Vector3.Distance(player.position, spawnPosition.position) < 9)
            //{
            //    throwDistance *= 1.2f;
            //}

            body.GetComponent<Rigidbody>().AddForce(throwVector * throwDistance);
        }
    }
}