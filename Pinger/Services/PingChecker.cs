using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ninject;
using Ninject.Modules;
using Pinger.Interfaces;
using Pinger.Models;
using Pinger.Util;
using System.Linq;

namespace Pinger.Services
{
    public class PingChecker : IPingChecker
    {
        private IPingerSettings _pingerSettings;

        private IPingerHttp _pingerHttp;
        private IPingerIcmp _pingerIcmp;
        private IPingerTcp _pingerTcp;

        private IPingLogWriter _pingLogWriter;

        private List<Task> tasks;
        private CancellationTokenSource cancelTokenSource;
        private CancellationToken token;
        private int TasksCanceledCount = 0;

        public PingChecker()
        {
            NinjectModule registrations = new NinjectRegistrations();
            var kernel = new StandardKernel(registrations);

            _pingerSettings = kernel.Get<IPingerSettings>();
            _pingerHttp = kernel.Get<IPingerHttp>();
            _pingerIcmp = kernel.Get<IPingerIcmp>();
            _pingerTcp = kernel.Get<IPingerTcp>();
            _pingLogWriter = kernel.Get<IPingLogWriter>();
        }

        public void StartAllCheckers()
        {
            cancelTokenSource = new CancellationTokenSource();
            token = cancelTokenSource.Token;                                

            _pingerSettings.LoadSettings();

            tasks = new List<Task>();

            foreach (var address in _pingerSettings.GetAddresses())
            {
                tasks.Add(new Task(() =>
                {
                    while (true)
                    {
                        if (token.IsCancellationRequested)
                        {
                            Console.WriteLine("Операция завершена: " + address.GetEndPoint());
                            TasksCanceledCount++;
                            CheckForClose();
                            return;
                        }

                        switch (address.GetProtocol())
                        {
                            case "Http":
                                _pingerHttp.CheckConnection(address);
                                break;
                            case "Icmp":
                                _pingerIcmp.CheckConnection(address);
                                break;
                            case "Tcp":
                                _pingerTcp.CheckConnection(address);
                                break;
                        }
                        Console.WriteLine(((IPingerLogSaveble)address).GetSaveLogData());
                        _pingLogWriter.SaveLog(address as IPingerLogSaveble);

                        if (token.IsCancellationRequested)
                        {
                            Console.WriteLine("Операция завершена: " + address.GetEndPoint());
                            TasksCanceledCount++;
                            CheckForClose();
                            return;
                        }
                        Thread.Sleep(address.GetCheckInterval());
                    }
                }));
            }


            foreach (var task in tasks)
            {
                task.Start();
            }            
        }

        public void StopAllCheckers()
        {
            cancelTokenSource.Cancel();
        }

        private void CheckForClose()
        {
            Console.WriteLine($"Завершено {TasksCanceledCount} из {tasks.Count}");
            if (tasks.Count == TasksCanceledCount)
            {
                Console.WriteLine("Все задачи завершены.");
                Console.WriteLine("Приложение закрывается ...");

                Environment.Exit(0);
            }
        }
    }
}
