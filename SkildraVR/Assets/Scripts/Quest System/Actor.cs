using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace skildravr.story.actor {
    public class Actor : MonoBehaviour {

        private List<ActorActionSO> actorActions;
        private byte currentActionIndex = 0;

        private void ClearActions(){
            actorActions.Clear();
        }

        public void AddAction(ActorActionSO action){
            if(action == null || actorActions.Count  <= 0){
                
                return
            }
        }
        
    }
}
