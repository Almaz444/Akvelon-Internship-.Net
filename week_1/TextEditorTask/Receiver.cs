using System;
using System.Collections.Generic;
using static TextEditorTask.TextEditor;

namespace TextEditorTask
{
    public class Receiver
    {
        //Receiver - Main Business Logic
        private List<char>[] text;

        public Receiver(List<char>[] text)
        {
            this.text = text;
        }

        public bool IsInserted(CursorCoordinates cursorCoordinates, char symbol)
        {
            if (text.Length > cursorCoordinates.X && text[cursorCoordinates.X] != null)
            {
                text[cursorCoordinates.X].Insert(cursorCoordinates.Y, symbol);
                return true;
            }
            else
                Console.WriteLine("There is no such coordinates.");
                return false;        
        }
        public bool IsDeleted(CursorCoordinates cursorCoordinates)
        {
            bool isValid = IsValid(cursorCoordinates.X);
            if (isValid)
            {
                text[cursorCoordinates.X].RemoveAt(cursorCoordinates.Y);
                return true;
            }
            else
            {
                Console.WriteLine("There is no such coordinate.");
                return false;
            }
        }
        private bool IsValid(int x)
        {
            if (text.Length > x && text[x] != null)
            {
                if (text[x].Count > 0)
                {
                    return true;
                }
                return false;
            }
            return false;
        }
        public Dictionary<int,char> FindChar(CursorCoordinates cursorCoordinates)
        {
            var dictionary = new Dictionary<int, char>();
            char deletedChar;
            bool isValid = IsValid(cursorCoordinates.X);
            if (isValid)
            {
                deletedChar = text[cursorCoordinates.X][cursorCoordinates.Y];
                dictionary.Add(1, deletedChar);
                return dictionary;
            }
            else
            {
                dictionary.Add(0, '?');
                return dictionary;
            }
        }
        public bool MoveCursor(int row, int col)
        {
            if (text.Length > row && text[row] != null)
            {
                if (text[row].Count >= col)
                {
                    return true;
                }
            }
            return false;
        }
        public void DisplayText()
        {
            for (int i = 0; i<text.Length; i++)
            {
                Console.WriteLine(string.Format(i + " Here's the line: ({0}).", string.Join(", ", text[i])));
            }
        }
    }
}
