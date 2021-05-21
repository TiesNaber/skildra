namespace overexcited.vr.general
{   
    public interface IPickupable
    {
        /// <summary>
        /// Pick up this instance
        /// </summary>
        void PickUp();

        /// <summary>
        /// Drops this instance
        /// </summary>
        void Drop();
    }
}