using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityHFSM;

namespace CatUp
{
    public abstract class Machine : MonoBehaviour
    {
        protected StateMachine machine;
        protected List<State> statesToInitialize;

        public MachineData machineData;

        [SerializeField]
        private string currentState;

        private bool stopMachine = false;

        protected void InitializeStates()
        {
            foreach (State pickedState in statesToInitialize)
            {
                machine.AddState(pickedState, onLogic: state => pickedState.Perform(), onEnter: state => pickedState.OnStateEnter(), onExit: state => pickedState.OnStateExit());
            }
        }

        public void TriggerTransition(string triggetName)
        {
            machine.Trigger(triggetName);
        }

        public void Stop()
        {
            stopMachine = true;
        }

        protected void Update()
        {
            if (stopMachine) return;

            machine.OnLogic();
            currentState = machine.ActiveStateName;
        }
    }

}