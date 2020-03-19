using System;
using System.Threading;
using System.Threading.Tasks;
using Pinger.Models;
using Pinger.Services;
using Pinger.Tools;

namespace Pinger
{
    class Program
    {
        static void Main(string[] args)
        {
            PingChecker pingChecker = new PingChecker();
            pingChecker.LoadSettings();

            while (true)
            {
                Console.Clear();
                ConsoleTool.WriteLineConsoleGreenMessage("Перед вами демоверсия пингера, который позволяет пинговать различные ресурсы посредством соответствующих протоколов подключения. В настоящий момент программа поддерживает обработку протоколов ICMP, TCP, HTTP.");
                ConsoleTool.WriteLineConsoleWhiteMessage("1 - Вывести список проверяемых ресурсов.");
                ConsoleTool.WriteLineConsoleWhiteMessage("2 - Добавить ресурс для проверки.");
                ConsoleTool.WriteLineConsoleWhiteMessage("3 - Удалить ресурс из проверки.");
                ConsoleTool.WriteLineConsoleWhiteMessage("4 - Запустить процесс проверки.");
                ConsoleTool.WriteLineConsoleWhiteMessage("5 - Остановить проверку.");
                ConsoleTool.WriteLineConsoleWhiteMessage("6 - Вывести результаты последней проверки.");
                ConsoleTool.WriteLineConsoleWhiteMessage("7 - Вывести статистику по проверкам текущей сессиии.");
                ConsoleTool.WriteLineConsoleGreenMessage("Любая другая клавиша - завершение работы.");

                var cki = Console.ReadKey();
                Console.WriteLine();
                switch (cki.KeyChar.ToString())
                {
                    case "1":
                        
                        break;
                    case "2":
                        
                        break;
                    case "3":
                        
                        break;
                    case "4":
                        pingChecker.StartAllCheckers();
                        break;
                    case "5":
                        
                        break;
                    case "6":
                        
                        break;
                    case "7":
                        
                        break;
                    default:
                        return;
                }
            }


        }
    }
}
