using System.Collections;
using UnityEngine;
using overexcited.vr.general;

namespace overexcited.vr.weapons.range
{
    [RequireComponent(typeof(Rigidbody))]
    public class Arrow : Interactable
    {
        [SerializeField] private Rigidbody rb;
        private bool isShot;
        float destroyTime = 5f;

        private Coroutine destroyCoroutine;


        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            InitObject();
        }

        private void OnEnable()
        {
            InitObject();
            if (rb != null)
                rb.velocity = Vector3.zero;
        }

        private void InitObject()
        {

            setKinematic(true);
            isShot = false;
        }


        public override void Drop()
        {
            setKinematic(false);
        }

        public override void PickUp()
        {
            if (rb.isKinematic != true)
            {
                setKinematic(true);
            }
        }

        private void Update()
        {
            if (isShot)
            {
                transform.LookAt(transform.position - rb.velocity);
                transform.Rotate(3, 0, 0);
            }
        }

        public void ApplyForce(float forceAmount)
        {
            setKinematic(false);
            rb.velocity = transform.forward * forceAmount;
            isShot = true;
            destroyCoroutine = StartCoroutine(destroyTimer(destroyTime));
        }

        /// <summary>
        /// True --> No Gravity;
        /// False --> Gravity;
        /// </summary>
        /// <param name="isKinematic"></param>
        private void setKinematic(bool isKinematic)
        {
            if (rb != null)
                rb.isKinematic = isKinematic;
        }

        public void Stick()
        {
            StopCoroutine(destroyCoroutine);
            rb.velocity = Vector3.zero;
            setKinematic(true);
            isShot = false;
        }

        private IEnumerator destroyTimer(float time)
        {

            yield return new WaitForSeconds(time);
            DeactivateObject();
        }

        private void DeactivateObject()
        {
            rb.velocity = Vector3.zero;
            setKinematic(true);
            isShot = false;
            if (transform.parent != null)
            {
                transform.SetParent(null, false);
            }
            this.gameObject.SetActive(false);
        }
    }
}