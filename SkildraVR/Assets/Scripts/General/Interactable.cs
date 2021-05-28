using System.Collections;
using UnityEngine;

namespace overexcited.vr.general
{
    public class Interactable : MonoBehaviour, IPickupable
    {
        public Transform tf_parent { get; private set; }

        public virtual void Drop()
        {
            throw new System.NotImplementedException();
        }

        public virtual void PickUp()
        {
            throw new System.NotImplementedException();
        }

        protected virtual void TriggerAction()
        {
            throw new System.NotImplementedException();
        }
    }
}