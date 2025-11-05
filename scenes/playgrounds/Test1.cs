using Godot;
using HelpMe;
using HelpMe.service;
using Microsoft.Extensions.DependencyInjection;
using System;

public partial class Test1 : Node2D
{

    SceneService sceneModel;
    string enemyScenePath = @"res://characters/enemy/Enemy1.tscn";
    PackedScene enemyScene;
    Random rnd;
    public override void _Ready()
    {
        //base._Ready();
        rnd = new Random(DateTime.Now.Microsecond);
        sceneModel = Application.Service.GetService<SceneService>();
        sceneModel.GameWinned += Scene_GameWinned;


        enemyScene = GD.Load<PackedScene>(enemyScenePath);


        sceneModel.AddCharacter(0,this.GetNode("Player"));


        
        for(var i = 0;i<1;i++)
        {
            addEnemy("Enemy1");
        }   




        //sceneModel.AddCharacter(1,this.GetNode("Enemy1"));
        //sceneModel.AddCharacter(2, this.GetNode("Enemy2"));
        //sceneModel.AddCharacter(3, this.GetNode("Enemy3"));
        //sceneModel.AddCharacter(4, this.GetNode("Enemy4"));
        //sceneModel.AddCharacter(5, this.GetNode("Enemy5"));
        //sceneModel.AddCharacter(6, this.GetNode("Enemy6"));

    }

    public override void _ExitTree()
    {
        //base._ExitTree();
        sceneModel.GameWinned -= Scene_GameWinned;
    }


    private void Scene_GameWinned(object sender, EventArgs e)
    {
        //throw new NotImplementedException();

        GetTree().CreateTimer(1.0).Timeout += () =>
        {
            //GetTree().ChangeSceneToFile("res://UI/Welcome.tscn");
            GD.Print("Scene_GameWinned call back");
            for (var i = 0; i < sceneModel.SceneLevel * 2; i++)
            {
                addEnemy($"Enemy{i + 1}");
            }
        };

        

    }

    

    public void addEnemy(string name)
    {
        var x = rnd.Next(100);

        var y = sceneModel.SceneLevel * 2;
        


        var enemy = enemyScene.Instantiate() as Enemy1;
        enemy.Name = name;
        enemy.Scale = new Vector2(0.25f, 0.25f);
        enemy.Position = new Vector2(GD.RandRange(200, 1000), GD.RandRange(200, 600));
        enemy.HP = 10 + sceneModel.SceneLevel ;

        if (x <= y)
        {
            enemy.Scale = new Vector2(0.75f, 0.75f);
            enemy.HP = (10 + sceneModel.SceneLevel) * 20;
        }
        

        this.AddChild(enemy);
        
        sceneModel.AddCharacter(enemy.GetHashCode(), enemy);

    }


}
