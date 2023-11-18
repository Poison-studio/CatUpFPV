using UnityEngine;

namespace CatUp
{
    public class CheckPoint : MonoBehaviour
    {
        //Get current active checkpoint
        public static int activeID { get; private set; } = 0;
        //CheckPoints on map
        public static int maxID { get; private set; } = 0;

        public int localID { get; private set; }

        private void Awake()
        {
            localID = maxID;
            maxID++;
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.tag == "Player")
            {
                activeID = localID;
                Debug.Log("CheckPoint " + activeID + " enabled");
            }
        }
    }

}