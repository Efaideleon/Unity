using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEditor.Experimental.GraphView;
//using UnityEditor.Search;
using UnityEngine;
using System.Linq;
using static UnityEngine.RuleTile.TilingRuleOutput;

namespace sadefai
{
    public class Graph : MonoBehaviour
    {
        [SerializeField] private GameObject[] checkpoints;
        
        private List<Node> nodeList;
       
        public void createGraph(Dictionary<string, string> nodes)
        {
            nodeList = new List<Node>();
            string name;
            Vector3 position;
            string neighbors;

            for (int i = 0; i < checkpoints.Length; i++)
            {
                name = checkpoints[i].name;
                position = checkpoints[i].transform.position;
                neighbors = nodes[name];

                nodeList.Add(new Node(name, position, neighbors));
                
            }
        }

        public List<Vector3> createPath(string current, string final)
        {
            if (current == final)
            {
                return new List<Vector3> { findNode(current).Position };
            }

            List<Vector3> path = new List<Vector3>();
            Node currentNode = findNode(current);
            Node finalNode = findNode(final);

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
                    List<Node> neighbors = new List<Node>();
                    foreach(char neighbor in node.Neighbors)
                    {
                        neighbors.Add(findNode(neighbor.ToString()));
                    }
                    foreach(Node neighbor in neighbors)
                    {
                        
                        List<Node> newPath = new List<Node>(nodePath);
                        newPath.Add(neighbor);
                        queue.Add(newPath);

                        if (neighbor.Name == finalNode.Name)
                        {
                            print("shortest path found");
                            foreach(Node node1 in newPath)
                            {
                                path.Add(node1.Position);
                                print(node1.Name);
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

        public Node findNode(string name)
        {
            return nodeList.Find(x => x.Name == name);         
        }

    }
}
