using System;
using System.IO;
using System.Linq;

var BoardingPassIDs = File.ReadAllLines("Input.txt").Select(BoardingPass => BoardingPass.Select((Row, Partition) => Row == 'B' | Row == 'R' ? 1024 >> (Partition + 1) : 0).Sum());

var MySeat = BoardingPassIDs.OrderBy(x => x).Where(x => !BoardingPassIDs.Contains(x + 1)).First() + 1;

Console.WriteLine(MySeat);