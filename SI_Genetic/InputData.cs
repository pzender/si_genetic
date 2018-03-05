using System;
using System.IO;
using System.Linq;

public class InputData
{
	public InputData(string filename)
	{
        streamReader = new StreamReader($"../../../input_files/{filename}");
	}

    public void ReadFile()
    {
        Size = Convert.ToInt32(streamReader.ReadLine());
        streamReader.ReadLine(); //empty line
        Flows = ReadMatrix();
        streamReader.ReadLine(); //empty line
        Distances = ReadMatrix();
    }

    private int[,] ReadMatrix()
    {
        int[,] res= new int[Size, Size];

        for (int i = 0; i < Size; i++)
        {
            string line = streamReader.ReadLine();
            string[] line_split = line.Split();
            line_split = line_split.Where(str => str != "").ToArray();
            
            for (int j = 0; j < Size; j++)
            {
                res[i, j] = Convert.ToInt32(line_split[j]);
            }
        }

        return res;
    }

    StreamReader streamReader;

    public int Size { get; private set; }
    public int[,] Flows { get; private set; }
    public int[,] Distances { get; private set; }
}
