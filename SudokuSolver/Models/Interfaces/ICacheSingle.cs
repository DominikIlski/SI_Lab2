namespace SudokuSolver.Models.Interfaces
{
    public interface ICacheSingle<TContent>
    {
        TContent this[int key] { get; set; }
    }
}