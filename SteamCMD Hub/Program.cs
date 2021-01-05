using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.IO.Compression;
using System.ComponentModel;

namespace SteamCMD_Hub
{
    class Program
    {
        static void Main(string[] args)
        {

            string zipPath = Environment.CurrentDirectory + @"\SteamCMD.zip";
            string folderPath = Environment.CurrentDirectory + @"\SteamCMD";

            DirectoryInfo di = new DirectoryInfo(Environment.CurrentDirectory + @"\SteamCMD");
            if (!di.Exists)
            {
                Console.WriteLine("SteamCMD was not detected on this folder!");
                Console.WriteLine("Would you like do download it now?");
                Console.WriteLine("(Y)es, (N)o");
                string input = Console.ReadLine();
                if (input == "y" ||input == "Y")
                {
                    try
                    {
                        WebClient webClient = new WebClient();
                        webClient.DownloadFile("https://steamcdn-a.akamaihd.net/client/installer/steamcmd.zip", zipPath);
                    }
                    catch (WebException e)
                    {
                        throw;
                    }

                    Console.WriteLine("Downloaded!");
                    Console.WriteLine("Extracting!");
                    try { ZipFile.ExtractToDirectory(zipPath, folderPath); }
                    catch (Exception)  {
                        Console.WriteLine("An error has occured, if you already have a folder called 'SteamCMD', please delete it and try again.");
                        Console.ReadKey();
                    }
                    Console.WriteLine("Extracted");
                    Process steamcmd = new Process();
                    steamcmd.StartInfo.FileName = Environment.CurrentDirectory + @"\SteamCMD\steamcmd.exe";
                    //steamcmd.StartInfo.Arguments = "+runscript steamcmd.script";
                    steamcmd.Start();
                    return;
                }
                else
                {
                    return;
                }
            }

            Console.WriteLine("Hi, welcome to the SteamCMD Hub, made by MMDDKK#6500, How can i help?");
            Console.WriteLine("1. Start SteamCMD with script");
            Console.WriteLine("2. Start SteamCMD Normally");
            Console.WriteLine("3. Start Steam CMD with Steam Guard Support");
            Console.WriteLine("4. Configure script");
            Console.WriteLine("5. Exit");
            Console.WriteLine("Choice:");

            string choice = Console.ReadLine();
            if (choice=="1") {
               Process steamcmd = new Process();
               steamcmd.StartInfo.FileName = Environment.CurrentDirectory + @"\SteamCMD\steamcmd.exe";
               steamcmd.StartInfo.Arguments = "+runscript steamcmd.script";
               steamcmd.Start();
               return;
            }
            else if (choice=="2") {
                Process steamcmd = new Process();
                steamcmd.StartInfo.FileName = Environment.CurrentDirectory + @"\SteamCMD\steamcmd.exe";
                //steamcmd.StartInfo.Arguments = "+runscript steamcmd.script";
                steamcmd.Start();
                return;
            }
            else if (choice == "3")
            {
                Console.WriteLine("What's your username?");
                string name = Console.ReadLine();
                Console.WriteLine("What's your password");
                string pass = Console.ReadLine();
                Console.WriteLine("What's your steam guard pin?");
                string pin = Console.ReadLine();
                Process steamcmd = new Process();
                steamcmd.StartInfo.FileName = Environment.CurrentDirectory + @"\SteamCMD\steamcmd.exe";
                steamcmd.StartInfo.Arguments = "+login " + name + " " + pass + " " +  pin;
                steamcmd.Start();
                return;
            }
            else if (choice=="4")
            {
                Process steamcmd = new Process();
                steamcmd.StartInfo.FileName = "notepad.exe";
                steamcmd.StartInfo.Arguments = Environment.CurrentDirectory + @"\SteamCMD\steamcmd.script";
                steamcmd.Start();
                return;
            }
            else if(choice=="5")
            {
                return;
            }
            else
            {
                Console.WriteLine("That's not an option! >//<");
                Console.ReadKey();
                return;
            }
        }
    }
}
