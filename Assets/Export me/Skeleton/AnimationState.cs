using UnityEngine;

namespace CatUp
{
    public class AnimationState : MonoBehaviour
    {
        private void Start()
        {
            Animator animator = GetComponent<Animator>();
            AnimatorStateInfo animationState = animator.GetCurrentAnimatorStateInfo(0);
            animator.Play(animationState.fullPathHash, 0, Random.Range(0f, 1f));
        }
    }

}