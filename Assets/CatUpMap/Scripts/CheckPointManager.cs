using CatUp;
using Hertzole.GoldPlayer;
using UnityEngine;

namespace CatUp
{
    public class CheckPointManager : MonoBehaviour
    {
        private GameObject player;
        private CheckPoint[] checkPoints;

        public void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<Health>().death.AddListener(OnPlayerDeath);
            checkPoints = FindObjectsOfType<CheckPoint>();
        }

        private void OnPlayerDeath()
        {
            player.GetComponent<GoldPlayerController>().SetPositionAndRotation(GetCurrentCheckPointTransform(CheckPoint.activeID).position, GetCurrentCheckPointTransform(CheckPoint.activeID).rotation.y);
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
    }

}