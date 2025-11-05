using Godot;
using HelpMe;
using HelpMe.service;
using Microsoft.Extensions.DependencyInjection;
using System;

public partial class Test2 : Node
{
    SceneService scene;

    public override void _Ready()
    {
        //base._Ready();
        scene = Application.Service.GetService<SceneService>();
        scene.GameEnd += Scene_GameEnd;
    }
   
    private void Scene_GameEnd(object sender, EventArgs e)
    {
        //throw new NotImplementedException();

        GetTree().CreateTimer(0.5).Timeout += () =>
        {
            //GetTree().ChangeSceneToFile("res://UI/Welcome.tscn");
            GD.Print("Scene_GameEnd call back");
            GetTree().ChangeSceneToFile("res://UI/Welcome.tscn");
        };
    }

    public override void _ExitTree()
    {
        //base._ExitTree();
        scene.GameEnd -= Scene_GameEnd;
    }

    public override void _Process(double delta)
    {
        //base._Process(delta);

        //if (scene.GameOver)
        //{
        //    GetTree().ChangeSceneToFile("res://UI/Welcome.tscn");
            
        //}

    }


}
