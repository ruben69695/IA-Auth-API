using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AI_AUTH_JR.Model;
using AI_AUTH_JR.Classes;

namespace AI_AUTH_JR.TaskServices
{
    public class SomeTask : Scheduling.IScheduledTask
    {
        public string Schedule => "*/5 * * * *";

        public async Task Invoke(aiAuthdbContext dbContext, CancellationToken cancellationToken)
        {
            aiAuthdbContext _context = dbContext;
            List<Emotions> _emotions = _context.Emotions.ToList();
            List<Objects> _objects = _context.Objects.ToList();
            int numberOfEmotions = new Random().Next(1, 3);

            // Create a new list
            if (Auth.Current == null)
                Auth.Current = new Auth();

            Auth.Current.items.Clear();
            
            // Add the new AuthAction emotions to the static class list
            for(int i = 1; i <= numberOfEmotions; i++)
            {
                Emotions temp = GetRandomEmotion(_emotions);
                AuthAction newaction = new AuthAction { name = temp.Name, description = temp.Description };
                Auth.Current.items.Add(newaction);
            }

            Objects tempObject = GetRandomObjects(_objects);
            AuthAction newActionObject = new AuthAction { name = tempObject.Name, description = tempObject.Description };
            Auth.Current.items.Add(newActionObject);
        }

        private Emotions GetRandomEmotion(List<Emotions> itemlist)
        {
            Random rnd = new Random();
            return itemlist[rnd.Next(0, itemlist.Count)];
        }

        private Objects GetRandomObjects(List<Objects> itemlist)
        {
            Random rnd = new Random();
            return itemlist[rnd.Next(0, itemlist.Count)];
        }
    }
}
