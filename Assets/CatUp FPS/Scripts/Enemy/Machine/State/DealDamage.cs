using UnityEngine;

namespace CatUp
{
    public class DealDamage : State
    {
        private float distance = 4;

        public DealDamage(MachineData machineData) : base(machineData) { }

        public override void OnStateEnter()
        {
            //data.animator.ResetTrigger();
            data.animator.SetTrigger("Attack");
        }

        public override void OnStateExit()
        {
            exitCondition[0] = false;
        }

        public override void Perform()
        {
            float exitTime = data.animator.GetCurrentAnimatorStateInfo(0).normalizedTime % data.animator.GetCurrentAnimatorClipInfo(0).Length;

            if ((Vector3.Distance(data.target.position, data.agent.position) > distance) && exitTime > 0.8f)
            {
                exitCondition[0] = true;
            }
        }
    }

}