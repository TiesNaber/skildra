using System.Collections;
using UnityEngine;
using overexcited.vr.general;

namespace overexcited.vr.weapons.range
{
    public class Bow : Interactable
    {
        [SerializeField] private Arrow currentArrow;
        [SerializeField] private GameObject arrowPrefab;
        [SerializeField] private float pullSpeed, releaseForce;

        [SerializeField] private Transform knockingPoint;
        private Vector3 maxPullPosition;
        private float maxPullValue_Z = 0.3f;

        private GameObject maxPoint;
        private bool isSpawning;

        private LineRenderer bowString;
        [SerializeField] private Transform topBow, botBow;

        // Use this for initialization
        void Start()
        {
            maxPullPosition = new Vector3(0,0, knockingPoint.localPosition.z - maxPullValue_Z);

            maxPoint = new GameObject("knockingPointMax");
            maxPoint.transform.SetParent(transform);
            maxPoint.transform.position = Vector3.zero;
            maxPoint.transform.localPosition = maxPullPosition;

            bowString = GetComponent<LineRenderer>();
        }

        private void Update()
        {
            if(Input.GetKey(KeyCode.D)){
                PullString();
            }

            if(Input.GetKeyUp(KeyCode.D)){
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
            if(knockingPoint.localPosition.z > maxPullPosition.z)
                knockingPoint.localPosition = Vector3.Lerp(knockingPoint.localPosition, maxPoint.transform.localPosition, pullSpeed * Time.deltaTime);
        }

        void ReleaseString()
        {
            if(currentArrow!=null){
                ReleaseArrow();
                knockingPoint.localPosition = Vector3.zero;

                if (!isSpawning)
                {
                    isSpawning = true;
                    StartCoroutine(spawnNewArrowDelay());
                }
            }
        }

        public override void PickUp()
        {
            
        }


        private IEnumerator spawnNewArrowDelay(){
            yield return new WaitForSeconds(0.5f);
            SpawnArrow();
            isSpawning = false;
        }



        private void PlaceArrow(Arrow arrow){
            currentArrow = arrow;
        }
        private void ReleaseArrow(){
            currentArrow.transform.SetParent(null,true);
            currentArrow.ApplyForce(calculatePullPower());
           
            
            currentArrow = null;

        }

        private float calculatePullPower(){
            return (knockingPoint.localPosition.z * -1f * releaseForce);
        }

        private void SpawnArrow(){
            GameObject temp = Instantiate(arrowPrefab.gameObject,knockingPoint.localPosition,Quaternion.identity);
            temp.transform.SetParent(knockingPoint, false);
            currentArrow = temp.GetComponent<Arrow>();
        }

        private void updateLineRenderer(){
            bowString.SetPositions(new Vector3[] { topBow.localPosition, knockingPoint.localPosition, botBow.localPosition });
            
        }
    }
}