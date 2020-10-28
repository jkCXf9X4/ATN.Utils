
using ATN.Utils.MachineLearning.Reinforcement.Agent;
using ATN.Utils.MachineLearning.Reinforcement.Base;
using ATN.Utils.MachineLearning.Reinforcement.Environment;
using ATN.Utils.MachineLearning.Reinforcement.Memory;
using ATN.Utils.MachineLearning.Reinforcement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATN.Utils.MachineLearning.Reinforcement.Episode
{

    public class Episode
    {
        IEnvironment environment;
        IAgent agent;

        public event EventHandler<EpisodeStepEvent> NewStep;
        protected virtual void OnStepEvent(EpisodeStepEvent stepEvent)
        {
            EventHandler<EpisodeStepEvent> handler = NewStep;
            handler?.Invoke(this, stepEvent);
        }

        public event EventHandler RunCompleted;

        protected virtual void OnRunCompleted(EventArgs e)
        {
            EventHandler handler = RunCompleted;
            handler?.Invoke(this, e);
        }

        public Episode(IEnvironment environment, IAgent agent)
        {
            this.environment = environment;
            this.agent = agent;
        }
        int counter = 0;
        public void Run()
        {
            var state = environment.Reset();

            while (!environment.IsDone)
            {
                counter++;

                ModelAction action = this.agent.Evaluate(state);

                (var reward, var resultingState, var _, var debugInfo) = this.environment.Step(action);

                var memory = new Memory.Memory(state, action, reward, environment.IsDone, resultingState);

                OnStepEvent(new EpisodeStepEvent(memory, debugInfo));

                state = resultingState;
            }
            OnRunCompleted(new EventArgs());
        }
    }
    public class EpisodeStepEvent : EventArgs
    {
        public IMemory Memory { get; set; }
        public object DebugInfo { get; set; }

        public EpisodeStepEvent(IMemory memory)
        {
            this.Memory = memory;
        }

        public EpisodeStepEvent(IMemory memory, object debugInfo) : this(memory)
        {
            this.DebugInfo = debugInfo;
        }
    }
}
