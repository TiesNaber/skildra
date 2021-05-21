using UnityEngine;
using System.Collections;
using overexcited.vr.weapons.target;

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

        private void OnAwake(){
            SubscribeToEvents();
        }

        private void InitInstance(){
            timesHit = 0;
            isIdle = false;
            maxIdleTime = minutesToSeconds();
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
        
        }


        private void TargetHit()
        {
            if (!isMaxHitsReached())
            {
                timesHit++;
            }
            else
            {
                throw new System.Exception("SHOULD END SCENE, BUT NOT IMPLEMENTED YET");// Call End Scene
            }
        }

        private bool isMaxHitsReached()
        {
            if (timesHit < maxHits)
                return false;
            else return true;
        }

        private void SubscribeToEvents(){
            ShootingTarget.OnHitTarget += TargetHit;
        }
        private void UnsubscribeToEvents(){
            ShootingTarget.OnHitTarget -= TargetHit;
        }

        private void OnDestroy()
        {
            UnsubscribeToEvents();
        }
    }
}

