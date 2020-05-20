using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronalMap
{
     class Program
     {
          static void Main(string[] args)
          {
               Neuron nOne = new Neuron("Kyle");
               Neuron nTwo = new Neuron("Dixon");
               NeuronList.Display();
               nOne.Connect(nTwo);
               nOne.DisplayConnections();
               nTwo.DisplayConnections();
               nTwo.Connect(nOne);
               nOne.DisplayConnections();
               nOne.RemoveCon(nTwo);
               nOne.DisplayConnections();
               nTwo.DisplayConnections();
               Console.ReadLine();
          }
     }
}
