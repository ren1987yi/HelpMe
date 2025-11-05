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
        public event EventHandler GameWinned;
        public event EventHandler GameEnd;


        Dictionary<int, Node> characters = new Dictionary<int, Node>();
        public SceneService() { }


        public bool GameOver
        {
            get;private set;
        }
        
        public int SceneLevel
        {
            get; private set;
        } = 1;




        public void Reset()
        {
            characters.Clear();
            GameOver = false;
            SceneLevel = 1;
        }

        public void EndGame()
        {
            // Logic to end the game, e.g., show game over screen
            GameOver = true;
            GD.Print("EndGame");
        }


        public void StartGame()
        {
            // Logic to start the game, e.g., change scenes
            GameOver = false;
            GD.Print("StartGame");
            SceneLevel = 1;
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
                if(item.Key == 0)
                {
                    GD.Print("Main character is dead! Game Over!");
                    // Additional game over logic can be added here
                    GameOver = true;
                    if(GameEnd != null)
                    {
                        GameEnd.Invoke(this, EventArgs.Empty);
                    }
                }
            }
            node.QueueFree();


            if(characters.Where(kv => kv.Key != 0).Count() == 0)
            {
                GD.Print("All enemies are dead! You win!");
                // Additional win logic can be added here
                //GameOver = true;
                SceneLevel++;
                if (GameWinned != null)
                {
                    GameWinned.Invoke(this, EventArgs.Empty);
                }
            }
        }

    }
}
