using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AI_AUTH_JR.Model
{
    public class LastActionSpecific
    {
        public ActionLogin _action;
        public Objects _object;
        public Emotions _emotions;

        public LastActionSpecific(ActionLogin action, Emotions emociones, Objects objects)
        {
            _action = action;
            _object = objects;
            _emotions = emociones;
        }

    }
}
