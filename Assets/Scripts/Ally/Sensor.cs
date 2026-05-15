using System.Collections.Generic;
using UnityEngine;


namespace Ally
{
 
    public class Sensor : MonoBehaviour
    {
        [SerializeField] private List<GameObject> detectedObjects;

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.CompareTag("Enemy"))
            {
                detectedObjects.Add(other.gameObject);
            }
        }

        private void OnTriggerExit(Collider other) 
        {
            if(detectedObjects.Contains(other.gameObject))
            {
                detectedObjects.Remove(other.gameObject);
            }
        }
    }

}
