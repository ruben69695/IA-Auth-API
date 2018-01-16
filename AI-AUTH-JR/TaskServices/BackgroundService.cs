using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AI_AUTH_JR.TaskServices
{
    public abstract class BackgroundService : IHostedService, IDisposable
    {
        private Task _executingTask;
        private readonly CancellationTokenSource _stoppingCts = new CancellationTokenSource();

        protected abstract Task ExecuteAsync(CancellationToken cancellationToken);


        public Task StartAsync(CancellationToken cancellationToken)
        {
            // Guardamos la tarea que estamos ejecutando
            _executingTask = ExecuteAsync(_stoppingCts.Token);

            // Si la tarea se ha completado la devolvemos
            if(_executingTask.IsCompleted)
            {
                return _executingTask;
            }

            // De lo contrario se esta ejecutando
            return Task.CompletedTask;
        }

        public virtual async Task StopAsync(CancellationToken cancellationToken)
        {
            // Parada sin haber iniciado
            if(_executingTask == null)
            {
                return;
            }

            try
            {
                // Mandamos una señal de parada a la tarea
                _stoppingCts.Cancel();
            }
            finally
            {
                // Esperamos hasta que la tarea se haya completado
                await Task.WhenAny(_executingTask, Task.Delay(Timeout.Infinite, cancellationToken));
            }
        }

        public void Dispose()
        {
            _stoppingCts.Cancel();
        }
    }
}
