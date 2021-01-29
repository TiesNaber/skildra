using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace skildravr.interfaces {
    interface ICanAdd<T>  {

        public bool CanAdd(T item);
        
    }
}
