using Godot;
using System;

public partial class PlayerV1 : CharacterBody2D
{

    float speed = 5.0f;
    float size = 32;

    float max_x = 1280;
    float max_y = 800;
    public override void _PhysicsProcess(double delta)
    {
        
        
        var curPosion = this.Position;
        var offset = new Vector2(0, 0);

        if (Input.IsActionPressed("ui_left"))
        {
            offset += new Vector2(-1.0f , 0);

        }
        if (Input.IsActionPressed("ui_right"))
        {
            offset += new Vector2(1.0f, 0);
        }
        if (Input.IsActionPressed("ui_up"))
        {
            offset += new Vector2(0,-1.0f);
        }
        if (Input.IsActionPressed("ui_down"))
        {
            offset += new Vector2(0, 1.0f);
        }


        curPosion += offset * (float)speed;
        if(curPosion.X - size < 0)
        {
            curPosion.X = size;
        }

        if(curPosion.X + size > max_x)
        {
            curPosion.X = max_x - size;
        }

        if(curPosion.Y - size < 0)
        {
            curPosion.Y = size;

        }

        if(curPosion.Y + size > max_y)
        {
            curPosion.Y = max_y - size;
        }

        

        this.Position = curPosion;

        

    }
}
