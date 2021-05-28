using System.Collections;
using UnityEngine;

namespace overexcited.vr.general
{
    public class Interactable : MonoBehaviour, IPickupable
    {
        public Transform tf_parent { get; private set; }

        // Use this for initialization
        private void Start()
        {

        }

        public void Drop()
        {
            throw new System.NotImplementedException();
        }

        public void PickUp()
        {
            throw new System.NotImplementedException();
        }

        private void TriggerAction()
        {
            throw new System.NotImplementedException();
        }
    }
}