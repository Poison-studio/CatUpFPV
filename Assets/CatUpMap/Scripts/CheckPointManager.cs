using Hertzole.GoldPlayer;
using UnityEngine;
using UnityEngine.Events;

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

            if(Input.GetKeyDown(KeyCode.R) && restartTimer > restartTime)
            {
                restartTimer = 0;
                player.GetComponent<Health>().death.Invoke();
            }
        }
    }

}