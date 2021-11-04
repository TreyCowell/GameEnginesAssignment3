using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceCubeCommand : ICommand
{
    Vector3 position;
    Color color;
    Transform cube;

    public PlaceCubeCommand(Vector3 position, Color color, Transform cube)
    {
        this.position = position;
        this.color = color;
        this.cube = cube;
    }
    
    public void Execute()
    {
        CubePlacer.PlaceCube(position, color, cube);
    }

    public void Undo()
    {
        CubePlacer.RemoveCube(position, color);
    }

    //Lab7
    public override string ToString()
    {
        return "ShapeLocationX:" + position.x + "\nShapeLocationZ:" + position.z + "\nRedColAmount:" + color.r + "\nGreenColAmount: " + color.g + "\nBlueColAmount:" + color.b + "\n\n";
    }
}
