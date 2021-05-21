using UnityEngine;
using System.Collections;
using overexcited.vr.weapons.target;
using overexcited.vr.managers;

namespace overexcited.vr.controllers{

    public class ShootingRangeController : MonoBehaviour
    {
        private byte timesHit;
        private const byte maxHits = 5;

        [SerializeField]
        private float endGameTime; // In Minutes!
        private float maxIdleTime;
        private bool isIdle;

        private Coroutine idleTimerCoroutine;

        private OXC_SceneManager sceneManager;

        private void Start(){
            SubscribeToEvents();
        }

        private void InitInstance(){
            timesHit = 0;
            isIdle = false;
            maxIdleTime = minutesToSeconds();
            sceneManager = FindObjectOfType<OXC_SceneManager>();
            Debug.Log("Been Here");
        }

        /// <summary>
        /// Converts the maxIdleTime variable to the amount of seconds
        /// </summary>
        /// <returns>idle time in seconds</returns>
        private float minutesToSeconds(){
            return endGameTime * 60.0f;
        }

        private void BeginIdleTimer(){
            idleTimerCoroutine = StartCoroutine(trackIdleTime());
        }

        private void StopIdleTimer(){
            if(idleTimerCoroutine != null){
                StopCoroutine(idleTimerCoroutine);
            }
        }

        private IEnumerator trackIdleTime(){
        
            yield return new WaitForSeconds(endGameTime);
            EndScene();

        }


        private void TargetHit()
        {
            if (!isMaxHitsReached())
            {
                timesHit++;
                Debug.Log(timesHit);
            }
            else
            {
                EndScene();
            }
        }

        private bool isMaxHitsReached()
        {
            if (timesHit + 1 < maxHits)
                return false;
            else return true;
        }

        private void EndScene(){
            UnsubscribeFromEvents();
            sceneManager.LoadScene("end-screen");
        }

        private void SubscribeToEvents(){
            ShootingTarget.OnHitTarget += TargetHit;
        }
        private void UnsubscribeFromEvents(){
            ShootingTarget.OnHitTarget -= TargetHit;
        }

        private void OnDestroy()
        {
            UnsubscribeFromEvents();
        }
    }
}

