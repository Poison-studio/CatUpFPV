using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Yarn.Compiler.BasicBlock;

namespace CatUp
{
    public class ArrowNavigator : MonoBehaviour
    {
        [SerializeField]
        private Transform target;

        private float rotationSpeed = 4f;


        void Start()
        {
            target = FindObjectOfType<SkeletonMachine>().transform;
            StartCoroutine(RotateArrow());
        }

        IEnumerator RotateArrow()
        {
            while (true)
            {
                Vector3 relativeTarget = transform.parent.InverseTransformPoint(target.position);

                float neededRotation = Mathf.Atan2(relativeTarget.x, relativeTarget.z) * Mathf.Rad2Deg;

                Quaternion targetLocalRotation = Quaternion.Euler(0, neededRotation, 0);

                // Плавное вращение стрелки в локальной системе координат
                transform.localRotation = Quaternion.Slerp(transform.localRotation, targetLocalRotation, rotationSpeed * Time.deltaTime);

                yield return null;
            }
        }
    }

}