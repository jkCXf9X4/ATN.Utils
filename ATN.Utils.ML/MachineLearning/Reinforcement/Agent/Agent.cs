using ATN.Utils.CollectionsExt.ArrayExt;
using ATN.Utils.MachineLearning.Reinforcement.Base;
using ATN.Utils.MachineLearning.Reinforcement.Memory;
using ATN.Utils.MachineLearning.Reinforcement.Model;
using ATN.Utils.MachineLearning.Reinforcement.ReplayQue;
using ATN.Utils.ObjectExt;
using ATN.Utils.SimpleTypes.EnumExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATN.Utils.MachineLearning.Reinforcement.Agent
{
    public abstract class Agent : IAgent
    {
        protected IReplay replayQue;
        protected IModel model;
        bool IsTraining;
        double epsilon = 0.3;

        Random random = new Random();

        public Agent(IModel model, IReplay replayQue, double epsilon,  bool training )
        {
            this.replayQue = replayQue;
            this.model = model;
            this.epsilon = epsilon;
            this.IsTraining = training;
        }

        public virtual void Remember(IMemory memory)
        {
            replayQue.Enqueue(memory);
        }
        public ModelAction DefaultAction { get; set; }

        /// <summary>
        /// Returns action depending on state
        /// If state is null, default state is returned
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public virtual ModelAction Evaluate(ModelState state)
        {
            if (state == null)
            {
                if (DefaultAction == null)
                {
                    throw new ArgumentNullException("DefaultAction must be set before use");
                }
                return DefaultAction;
            }

            var q_values =  model.Predict(state);

            if (IsTraining && random.NextDouble() < epsilon)
            {
                var max = q_values.actionRaw[0].Max();

                var action = random.Next(0, model.OutputShape);

                q_values.actionRaw[0][action] = max*1.1;
            }

            return q_values;
        }

        public abstract double Replay(int batchSize, int epochs);
    }
}
