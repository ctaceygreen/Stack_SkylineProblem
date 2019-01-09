using System;
using System.Collections.Generic;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution
{
    public int solution(int[] H)
    {
        // write your code in C# 6.0 with .NET 4.5 (Mono)
        Stack<int> blockStack = new Stack<int>();
        int currentStackHeight = 0;
        int totalBlocks = 0;
        foreach(var height in H)
        {
            while (currentStackHeight != height)
            {
                if (blockStack.Count > 0)
                {
                    if (currentStackHeight == height)
                    {
                        //Still at the correct height so all good
                    }
                    else if (currentStackHeight < height)
                    {
                        //Lower so we need to add a new block to the stack
                        blockStack.Push(height - currentStackHeight);
                        currentStackHeight = height;
                        totalBlocks++;
                    }
                    else
                    {
                        //We are too high so pop until we are equal or lower
                        int removedBlock = blockStack.Pop();
                        currentStackHeight -= removedBlock;
                    }
                }
                else
                {
                    //No blocks so add a block of this height
                    blockStack.Push(height);
                    totalBlocks++;
                    currentStackHeight = height;
                }
            }
        }
        return totalBlocks;

    }
}