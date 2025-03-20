namespace RubiksCubeSimulator.Commands
{
    public interface IMoveCommand
    {
        void Execute();
        void Undo();
        string GetDescription();
    }
}
