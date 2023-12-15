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
            player.GetComponent<PlayerHealth>().respawn.AddListener(Respawn);
            checkPoints = FindObjectsOfType<CheckPoint>();
        }

        private void Respawn()
        {
            player.GetComponent<GoldPlayerController>().SetPositionAndRotation(GetCurrentCheckPointTransform(CheckPoint.activeID).position, GetCurrentCheckPointTransform(CheckPoint.activeID).eulerAngles.y);
            player.GetComponent<GoldPlayerController>().Movement.AddForce(Vector3.zero, 0);
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

            if(Input.GetKeyDown(KeyCode.O) && restartTimer > restartTime)
            {
                restartTimer = 0;
                player.GetComponent<PlayerHealth>().death.Invoke();
            }
        }
    }

}