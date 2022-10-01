public class StateAttack : StateBase
{
    public StateAttack(StateMachine.StateType machineType, StateMachine machine) : base(machineType, machine)
    {
    }

    public override bool IsExcecuteOK => true;

    public override void Execute()
    {
        
    }

    public override void FixedUpdate()
    {
        
    }

    public override void ForceStop()
    {
        
    }

    public override void MoveNext()
    {
        
    }

    public override StateMachine.StateType Update()
    {
        return MachineType;
    }
}