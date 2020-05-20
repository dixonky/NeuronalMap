using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronalMap
{
     class NeuronList
     {
          static List<Neuron> _list; // Static List instance

          static NeuronList()
          {
               _list = new List<Neuron>();
          }

          public static void Record(Neuron neuron)
          {
               _list.Add(neuron);
          }

          public static void Display()
          {
               Console.WriteLine("All neurons by ID: ");
               foreach (Neuron value in _list)
               {
                    Console.WriteLine("{0}: {1} ",value.Id, value.Value);
               }
          }

          public static Neuron GetNeuron(int key)
          {
               foreach (Neuron value in _list)
               {
                    if (key == value.Id)
                         return value;
               }
               return null;
          }
     }
}
