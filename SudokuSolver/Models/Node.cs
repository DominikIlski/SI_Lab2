using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuSolver.Models
{
    class Node
    {
        public List<Node> Children { get; set; }
        public Node? Parent { get; set; }
        public Sudoku CurrentState { get; set; }
        public bool HasAllChildern { get; set; }
        public int AllNodesCount = 0;

        public Node(Sudoku sudoku)
        {
            Children = new List<Node>();
            Parent = null;
            CurrentState = sudoku;
            HasAllChildern = false;
            AllNodesCount++;
        }

        public void AddChild(Node node) => Children.Add(node);

        public void SetParrent(Node node) => Parent = node;
        
    }
}
