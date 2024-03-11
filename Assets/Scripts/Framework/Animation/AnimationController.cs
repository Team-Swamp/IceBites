using System.Linq;
using UnityEngine;

namespace Framework.Animation
{
    public sealed class AnimationController : MonoBehaviour
    {
        private const string INVALID_ANIMATION = "Animation name does not exist in the Animator controller: ";
        private const string NO_ANIMATOR_ERROR = "Animator component is not assigned.";
        
        private Animator _animator;


        private void Awake() => _animator = GetComponent<Animator>();
        
        /// <summary>
        /// This will activate an animation based on triggers
        /// </summary>
        /// <param name="animationName">The trigger it will be activating</param>
        public void PlayAnimation(string animationName)
        {
            if (IsValidAnimation(animationName))
                _animator.SetTrigger(animationName);
        }
    
        private bool IsValidAnimation(string animationName)
        {
            if (_animator == null)
            {
                Debug.LogError(NO_ANIMATOR_ERROR);
                return false;
            }

            bool animationParameters = _animator.parameters.Any(animationParam  => animationParam .name == animationName);
            
            if (!animationParameters)
            {
                Debug.LogError(INVALID_ANIMATION + animationName);
                return false;
            }

            return true;
        }
    }
}