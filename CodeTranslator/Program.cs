using System;
using System.Collections.Generic;

namespace CodeTranslator
{

    class CodeSnippet
    {
        protected string cSharp;
        protected string Python;
        protected List<string> PythonSplit;

        public CodeSnippet(string cS, string Py)
        {
            cSharp = cS;
            Python = Py;
        }

        public string getPython()
        {
            return Python;
        }

        public string getCSharp()
        {
            return cSharp;
        }
        
        public void checkForEquals()
        {
            try
            {
                PythonSplit.AddRange(Python.Split('='));
                foreach(string s in PythonSplit)
                {
                    s.Trim();
                }
            }
            catch
            {
                PythonSplit.Add(Python);
            }
              

        }


    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            List<string> AllLines = new List<string>();

            AllLines.Add("print(\"Hello World\")");
            AllLines.Add("print(\"My name is Adam\")");
            AllLines.Add("x = input()");

            List<CodeSnippet> Comparator = new List<CodeSnippet>();

            Comparator.Add(new CodeSnippet("Console.WriteLine", "print"));
            Comparator.Add(new CodeSnippet("Console.ReadLine", "input"));

            foreach(string line in AllLines)
            {
                foreach(CodeSnippet snippet in Comparator)
                {
                    Console.WriteLine("in");
                    int len = snippet.getPython().Length;
                    bool alike = true;
                    for(int a = 0; a < len; a++)
                    {
                        Console.WriteLine(line[a]); //test
                        Console.WriteLine(snippet.getPython()[a]); //test
                        if(line[a] == snippet.getPython()[a])
                        {
                            Console.WriteLine("bang on");
                        }
                        else
                        {
                            alike = false;
                            //Console.WriteLine("nope"); //test
                        }
                    }
                    if (alike)
                    {
                        string replacement = snippet.getCSharp();
                        string newLine = string.Concat(replacement, line.Substring(len));
                        Console.WriteLine(newLine);
                        break;
                    }
                    Console.WriteLine(alike);
                }
            }

        }

    }
}
