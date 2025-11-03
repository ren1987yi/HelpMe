using Godot;
using HelpMe;
using HelpMe.service;
using Microsoft.Extensions.DependencyInjection;
using System;

public partial class hud_ui : Control
{
    Label playerHP;
    SceneService sceneService;
    public override void _Ready()
    {
        //base._Ready();
        playerHP = GetNode<Label>("lbPlayerHP");

        sceneService = Application.Service.GetService<SceneService>();

    }


    public override void _Process(double delta)
    {
        //base._Process(delta);
        if (playerHP != null)
        {
            playerHP.Text = $"{sceneService.GetCharacterHP(0):f0}" ;
        }
    }

}
