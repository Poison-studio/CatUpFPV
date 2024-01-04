using UnityEngine;

namespace CatUp
{
    public class Idle : State
    {
        private float timer = 0f;
        private float waitTime = 2f;
        private bool useTimer;

        public Idle(MachineData machineData, bool useTimer) : base(machineData) 
        {
            this.useTimer = useTimer;
        }

        public override void OnStateEnter()
        {
            data.meshAgent.isStopped = true;
            data.animator.SetTrigger("Idle");
        }

        public override void OnStateExit()
        {
            data.meshAgent.isStopped = false;
            timer = 0f;
            exitCondition[0] = false;
        }

        public override void Perform()
        {
            if (!useTimer) return;
            timer += Time.deltaTime;

            if(timer > waitTime)
            {
                exitCondition[0] = true;
            }
        }
    }

}