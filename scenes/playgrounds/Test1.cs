using Godot;
using HelpMe;
using HelpMe.service;
using Microsoft.Extensions.DependencyInjection;
using System;

public partial class Test1 : Node2D
{

    SceneService sceneModel;

    public override void _Ready()
    {
        //base._Ready();

        sceneModel = Application.Service.GetService<SceneService>();


        sceneModel.AddCharacter(0,this.GetNode("Player"));
        sceneModel.AddCharacter(1,this.GetNode("Enemy1"));

    }


}
