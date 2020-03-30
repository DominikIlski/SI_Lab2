using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuSolver.Models
{
    class Node
    {
        public List<Node> Children { get; set; }
        public Node? Parent { get; set; }
        public Sudoku CurrentSudokuState { get; set; }
        public bool HasAllChildren { get; set; }
        public int AllNodesCount = 0;

        public Node(Sudoku sudoku, Node parent = null)
        {
            Children = new List<Node>();
            Parent = parent;
            CurrentSudokuState = new Sudoku(sudoku);
            HasAllChildren = false;
            AllNodesCount++;
        }

        public void AddChild(Node node) => Children.Add(node);

        public Node(Node other)
        {
            Children = new List<Node>(other.Children);
            Parent = other.Parent;
            CurrentSudokuState = new Sudoku(other.CurrentSudokuState);
            HasAllChildren = other.HasAllChildren;
            AllNodesCount++;
        }
        
    }
}
