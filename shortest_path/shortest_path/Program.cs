using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shortest_path
{
    class Program
    { // A utility function to find the 
      // vertex with minimum distance 
      // value, from the set of vertices 
      // not yet included in shortest 
      // path tree 
        private static readonly int NO_PARENT = -1;

        // Function that implements Dijkstra's 
        // single source shortest path 
        // algorithm for a graph represented 
        // using adjacency matrix 
        // representation 
        private static void dijkstra(int[,] adjacencyMatrix, int startVertex, int endVertex)
        {
            int nVertices = adjacencyMatrix.GetLength(0);

            // shortestDistances[i] will hold the 
            // shortest distance from src to i 
            int[] shortestDistances = new int[nVertices];

            // added[i] will true if vertex i is 
            // included / in shortest path tree 
            // or shortest distance from src to 
            // i is finalized 
            bool[] added = new bool[nVertices];

            // Initialize all distances as 
            // INFINITE and added[] as false 
            for (int vertexIndex = 0; vertexIndex < nVertices; vertexIndex++)
            {
                shortestDistances[vertexIndex] = int.MaxValue;
                added[vertexIndex] = false;
            }

            // Distance of source vertex from 
            // itself is always 0 
            shortestDistances[startVertex] = 0;

            // Parent array to store shortest 
            // path tree 
            int[] parents = new int[nVertices];

            // The starting vertex does not 
            // have a parent 
            parents[startVertex] = NO_PARENT;

            // Find shortest path for all 
            // vertices 
            for (int i = 1; i < nVertices-2; i++)
            {

                // Pick the minimum distance vertex 
                // from the set of vertices not yet 
                // processed. nearestVertex is 
                // always equal to startNode in 
                // first iteration.
                int nearestVertex = -1;
                int shortestDistance = int.MaxValue;
                for (int vertexIndex = 0; vertexIndex < nVertices; vertexIndex++)
                {
                    if (!added[vertexIndex] && shortestDistances[vertexIndex] < shortestDistance)
                    {
                        nearestVertex = vertexIndex;
                        shortestDistance = shortestDistances[vertexIndex];
                    }
                }

                // Mark the picked vertex as 
                // processed 
                added[nearestVertex] = true;

                // Update dist value of the 
                // adjacent vertices of the 
                // picked vertex. 
                for (int vertexIndex = 0; vertexIndex < nVertices; vertexIndex++)
                {
                    int edgeDistance = adjacencyMatrix[nearestVertex, vertexIndex];

                    if (edgeDistance > 0 && ((shortestDistance + edgeDistance) < shortestDistances[vertexIndex]))
                    {
                        parents[vertexIndex] = nearestVertex;
                        shortestDistances[vertexIndex] = shortestDistance + edgeDistance;
                    }
                }
            }

            printSolution(startVertex, endVertex, shortestDistances, parents);
        }

        // A utility function to print 
        // the constructed distances 
        // array and shortest paths 
        private static void printSolution(int startVertex, int endVertex, int[] distances, int[] parents)
        {
            int nVertices = distances.Length;
            Console.Write("The Shortest Path is ");

            for (int vertexIndex = endVertex; vertexIndex <= endVertex; vertexIndex++)
            {
                if (vertexIndex != startVertex)
                {
                    printPath(startVertex, vertexIndex, parents);
                    Console.Write(" with total distance of "+distances[vertexIndex]+".");
                }
            }
        }

        // Function to print shortest path 
        // from source to currentVertex 
        // using parents array 
        private static void printPath(int startVertex,int currentVertex, int[] parents)
        {

            // Base case : Source node has 
            // been processed 
            if (currentVertex == NO_PARENT)
            {
                return;
            }
            printPath(startVertex, parents[currentVertex], parents);
            if (currentVertex != startVertex)
            {
                Console.Write("-->");
            }
            Console.Write(currentVertex+1);
        }

        // Driver Code 
        public static void Main(String[] args)
        {
            /*Console.Write("Enter the totla number of vertices: ");
                  var v = Int32.Parse(Console.ReadLine());
                  int[,] adjacencyMatrix = new int[v, v];
                  for (var i = 0; i < v; i++)
                  {
                      var numList = new string[v];
                      numList = Console.ReadLine().Split();
                      for (var j = 0; j < v; j++)
                      {
                         adjacencyMatrix[i, j] = Convert.ToInt32(numList[j]);
                      }
                  }*/
            int[,] adjacencyMatrix = { { 0, 2, 4, 0 },
                                      { 2, 0, 0, 3 },
                                      { 4, 0, 0, 5 },
                                      { 0, 3, 5, 0 } };
            /*int[,] adjacencyMatrix = { { 0, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                      { 1, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0 },
                                      { 2, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                      { 0, 0, 1, 0, 0, 2, 0, 0, 0, 0, 0, 8, 0 },
                                      { 0, 3, 0, 0, 0, 1, 0, 0, 4, 0, 0, 0, 0 },
                                      { 0, 0, 0, 2, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
                                      { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                      { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                      { 0, 0, 0, 0, 4, 0, 0, 0, 0, 1, 0, 3, 0 },
                                      { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 3 },
                                      { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                      { 0, 0, 0, 8, 0, 0, 0, 0, 3, 0, 0, 0, 2 },
                                      { 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 2, 0 } };*/
            Console.Write("Enter Source node :");
            var Source = Int32.Parse(Console.ReadLine());
            Console.Write("Enter Destination node :");
            var Destination = Int32.Parse(Console.ReadLine());
            dijkstra(adjacencyMatrix, Source-1, Destination-1);
            Console.ReadKey();
        }
    }
}
