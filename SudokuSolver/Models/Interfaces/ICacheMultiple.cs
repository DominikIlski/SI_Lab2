namespace SudokuSolver.Models.Interfaces
{
    public interface ICacheMultiple<TContent>
    {
        TContent this[int xKey, int yKey] { get; set; }
    }
}