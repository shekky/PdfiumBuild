﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PdfiumBuild
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Setting up environment");

            var arguments = Arguments.Parse(args);

            Console.WriteLine("Initializing build environment");

            var env = new Env(arguments);

            env.Setup();

            Console.WriteLine("Finding scripts");

            var scripts = new List<Script>();

            foreach (string directory in Directory.GetDirectories(arguments.Scripts))
            {
                Console.WriteLine($"Found script {Path.GetFileName(directory)}");

                scripts.Add(new Script(env, directory, arguments.Target));
            }

            Console.WriteLine("Executing scripts");

            foreach (var script in scripts)
            {
                script.Execute();
            }
        }
    }
}