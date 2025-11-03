using Godot;
using System;

public partial class Enemy1 : Node2D
{
    [Export]
    public float Damage { get; set; } = 1.0f;


    [Export]
    public float HP { get; set; } = 1000.0f;

}
