using Hertzole.GoldPlayer;
using UnityEngine;

namespace CatUp
{
    public class CheckPointManager : MonoBehaviour
    {
        private GameObject player;
        private CheckPoint[] checkPoints;

        [Tooltip("Allowed restart frequency")]
        [SerializeField]
        private float restartTime;

        private float restartTimer;

        public void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<Health>().death.AddListener(OnPlayerDeath);
            checkPoints = FindObjectsOfType<CheckPoint>();
        }

        private void OnPlayerDeath()
        {
            player.GetComponent<GoldPlayerController>().SetPositionAndRotation(GetCurrentCheckPointTransform(CheckPoint.activeID).position, GetCurrentCheckPointTransform(CheckPoint.activeID).rotation.y);
            player.GetComponent<GoldPlayerController>().Movement.AddForce(Vector3.zero, 0);
            //player.GetComponent<GoldPlayerController>().Movement.AddForce(player.GetComponent<GoldPlayerController>().Movement.Velocity.normalized, player.GetComponent<GoldPlayerController>().Movement.Velocity.y);
        }

        private Transform GetCurrentCheckPointTransform(int currentCheckPointNumber)
        {
            foreach (CheckPoint current in checkPoints)
            {
                if (current.localID == CheckPoint.activeID)
                {
                    return current.transform;
                }
            }

            return null;
        }

        //Временный рестарт
        private void Update()
        {

            restartTimer += Time.deltaTime;

            if(Input.GetKeyDown(KeyCode.R)/* && restartTimer > restartTime*/)
            {
                //OnPlayerDeath();
                restartTimer = 0;
                player.GetComponent<Health>().death.Invoke();
            }
        }
    }

}