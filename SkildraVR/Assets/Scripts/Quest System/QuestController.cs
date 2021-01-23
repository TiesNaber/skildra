using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  -------------- TO DO -------------------------
///  * Start quest
///  * Wait for quest to finish
///  * Complete quest
///  * Start new Quest
///  
///  * Add Actor events
///     - Talk
///     - Wait for input
///     - Animations
///     - Done
///     
///   *Story
///     - State
///     - Current Actors
///     - Current Quest
///     - Music to play
///     - Story controller
///  
/// </summary>

namespace skildravr.story.quest {
    public class QuestController : MonoBehaviour {
        private Quest currentQuest;
        private Coroutine stateCoroutine;
        

        public Quest getCurrentQuest() {
            return this.currentQuest;
        }

        private void setCurrentQuest(Quest quest) {
            if(currentQuest == null || quest == null) {
                Debug.LogWarning("QUESTCONTROLLER: CURRENT QUEST EQUALS NULL");
                return;
            } else {
                if(currentQuest.getQuestState() == QuestState.COMPLETED)
                    this.currentQuest = quest;
            }
        }

        private void BeginQuestPhase(){
            stateCoroutine = StartCoroutine(IEStateChecker(currentQuest.getQuestState()));
        }

        private void TerminateQuestPhase(){
            StopCoroutine(stateCoroutine);
        }

        // Wait for the state to change. if changing -->  callback;
        private IEnumerator IEStateChecker(QuestState state){
            while(state == currentQuest.getQuestState()){
                yield return null;
            }
        }
    }
}
