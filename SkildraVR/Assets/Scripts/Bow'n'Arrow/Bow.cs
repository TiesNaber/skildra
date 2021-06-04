using System.Collections;
using UnityEngine;
using overexcited.vr.general;

namespace overexcited.vr.weapons.range
{
    public class Bow : Interactable
    {
        [SerializeField] private Arrow currentArrow;
        [SerializeField] private float pullSpeed, releaseForce;

        [SerializeField] private Transform knockingPoint;
        private Vector3 knockingPointStartPos;
        private Vector3 maxPullPosition;
        private float maxPullValue_Z = 0.3f;

        private GameObject maxPoint;
        private bool isSpawning;
        private bool canShoot;

        private LineRenderer bowString;
        [SerializeField] private Transform topBow, botBow;

        private SFX_player sfx_Player;
        private bool isPulling;

        // Use this for initialization
        void Start()
        {
            maxPullPosition = new Vector3(0, 0, knockingPoint.localPosition.z - maxPullValue_Z);
            knockingPointStartPos = knockingPoint.localPosition;

            maxPoint = new GameObject("knockingPointMax");
            maxPoint.transform.SetParent(transform);
            maxPoint.transform.position = Vector3.zero;
            maxPoint.transform.localPosition = maxPullPosition;

            bowString = GetComponent<LineRenderer>();
            sfx_Player = GetComponent<SFX_player>();

            canShoot = true;
            isPulling = false;
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.D) && canShoot)
            {
                if (currentArrow != null)
                {
                    PullString();
                }
            }

            if (Input.GetKeyUp(KeyCode.D) && canShoot)
            {
                ReleaseString();
            }

            if (Input.GetKeyUp(KeyCode.S))
            {
                SpawnArrow();
            }
            updateLineRenderer();
        }

        void PullString()
        {
            if (!isPulling)
            {
                sfx_Player.PlayClip(0);
                isPulling = true;
            }

            if (knockingPoint.localPosition.z > maxPullPosition.z)
                knockingPoint.localPosition = Vector3.Lerp(knockingPoint.localPosition, maxPoint.transform.localPosition, pullSpeed * Time.deltaTime);
        }

        void ReleaseString()
        {
            if (currentArrow != null)
            {
                canShoot = false;
                ReleaseArrow();
                knockingPoint.localPosition = knockingPointStartPos;

                if (!isSpawning)
                {
                    isSpawning = true;
                    StartCoroutine(spawnNewArrowDelay());
                }
                isPulling = false;
            }
        }

        public override void PickUp()
        {
            throw new System.NotImplementedException("PickUp method not implemented yet");
        }


        private IEnumerator spawnNewArrowDelay()
        {
            yield return new WaitForSeconds(0.5f);
            SpawnArrow();
            isSpawning = false;
            canShoot = true;
        }

        private void PlaceArrow(Arrow arrow)
        {
            currentArrow = arrow;
        }

        private void ReleaseArrow()
        {
            Vector3 worldPos = transform.TransformPoint(knockingPoint.transform.localPosition);
            currentArrow.transform.SetParent(null);
            
            currentArrow.transform.position = worldPos;
            currentArrow.ApplyForce(calculatePullPower());
            
            currentArrow = null;
            sfx_Player.PlayClip(1);

        }

        private float calculatePullPower()
        {
            return (knockingPoint.localPosition.z * -1f * releaseForce);
        }

        private void SpawnArrow()
        {
            GameObject arrow = ObjectPooler.sharedInstance.GetPooledObject();
            if (arrow != null)
            {
                arrow.transform.position = knockingPoint.localPosition;
                arrow.transform.eulerAngles = knockingPoint.forward;
                arrow.transform.SetParent(knockingPoint, false);
                arrow.transform.localPosition = Vector3.zero;
                currentArrow = arrow.GetComponent<Arrow>();
                arrow.SetActive(true);
            }
        }

        private void updateLineRenderer()
        {
            bowString.SetPositions(new Vector3[] { topBow.localPosition, knockingPoint.localPosition, botBow.localPosition });
        }
    }
}