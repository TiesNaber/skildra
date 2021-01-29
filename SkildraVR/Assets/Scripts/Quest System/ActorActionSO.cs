using UnityEngine;


namespace skildravr.story.actor {
    [CreateAssetMenu(fileName = "ActorActionData", menuName = "ActorActions/ActorActionSO", order = 1)]
    public class ActorActionSO : ScriptableObject {
        [Tooltip("Responsible actor for this action")]
        public Actor actor;

        [Tooltip("Quest index for this action")]
        public int QuestIndex;

        [Tooltip("Name of the animation that should play for this action")]
        public string AnimationName;

        [Tooltip("Audio clip that should play during this action")]
        public AudioClip ScriptClip;
    }
}