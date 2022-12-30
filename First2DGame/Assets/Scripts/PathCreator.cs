using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace sadefai
{
    public class PathCreator : MonoBehaviour
    {
        [SerializeField] private GameObject[] checkpoints;
        // Start is called before the first frame update
        void Start()
        {

            
        }

        // Update is called once per frame
        void Update()
        {

        }

        public Vector3 getPositionOfCheckpoint()
        {
            print(checkpoints[0].transform.position);
            return checkpoints[0].transform.position;
        }
    }
}
