using Framework.Animation;

namespace NPC
{
    public sealed class NpcAnimationController : AnimationController
    {
        public void PlayNpcAnimation(string animationName) => PlayAnimation(animationName);
    }
}
