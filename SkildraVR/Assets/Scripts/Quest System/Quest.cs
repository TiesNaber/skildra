using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using skildravr.story.actor;
using skildravr.interfaces;


namespace skildravr.story.quest {

    public enum QuestState {
        INIT= 0,
        START=1,
        INPROGRESS=2,
        ENDING=3,
        COMPLETED=4
    }

    public class Quest : MonoBehaviour, ICanAdd<Actor>{

        private List<Actor> actors; // List of participating actors
        private QuestState questState = QuestState.INIT; // Quest State

        private void setQuestState(QuestState state) {
            this.questState = state;
        }

        public QuestState getQuestState() {
            return this.questState;
        }

        public void AddActor(Actor actor) {
            if(CanAdd(actor))
                this.actors.Add(actor);
            else Debug.LogWarning("QUEST: AddActor -- Can't add actor");
        }

        private void ClearActorList(){
            actors.Clear();
        }

        public List<Actor> GetActors(){
            return actors;
        }

        public bool CanAdd(Actor actor) {
            if(actors != null && actor != null) {
                if(actors.Contains(actor)) return false;
                else return true;
            } else return false;
        }
    }
}