using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Activities
{
    public class List
    {
        public class Query : IRequest<List<Activity>> { }

        public class Handler(DataContext context, ILogger<List.Handler> logger) : IRequestHandler<Query, List<Activity>>
        {
            private readonly DataContext _context = context;
            private readonly Microsoft.Extensions.Logging.ILogger<Handler> _logger = logger;

            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                try
                {
                    for (var i = 0; i < 10; i++)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        await Task.Delay(1000, cancellationToken);
                        _logger.LogInformation("Task {i} has completed", i);
                    }
                }
                catch (System.Exception)
                {
                    _logger.LogInformation("Task was cancelled");
                }
                return await _context.Activities.ToListAsync();
            }
        }
    }
}