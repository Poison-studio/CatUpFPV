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
            machineData.meshAgent.SetDestination(pathPoints[currentPathPoint].position);
            machineData.animator.SetTrigger("Walk");
        }

        public override void OnStateExit()
        {
            exitCondition = false;
            currentPathPoint++;
            if (currentPathPoint >= pathPoints.Length)
            {
                currentPathPoint = 0;
            }
        }

        public override void Perform()
        {
            if (!machineData.meshAgent.hasPath || machineData.meshAgent.pathPending) return;

            if (machineData.meshAgent.remainingDistance <= machineData.meshAgent.stoppingDistance)
            {
                exitCondition = true;
            }
        }
    }
}
