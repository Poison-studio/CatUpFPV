using UnityEngine;
using UnityEngine.AI;

namespace CatUp
{
    [RequireComponent(typeof(PathPoints))]
    public class Patrol : Node
    {
        private NavMeshAgent agent;
        private PathPoints path;
        private int currentNumber;

        public Patrol(Transform[] pathPoints)
        {
            //path = GameObject.
        }

        public override void OnStateEnter()
        {
            currentNumber++;
            Debug.Log("Patrol Enter" + currentNumber);
        }

        public override void OnStateExit()
        {
            Debug.Log("Patrol Exit");
        }

        public override void Perform()
        {
            Debug.Log("Patrol Perform");
        }
    }
}
