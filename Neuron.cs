using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronalMap
{
     public class Neuron
     {
          private static int _lastId;
          private static int _totalCount;
          public int Id { get; }
          public string Value { get; set; }
          Dictionary<int, int> connections = new Dictionary<int, int>();

          public Neuron(string val)
          {
               _lastId++;
               _totalCount++;
               Id = _lastId;
               Value = val;
               NeuronList.Record(this);
               Console.WriteLine("Neuron created, Id = {0}", this.Id);
          }

          public void Connect(Neuron other)
          {
               int conStrength = 1;
               try
               {
                    this.connections.Add(other.Id, conStrength);
                    other.connections.Add(this.Id, conStrength);
                    Console.WriteLine("Connections Added: Neuron {0} & Neuron {1}", this.Id, other.Id);
               }
               catch (ArgumentException)
               {
                    Console.WriteLine("That connection already exists, strengthened connection");
                    this.connections[other.Id] += 1;
                    other.connections[this.Id] += 1;
               } 
          }

          public void IncCon(Neuron other)
          {
               try
               {
                    this.connections[other.Id] += 1;
                    other.connections[this.Id] += 1;
               }
               catch (ArgumentException)
               {
                    Console.WriteLine("No such connection");
               }
          }

          public void DecCon(Neuron other)
          {
               try
               {
                    if (this.connections[other.Id] == 0)
                    {
                         Console.WriteLine("Connection is already at 0");
                         return;
                    }    
                    this.connections[other.Id] -= 1;
                    other.connections[this.Id] -= 1;
               }
               catch (ArgumentException)
               {
                    Console.WriteLine("No such connection");
               }
          }

          public void RemoveCon(Neuron other)
          {
               try
               {
                    foreach (KeyValuePair<int, int> kvp in this.connections)
                    {
                         if (other.Id == kvp.Key)
                         {
                              this.connections.Remove(kvp.Key);
                              other.connections.Remove(this.Id);
                         }
                         Console.WriteLine("Connections Removed: Neuron {0} & Neuron {1}", this.Id, other.Id);
                    }
               }
               catch (ArgumentException)
               {
                    Console.WriteLine("No connection found");
               }
               catch(InvalidOperationException)
               {
                    Console.WriteLine("No connections found for Neuron {0}", this.Id);
               }
          }

          public void DisplayConnections()
          {
               foreach (KeyValuePair<int, int> kvp in this.connections)
               {
                    Console.WriteLine("Neuron {0} connected to Neuron {1}, Connection Strength = {2}", this.Id, kvp.Key, kvp.Value);
               }
          }

          ~Neuron()
          {
               foreach (KeyValuePair<int, int> kvp in this.connections)
               {
                    Neuron temp = NeuronList.GetNeuron(kvp.Key);
                    temp.RemoveCon(this);
               }
          }
     }
}
