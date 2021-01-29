using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using skildravr.story.actor;
using skildravr.story.quest;
namespace skildravr.story.quest.scriptableobjects {

    [CreateAssetMenu(fileName = "QuestData", menuName = "Scriptable Objects/QuestData/QuestSO", order = 1)]
    public class QuestSO : ScriptableObject {
        [SerializeField] private Actor[] actors;

        public ActorActionSO[] actorActions;
        [HideInInspector] public QuestState state;

        
    }
}

