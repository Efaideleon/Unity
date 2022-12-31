using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Search;
using UnityEngine;
using System.Linq;
using static UnityEngine.RuleTile.TilingRuleOutput;

namespace sadefai
{
    public class PathCreator : MonoBehaviour
    {
        [SerializeField] private GameObject[] checkpoints;
        private List<Vector3> path;
        private int col = 5;
        private int row = 5;
        private int count = 0;
        private int index = 0;
        private Vector3 temp;
        private Node A, B, C, D, E, F, G, H, I, J, K, L, M;

        public void createNodes()
        {
            A = new Node(0, checkpoints[0].transform.position);
            B = new Node(1, checkpoints[1].transform.position);
            C = new Node(2, checkpoints[2].transform.position);
            D = new Node(3, checkpoints[3].transform.position);
            E = new Node(4, checkpoints[4].transform.position);
            F = new Node(5, checkpoints[5].transform.position);
            G = new Node(6, checkpoints[6].transform.position);
            H = new Node(7, checkpoints[7].transform.position);
            I = new Node(8, checkpoints[8].transform.position);
            J = new Node(9, checkpoints[9].transform.position);
            K = new Node(10, checkpoints[10].transform.position);
            L = new Node(11, checkpoints[11].transform.position);
            M = new Node(12, checkpoints[12].transform.position);


            A.Neighbors = new List<Node> { B, D };
            B.Neighbors = new List<Node> { A, C, F };
            C.Neighbors = new List<Node> { B, H };
            D.Neighbors = new List<Node> { F, A, I };
            E.Neighbors = new List<Node> { D, F };
            F.Neighbors = new List<Node> { D, H, B, K }; 
            G.Neighbors = new List<Node> { F, H };
            H.Neighbors = new List<Node> { G, C, M };
            I.Neighbors = new List<Node> { K, D };
            J.Neighbors = new List<Node> { D, F };
            K.Neighbors = new List<Node> { I, M, F };
            L.Neighbors = new List<Node> { F, H };
            M.Neighbors = new List<Node> { K, H };
            
            
        }

        public List<Vector3> getPath()
        {
            createNodes();
            path = new List<Vector3>();
            Node currentNode = getStartingNode();
            Node finalNode = I;

            List<Node> explored = new List<Node>();           
            List<List<Node>> queue =  new List<List<Node>>();
            queue.Add(new List<Node> {currentNode});

            List<Node> nodePath = new List<Node>();
            Node node;
            while (queue != null)
            {
                nodePath = queue[0];
                queue.RemoveAt(0);
                node = nodePath.Last();

                if (!explored.Contains(node))
                {
                    List<Node> neighbors = node.Neighbors;
                    foreach(Node neighbor in neighbors)
                    {
                        
                        List<Node> newPath = new List<Node>(nodePath);
                        newPath.Add(neighbor);
                        print("newPath");
                        foreach(Node n in newPath)
                        {
                            print(n.Value);
                        }
                        print("end");
                        queue.Add(newPath);

                        if (neighbor.Value == finalNode.Value)
                        {
                            print("shortest path found");
                            foreach(Node node1 in newPath)
                            {
                                print(node1.Value);
                                print(node1.Position);
                                path.Add(node1.Position);
                                
                            }
                            return path;
                        }
                    }
                    explored.Add(node);
                }

            }
            return path;   
        }

        public float distance(Vector3 currentPosition, Vector3 endPosition)
        {
            Vector3 distance = endPosition - currentPosition;
            return distance.magnitude;
        }

        public Node getStartingNode()
        {
            Node startNode = C;
            return startNode;
        }
    }
}
