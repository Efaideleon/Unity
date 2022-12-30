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

        public void getPositionsOfCheckpoints()
        {
            for(int i = 0; i < checkpoints.Length; i++)
            {
                print(checkpoints[i].transform.position); 
            }
            
        }
    }
}
