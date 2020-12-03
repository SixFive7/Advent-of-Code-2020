using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


// Read input.
var Map = (from Row in File.ReadAllLines("Input.txt")
           select (from RawTile in Row
                   select new Tile() { Type = (TileType)RawTile }
                  ).ToList()
          ).ToList();

// Create map.
var Rows = Map.Count();
var Colums = Map.First().Count();
for (int Row = 0; Row < Rows; Row++)
{
    for (int Colum = 0; Colum < Colums; Colum++)
    {
        if (Row > 0) { Map[Row][Colum].Above = Map[Row - 1][Colum]; };            // Map tiles above.
        if (Row < Rows - 1) { Map[Row][Colum].Below = Map[Row + 1][Colum]; };     // Map tiles below.
        if (Colum > 0) { Map[Row][Colum].Left = Map[Row][Colum - 1]; };           // Map tiles left.
        if (Colum < Colums - 1) { Map[Row][Colum].Right = Map[Row][Colum + 1]; }; // Map tiles right.
        if (Colum == 0) { Map[Row][Colum].Left = Map[Row][Colums - 1]; };         // Wrap the left edge around.
        if (Colum == Colums - 1) { Map[Row][Colum].Right = Map[Row][0]; };        // Wrap the right edge around.
    }
}

// Print map.
foreach (var Row in Map)
{
    foreach (var Tile in Row)
    {
        Console.Write(Tile);
    }
    Console.WriteLine("");
}


// Count trees en route.
var Position = Map[0][0];
var EncounteredTrees = 0;
do
{
    if (Position.Type == TileType.Tree) { EncounteredTrees++; }
    Position = Position.Right.Right.Right.Below;
} while (Position != null);

Console.WriteLine(EncounteredTrees);


enum TileType
{
    Open = '.',
    Tree = '#',
}
class Tile
{
    internal TileType Type;
    internal Tile Left;
    internal Tile Right;
    internal Tile Above;
    internal Tile Below;

    public override string ToString()
    {
        return Convert.ToChar(Type).ToString();
    }
}