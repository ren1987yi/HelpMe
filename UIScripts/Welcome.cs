using Godot;
using HelpMe.service;
using HelpMe;
using System;
using Microsoft.Extensions.DependencyInjection;

public partial class Welcome : Control
{
    SceneService _sceneService;
    Button btnStart;
    public override void _Ready()
    {

        _sceneService = Application.Service.GetService<SceneService>(); 
        _sceneService.Reset();
        btnStart = GetNode<Button>("btnStart");
        btnStart.Pressed += _on_button_pressed;
    }


    public void _on_button_pressed()
    {
        GD.Print("Start Button Pressed");
        GetTree().ChangeSceneToFile("res://scenes/playgrounds/test2.tscn");

    }
}
