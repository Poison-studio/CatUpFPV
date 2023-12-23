using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatUp
{
    public class Idle : Node
    {
        public override void OnStateEnter()
        {
            Debug.Log("Idle Enter");
        }

        public override void OnStateExit()
        {
            Debug.Log("Idle Exit");
        }

        public override void Perform()
        {
            Debug.Log("Idle Perform");
        }
    }

}