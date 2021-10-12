using UnityEngine;

namespace PlatformerGU.Views
{
    public class CharacterView : MonoBehaviour
    {
        private const string WALK_ANIMATION = "IsWalk";
        private const string JUMP_ANIMATION = "Jump";

        [SerializeField] private Animator _animator;

        public void PlayWalkAnimation(bool value)
        {
            _animator.SetBool(WALK_ANIMATION, value);
        }

        public void PlayJumpAnimation()
        {
            _animator.SetTrigger(JUMP_ANIMATION);
        }

        public void StopJumpAnimation()
        {
            _animator.ResetTrigger(JUMP_ANIMATION);
        }
    }
}

