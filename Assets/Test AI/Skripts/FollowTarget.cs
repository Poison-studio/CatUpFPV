using UnityEngine;
using UnityEngine.AI;

namespace CatUp
{
    public class FollowTarget : State
    {
        private NavMeshAgent agent;
        private float distance = 3;

        public FollowTarget(MachineData data,NavMeshAgent agent) : base(data)
        {
            this.agent = agent;
        }

        public override void OnStateEnter()
        {
            machineData.animator.SetTrigger("Run");
        }

        public override void OnStateExit()
        {
            exitCondition = false;
        }

        public override void Perform()
        {
            agent.SetDestination(machineData.target.position);

            if(Vector3.Distance(machineData.target.position, machineData.agent.position) < distance)
            {
                exitCondition = true;
            }
        }
    }

}