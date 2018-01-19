using System;
using ch.wuerth.tobias.ProcessPipeline;

namespace ch.wuerth.tobias.mux.Core.processing
{
    public class ConditionalBranchExecutor : ProcessPipe<dynamic, dynamic>
    {
        public delegate Boolean ConditionCheckEvent(dynamic obj);

        private readonly ConditionCheckEvent _conditionCheckEvent;

        private readonly Procedure _procedure;

        public ConditionalBranchExecutor(ConditionCheckEvent conditionCheckEvent, Procedure procedure)
        {
            _conditionCheckEvent = conditionCheckEvent;
            _procedure = procedure;
        }

        protected override dynamic OnProcess(dynamic obj)
        {
            if (_conditionCheckEvent.Invoke(obj))
            {
                _procedure.Process(obj);
            }
            return obj;
        }
    }
}