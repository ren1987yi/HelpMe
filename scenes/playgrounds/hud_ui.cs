using Godot;
using HelpMe;
using HelpMe.service;
using Microsoft.Extensions.DependencyInjection;
using System;

public partial class hud_ui : Control
{
    Label playerHP,lbLv,lbMsg;
    SceneService sceneService;
    public override void _Ready()
    {
        //base._Ready();
        playerHP = GetNode<Label>("lbPlayerHP");
        lbLv = GetNode<Label>(nameof(lbLv));
        lbMsg = GetNode<Label>(nameof(lbMsg));
        sceneService = Application.Service.GetService<SceneService>();
        sceneService.GameWinned += SceneService_GameWinned;
        sceneService.GameEnd += SceneService_GameEnd;
    }

    private void SceneService_GameEnd(object sender, EventArgs e)
    {
        //throw new NotImplementedException();
        //lbMsg.Text = "Game Over!";
        setMsgText("Game Over!");
    }

    private void SceneService_GameWinned(object sender, EventArgs e)
    {
        //throw new NotImplementedException();
        
        setMsgText("You Win!");
    }

    private void setMsgText(string msg)
    {
        lbMsg.Text = msg;
        GetTree().CreateTimer(2.0).Timeout += () =>
        {
            lbMsg.Text = "";
        };
    }

    public override void _ExitTree()
    {
        sceneService.GameWinned -= SceneService_GameWinned;
        sceneService.GameEnd -= SceneService_GameEnd;
        base._ExitTree();
    }



    public override void _Process(double delta)
    {
        //base._Process(delta);
        if (playerHP != null)
        {
            playerHP.Text = $"{sceneService.GetCharacterHP(0):f0}" ;
        }

        lbLv.Text = $"Level:{sceneService.SceneLevel}";

    }

}
