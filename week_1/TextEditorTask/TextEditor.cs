using System;
using System.Collections.Generic;
using TextEditorTask.Service;

namespace TextEditorTask
{
    public class TextEditor
    {
        private Stack<IOperation> stackUndo;
        private Stack<IOperation> stackRedo;
        private CursorCoordinates cursorCoordinates;
        private Receiver receiver;

        public TextEditor(Receiver receiver)
        {
            this.receiver = receiver;
            stackUndo = new Stack<IOperation>();
            stackRedo = new Stack<IOperation>();
            cursorCoordinates = new CursorCoordinates();
        }
        public void UndoCommand()
        {
            if (stackUndo.Count <= 0)
            {
                Console.WriteLine("There is no Undo command in history.");
                return;
            }
            Console.WriteLine("This is Undo command");
            stackUndo.Peek().Undo();
            stackRedo.Push(stackUndo.Peek());
            stackUndo.Pop();
        }
        public void RedoCommand()
        {
            if (stackRedo.Count <= 0)
            {
                Console.WriteLine("This is no Redo command in history.");
                return;
            }
            Console.WriteLine("This is Redo command");
            stackRedo.Peek().Redo();
            stackUndo.Push(stackRedo.Peek());
            stackRedo.Pop();
        }
        public void DeleteChar()
        {
            DeleteCharOperation command = new DeleteCharOperation(cursorCoordinates, receiver);
            command.Redo();
            stackUndo.Push(command);
        }
        public void InsetChar(char c)
        {
            InsertCharOperation command = new InsertCharOperation(cursorCoordinates, receiver, c);
            command.Redo();
            stackUndo.Push(command);
        }
        public void MoveCursor(int x, int y)
        {
            if (x < 0 ||y < 0)
            {
                Console.WriteLine("Coordinates must be not below 0. Try again");
            }
            else
            {
                MoveCursorOperation command = new MoveCursorOperation(receiver, cursorCoordinates, x, y);
                command.Redo();
                stackUndo.Push(command);
            }
        }

        public class DeleteCharOperation : IOperation
        {
            private Receiver receiver;
            private readonly CursorCoordinates cursorCoordinates;
            private Dictionary<int, char> deletedChar;
            
            public DeleteCharOperation(CursorCoordinates cursorCoordinates,Receiver receiver)
            {
                this.cursorCoordinates = cursorCoordinates;
                this.receiver = receiver;
                deletedChar = new Dictionary<int, char>();
                
            }
            public void Redo()
            {
                deletedChar = receiver.FindChar(cursorCoordinates);
                bool isDeleted = receiver.IsDeleted(cursorCoordinates);
                if (isDeleted)
                {   
                    Console.WriteLine("Char '{0}' was deleted.", deletedChar[1]);
                }   
                else
                {
                    deletedChar.Clear();
                    Console.WriteLine("Line is empty.");
                }
            }
            public void Undo()
            {
                if (deletedChar.Count > 0)
                    if (deletedChar.ContainsKey(1))
                    {
                        char charInsert = deletedChar[1];
                        bool isInserted = receiver.IsInserted(cursorCoordinates, charInsert);
                        if (isInserted)
                            Console.WriteLine("Char '{0}' was placed back to previous position.", charInsert);
                        else
                            Console.WriteLine("Char was not inserted.Error");
                    }
            }
        }
        public class InsertCharOperation : IOperation
        {
            private readonly Receiver receiver;
            private readonly CursorCoordinates cursorCoordinates;
            private char insertedChar;

            public InsertCharOperation(CursorCoordinates cursorCoordinates,Receiver receiver, char symbol)
            {
                this.cursorCoordinates = cursorCoordinates;
                this.receiver = receiver;
                insertedChar = symbol;
            }
            public void Redo()
            {
                bool isInserted =receiver.IsInserted( cursorCoordinates,insertedChar);
                if(isInserted)
                    Console.WriteLine("Char '{0}' was inserted successfully at x = {1}, y = {2}.",insertedChar,cursorCoordinates.X,cursorCoordinates.Y);
                else
                    Console.WriteLine("Char was not inserted. Please check coordinates.");
            }
            public void Undo()
            {
                bool isDeleted = receiver.IsDeleted(cursorCoordinates);
                if (isDeleted)
                {
                    Console.WriteLine("Char was deleted.This is Undo Command");
                }
                else
                {
                    Console.WriteLine("Line is empty.");
                }
            }
        }
        public class MoveCursorOperation : IOperation
        {
            private readonly Receiver receiver;
            private readonly CursorCoordinates cursorCoordinates;
            private int row, column;
            private CursorCoordinates previousCoordinates;

            public MoveCursorOperation(Receiver receiver, CursorCoordinates cursorCoordinates, int row, int column)
            {
                this.receiver = receiver;
                this.cursorCoordinates = cursorCoordinates;
                this.row = row;
                this.column = column;
                previousCoordinates = new CursorCoordinates() { X = cursorCoordinates.X,Y = cursorCoordinates.Y};
            }

            public void Redo()
            {
                bool isMoved = receiver.MoveCursor(row,column);
                if (isMoved)
                {
                    cursorCoordinates.X = row;
                    cursorCoordinates.Y = column;
                    Console.WriteLine("Cursor moved to  x = {0}, y = {1}", cursorCoordinates.X, cursorCoordinates.Y);
                }
                else
                    Console.WriteLine("Please choose correct coordinates.Your current cursor position is at x = {0} and y = {1}", cursorCoordinates.X, cursorCoordinates.Y);
            }
            public void Undo()
            {
                if (previousCoordinates != null)
                {
                    cursorCoordinates.X = previousCoordinates.X;
                    cursorCoordinates.Y = previousCoordinates.Y;
                    Console.WriteLine("Cursor moved back to previous position x = {0}, y = {1}", cursorCoordinates.X, cursorCoordinates.Y);
                }
            }
        }
        public class CursorCoordinates
        {
            public int X { get; set; }
            public int Y { get; set; }

            public CursorCoordinates()
            {
                X = 0;
                Y = 0;
            }
        }
    }
}
 