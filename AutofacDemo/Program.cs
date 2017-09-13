using System;
using AutofacDemo.MovieFinder;
using FakeAutofac;

namespace AutofacDemo
{
    internal class Program
    {
        private static IContainer _container;
        private static void Main(string[] args)
        {
            InitIoC();

            var lister = _container.Resolve<MPGMovieLister>();

            foreach (var movie in lister.GetMPG())
            {
                Console.WriteLine(movie.Name);
            }
            Console.Read();
        }


        private static void InitIoC()
        {
            var builder = new ContainerBuilder();

            // 注册ListMovieFinder类型，作为接口IMovieFinder的实现
            builder.RegisterType<ListMovieFinder>().AsImplementedInterfaces();

            // 注册DBMovieFinder类型，作为接口IMovieFinder的实现，覆盖ListMovieFinder
            //builder.RegisterType<DBMovieFinder>().AsImplementedInterfaces();

            // 注册MPGMovieLister类型，自动补充构造方法中的参数，通过IMovieFinder的实现创建
            builder.RegisterType<MPGMovieLister>();


            _container = builder.Build();
        }
    }
}
