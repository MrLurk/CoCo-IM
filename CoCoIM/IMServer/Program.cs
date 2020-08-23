﻿using SuperSocket.SocketBase;
using SuperSocket.SocketEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Init();
        }

        public static void Init()
        {
            try
            {
                //支持通过配置文件读取对服务启动 
                IBootstrap bootstrap = BootstrapFactory.CreateBootstrap();
                if (!bootstrap.Initialize())
                {
                    Console.WriteLine("初始化失败");
                    Console.ReadKey();
                    return;
                }
                Console.WriteLine("准备启动服务");
                var result = bootstrap.Start();

                foreach (var server in bootstrap.AppServers)
                {
                    if (server.State == ServerState.Running)
                    {
                        Console.WriteLine($"{server.Name}运行中");
                    }
                    else
                    {
                        Console.WriteLine($"{server.Name}启动失败");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}
