using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using skildravr.story.actor;

namespace skildravr.story.quest {
    public class QuestController : MonoBehaviour {
        [SerializeField]private Quest currentQuest;

        private Quest[] quests;
        private Coroutine stateCoroutine;

        [SerializeField] private ActorActionSO[] phaseActions;


        private void Awake() {
            OnInit();
        }

        private void OnInit(){
            currentQuest = new Quest();
            currentQuest.InitDictionary();
        }
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

        private void InitQuestPhase(){
            phaseActions = currentQuest.getActionsByState(currentQuest.getQuestState());

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
