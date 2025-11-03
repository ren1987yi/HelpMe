using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMe.service
{
    public class SceneService
    {
        Dictionary<int, Node> characters = new Dictionary<int, Node>();
        public SceneService() { }


        public void StartGame()
        {
            // Logic to start the game, e.g., change scenes

            GD.Print("StartGame");

            characters.Clear();
        }



        public void AddCharacter(int id,Node node)
        {
            characters.Add(id,node);
            GD.Print($"add character {node.Name}");
        }

        public float GetCharacterHP(int id)
        {
            if(characters.TryGetValue(id, out var node)){
                return node.Get("HP").AsSingle();
     
            }
            else
            {
                return 0.0f;
            }
        }

        public void OnDead(Node node)
        {
            GD.Print($"SceneService: OnDead {node.Name}");
            // Logic to handle character death, e.g., remove from scene
            var item = characters.FirstOrDefault(kv => kv.Value == node);
            if(item.Value != null)
            {
                characters.Remove(item.Key);
            }
            node.QueueFree();
        }

    }
}
