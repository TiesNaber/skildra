using System.Collections;
using UnityEngine;
using overexcited.vr.weapons.range;

namespace overexcited.vr.weapons.target
{
    [RequireComponent(typeof(Collider))]
    public class ShootingTarget : MonoBehaviour
    {
        private byte timesHit;
        private const byte maxHits = 5;
        private bool isHittable;

        private void OnAwake(){
            timesHit = 0;
            isHittable = true;
        }

        private void TargetHit(){
            if(!isMaxHitsReached()){ 
                timesHit++;
                isHittable = true;
            }else{
                throw new System.Exception("SHOULD END SCENE, BUT NOT IMPLEMENTED YET");// Call End Scene
            }
        }

        private bool isMaxHitsReached(){
            if (timesHit < maxHits)
                return false;
            else return true;
        }

        private void OnTriggerEnter(Collider other)
        {
            var arrow = other.GetComponent<Arrow>();
            if(arrow != null && isHittable){
                isHittable = false;
                TargetHit();
            }
        }
    }
}
