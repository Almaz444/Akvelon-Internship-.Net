using System;
using System.Collections.Generic;

namespace TextEditorTask
{
    class Program
    {
        static void Main(string[] args)
        {
            List<char> line1 = new List<char> { '1', '2' };
            List<char> line2 = new List<char> { 'a', 'b' };
            List<char>[] list = new List<char>[2] { line1, line2};
            
            Receiver receiver = new Receiver(list);
            TextEditor textEditor = new TextEditor(receiver);
            receiver.DisplayText();

            textEditor.MoveCursor(0, 4);
            textEditor.MoveCursor(0, 2);

            textEditor.InsetChar('c');
            receiver.DisplayText();

            textEditor.DeleteChar();
            receiver.DisplayText();

            textEditor.MoveCursor(1,2);
            textEditor.InsetChar('c');

            textEditor.UndoCommand();
            textEditor.UndoCommand();

            textEditor.RedoCommand();
            textEditor.RedoCommand();
            receiver.DisplayText();
           
        }
    }
}
