using System.Linq;
using UnityEngine;

namespace Framework.Animation
{
    public abstract class AnimationController : MonoBehaviour
    {
        protected Animator p_animator;

        protected virtual void Awake() => p_animator = GetComponent<Animator>();

        protected virtual void PlayAnimation(string animationName)
        {
            if (IsValidAnimation(animationName));
                p_animator.SetTrigger(animationName);
        }
    
        protected bool IsValidAnimation(string animationName)
        {
            if (p_animator == null)
            {
                Debug.LogError("Animator component is not assigned.");
                return false;
            }

            bool animationParameters = p_animator.parameters.Any(param => param.name == animationName);
            if (animationParameters)
                return true;
            else
            {
                Debug.LogError("Animation name does not exist in the Animator controller: " + animationName);
                return false;
            }
        }
    }
}