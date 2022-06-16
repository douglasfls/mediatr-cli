using System.Diagnostics;
using MediatR;

namespace GenericCli.Extensions
{
    public abstract class LoggerWrapper<T> : INotificationHandler<T> where T : INotification
    {

        public Task Handle(T notification, CancellationToken cancellationToken)
        {
            using var meterdRun = new MeteredRun();
            return Execute(notification, cancellationToken);
        }

        public abstract Task Execute(T notification, CancellationToken cancellationToken);
    }

    class MeteredRun : IDisposable
    {
        private Stopwatch _stopWatch;

        public MeteredRun()
        {
            _stopWatch = new Stopwatch();
            _stopWatch.Start();
        }

        void IDisposable.Dispose()
        {
            _stopWatch.Stop();
            Console.WriteLine($"Elapsed {_stopWatch.ElapsedMilliseconds}ms");
        }
    }
}