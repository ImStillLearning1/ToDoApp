using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ToDoApp.DbContexts;
using ToDoApp.Handlers;
using ToDoApp.Models;
using ToDoApp.Models.Dtos;
using ToDoApp.Repository;

namespace ToDoApp.Services
{
    public class BackgroundSendingEmail : BackgroundService
    {
        private readonly ILogger<BackgroundSendingEmail> _logger;
        private readonly PeriodicTimer _timer;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private IMapper _mapper;
        public BackgroundSendingEmail(ILogger<BackgroundSendingEmail> logger, IServiceScopeFactory serviceScopeFactory, IMapper mapper) 
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
            _mapper = mapper;
            _timer = new(TimeSpan.FromSeconds(this.RecalculateDelay()));
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed background Service is starting");
            
            while(await _timer.WaitForNextTickAsync(stoppingToken) && !stoppingToken.IsCancellationRequested)
            {
                await DoWorkAsync();
            }
        }

        private async Task DoWorkAsync()
        {
            int tickDelay = RecalculateDelay();
            _logger.LogInformation("Timed Background Service is working");
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var myScopedService = scope.ServiceProvider.GetService<AppDbContext>();
                var tomorrowDate = DateTime.Now.AddDays(1);
                List<Event> events = await myScopedService.Events.Include(x => x.User).Where(x => x.ReminderSent == false && x.DateOfOccurence.Day == tomorrowDate.Day).ToListAsync();

                foreach (Event eventItem in events)
                {
                    try
                    {
                        string subject = "Przypomnienie o wydarzeniu: " + eventItem.Title;
                        string body = "Cześć " + eventItem.User.FirstName + "<br/>";
                        body += "Chcielibyśmy Cię poinformować o wydarzeniu: " + eventItem.Title + "<br/>";
                        body += "Opis wydarzenia: " + eventItem.Description + "<br/>";
                        body += "Data wydarzenia: " + eventItem.DateOfOccurence + "<br/>";
                        SendEmail.Email("mateusz.expand@gmail.com", subject, body);

                        _logger.LogInformation("The email has been sent for Event ID: " + eventItem.EventId);
                        eventItem.ReminderSent = true;
                        myScopedService.Update(eventItem);
                        var result = myScopedService.SaveChanges();
                        _logger.LogInformation("The update has been completed");
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError("Something goes wrong, check the configuration: " + ex.ToString());
                    }
                }
            }

            await Task.Delay(tickDelay);
        }

        private int RecalculateDelay()
        {
            DateTime nowTime = DateTime.Now;
            DateTime eightAmTime = new DateTime(nowTime.Year, nowTime.Month, nowTime.Day, 8, 0, 0, 0);
            if (nowTime > eightAmTime)
                eightAmTime = eightAmTime.AddDays(1);

            int tickTime = (int)(eightAmTime - nowTime).TotalSeconds;
            return tickTime;
        }

        public void Dispose()
        {
            _timer.Dispose();
        }


    }
}
