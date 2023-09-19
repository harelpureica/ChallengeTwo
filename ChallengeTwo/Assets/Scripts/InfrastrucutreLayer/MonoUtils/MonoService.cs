using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ChallengeTwo.InfrastrucutreLayer.MonoUtils
{
    //this class is responsible for providing MonoBehaviour functionality for non monoBehaviour scripts .
    public class MonoService:MonoBehaviour
    {
        #region Methods
        //Destroys The given gameObject.
        public void DestroyGameObject(GameObject obj)
        {
            Destroy(obj);
        }
        //instantiate a gameObject.
        public GameObject InstantiateGameObject(GameObject obj)
        {
           return Instantiate(obj);
        }
        //instantiate a gameObject and setting its position and rotation.

        public GameObject InstantiateGameObject(GameObject obj,Vector3 position,Quaternion rotation)
        {
            return Instantiate(obj,position,rotation);
        }
        //instantiate a gameObject and setting its transforms parent.

        public GameObject InstantiateGameObject(GameObject obj, Transform parent)
        {
            return Instantiate(obj,parent);
        }
        #endregion
    }
}
