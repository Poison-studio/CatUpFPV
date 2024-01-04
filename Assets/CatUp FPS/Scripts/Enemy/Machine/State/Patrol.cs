using UnityEngine;

namespace CatUp
{
    public class Patrol : State
    {
        private Transform[] pathPoints;
        private int currentPathPoint;

        public Patrol(MachineData machineData, Transform[] pathPoints) : base(machineData)
        {
            this.pathPoints = pathPoints;
            currentPathPoint = 0;
        }

        public override void OnStateEnter()
        {
            data.meshAgent.SetDestination(pathPoints[currentPathPoint].position);
            data.animator.SetTrigger("Walk");
        }

        public override void OnStateExit()
        {
            exitCondition[0] = false;
            currentPathPoint++;
            if (currentPathPoint >= pathPoints.Length)
            {
                currentPathPoint = 0;
            }
        }

        public override void Perform()
        {
            if (!data.meshAgent.hasPath || data.meshAgent.pathPending) return;

            if (data.meshAgent.remainingDistance <= data.meshAgent.stoppingDistance)
            {
                exitCondition[0] = true;
            }
        }
    }
}
