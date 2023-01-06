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

        public List<Vector3> createPath(string currentNodeName, string targetNodeName)
        {
            List<Vector3> path = new List<Vector3>();
            Node currentNode = findNode(currentNodeName);
            Node finalNode = findNode(targetNodeName);
            List<Node> explored = new List<Node>();           
            List<List<Node>> queue =  new List<List<Node>>();
            List<Node> nodePath = new List<Node>();
            Node node;

            if(currentNode == null || finalNode == null)
            {
                print("no path found 1");
                return null;
            }

            if (currentNodeName == targetNodeName)
            {
                print("no path found 2");
                return null;
            }
            
            queue.Add(new List<Node> {currentNode});

            while (queue.Any())
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
            print("no path found 3");
            return null;   
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
    
        public bool isNodeClicked(string clickedNodeName, string checkNodeName )
        {
            Node clickedNode = findNode(clickedNodeName);
            if(clickedNode !=  null)
            {
                if(clickedNodeName == checkNodeName)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}
