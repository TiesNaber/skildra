using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using skildravr.interfaces;

namespace skildravr.story.actor {
    public class Actor : MonoBehaviour, ICanAdd<ActorActionSO> {

        private List<ActorActionSO> actorActions;
        private byte currentActionIndex = 0;
        public string actorName;

        private void ClearActions(){
            actorActions.Clear();
        }

        public bool CanAdd(ActorActionSO action) {
            if(action == null || actorActions.Count <= 0) {
                return false;
            } else return true;
        }

        public void setActorActions(List<ActorActionSO> actions){
            this.actorActions = actions;
        }

        private void setNextActionIndex(){
            if(currentActionIndex + 1 < actorActions.Count - 1) {
                currentActionIndex++;
            } else return;
        }

        public string getActorName(){
            return this.actorName;
        }

        private void setActorName(string name){
            this.actorName = name;
        }

        
    }
}
