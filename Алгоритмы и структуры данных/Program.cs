using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ASD
{
    class Program
    {
        static List<int>[] graph;
        static int[] color;
        static int verticesCount;
        static readonly string input = @"C:\Users\1\Desktop\programming\ASD\input.txt";
        static readonly string output = @"C:\Users\1\Desktop\programming\ASD\output.txt";
        static bool result = true;
        static int Invert(int c)
        {
            return c == 1 ? 2 : 1;
        }

        /*Алгоритм обхода графа в глубину, с раскрашиванием посещенных вершин*/
        static void DFS(int v, int c)
        {
            color[v] = c;

            foreach (var el in graph[v])
            {
                if (color[el] == 0)
                {
                    DFS(el, Invert(c));
                }
                else if (color[el] == c)
                {
                    result = false;
                }
            }
        }
        static void Main()
        {
            /*Разбиваем входящие данные*/
            var info = File.ReadAllText(input).Split('\n'); /*Считываем построчно всё из файла в массив строк*/
            var graphMas = info.Skip(1).ToArray(); /*Получаем список ребер*/
            verticesCount = int.Parse(info[0].Split(' ')[0]); /*Получаем количество вершин*/
            color = new int[verticesCount]; /*Объявляем массив посезенных вершин*/
            graph = new List<int>[verticesCount]; /*Объявляем массив листов, в котором хранится вершина и смежные с ней вершины*/

            /*Объявляем листы, в которых будут храниться смежные вершины*/
            for (int i = 0; i < graph.Length; i++)
                graph[i] = new List<int>();

            foreach (var el in graphMas)
            {
                if (el == "")
                    break;

                var str = el.Split(' ').ToArray();
                var x = Int32.Parse(str[0]) - 1;
                var y = Int32.Parse(str[1]) - 1;

                /*Составляем списки смежности*/
                graph[x].Add(y);
                graph[y].Add(x);
            }

            for (int i = 0; i < graph.Length; i++)
            {
                if (color[i] == 0)
                {
                    DFS(i, 1);
                }
            }
            if (result)
                File.WriteAllText(output, "YES");
            else
                File.WriteAllText(output, "NO");
        }
    }
}