using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using skildravr.story.actor;
using skildravr.interfaces;
using skildravr.story.quest.scriptableobjects;

namespace skildravr.story.quest {

    public enum QuestState {
        INIT= 0,
        START=1,
        INPROGRESS=2,
        ENDING=3,
        COMPLETED=4
    }

    [System.Serializable]
    public class Quest {


        [SerializeField] private QuestSO currentQuestData;

        private Dictionary<QuestState, ActorActionSO> actingSequence = new Dictionary<QuestState, ActorActionSO>();
       

        public void setQuestState(QuestState state) {
            this.currentQuestData.state = state;
        }

        public QuestState getQuestState() {
            return this.currentQuestData.state;
        }

        public void setCurrentQuest(QuestSO newQuestData){
            this.currentQuestData = newQuestData;
        }

        public QuestSO getCurrentQuest(){
            return this.currentQuestData;
        }

        public ActorActionSO[] getActorActions(){
            return this.currentQuestData.actorActions;
        }

         public void InitDictionary(){
            foreach(ActorActionSO item in getActorActions()){
                actingSequence.Add(item.state, item);
            }
        }

        public ActorActionSO[] getActionsByState(QuestState state){
            List<ActorActionSO> entries = new List<ActorActionSO>();
            foreach(KeyValuePair<QuestState, ActorActionSO> entry in actingSequence){
                if(entry.Key == state){
                    entries.Add(entry.Value);
                }
            }
            return entries.ToArray();
        }

        
 
    }
}