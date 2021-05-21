using UnityEngine;
using overexcited.vr.weapons.range;

namespace overexcited.vr.weapons.target
{
    [RequireComponent(typeof(Collider))]
    public class ShootingTarget : MonoBehaviour
    {
        public delegate void TargetEvent();
        public static event TargetEvent OnHitTarget;


        private bool isHittable;

        private void OnAwake(){
            isHittable = true;
        }

        private void TargetHit(){
            if(OnHitTarget != null){
                OnHitTarget();
                isHittable = true;
            }
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
