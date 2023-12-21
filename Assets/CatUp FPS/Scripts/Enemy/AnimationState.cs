using UnityEngine;

namespace CatUp
{
    public class AnimationState : MonoBehaviour
    {
        [SerializeField]
        private AudioClip clip;

        [SerializeField]
        private AudioSource source;

        private void Start()
        {
            Animator animator = GetComponent<Animator>();
            AnimatorStateInfo animationState = animator.GetCurrentAnimatorStateInfo(0);
            animator.Play(animationState.fullPathHash, 0, Random.Range(0f, 1f));
        }

        public void PlayWalkSound()
        {
            Debug.Log("Sound");
            source.clip = clip;
            source.Play();
        }
    }

}