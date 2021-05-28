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

        private void Start(){
            isHittable = true;
        }

        private void TargetHit(){
            if(OnHitTarget != null){
                OnHitTarget();
                isHittable = true;
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                TargetHit();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            var arrow = other.GetComponentInParent<Arrow>();
            if(arrow != null && isHittable){
                isHittable = false;
                TargetHit();
                arrow.Stick();
            }
        }
    }
}
