using System;
using System.IO;
using System.Linq;

var BoardingPassRanks = File.ReadAllLines("Input.txt").Select(BoardingPass => BoardingPass.Select((Row, Partition) => Row == 'B' | Row == 'R' ? 1024 >> (Partition + 1) : 0).Sum());

Console.WriteLine(BoardingPassRanks.Max());