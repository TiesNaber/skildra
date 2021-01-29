using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using skildravr.interfaces;

namespace skildravr.story.actor {
    public class Actor : MonoBehaviour, ICanAdd<ActorActionSO> {

        private List<ActorActionSO> actorActions;
        private byte currentActionIndex = 0;
        public string actorName{ get; private set; }

        private void ClearActions(){
            actorActions.Clear();
        }

        public bool CanAdd(ActorActionSO action) {
            if(action == null || actorActions.Count <= 0) {
                return false;
            } else return true;
        }
    }
}
