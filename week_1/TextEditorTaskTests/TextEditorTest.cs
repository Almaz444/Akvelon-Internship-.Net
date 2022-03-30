using System.Collections.Generic;
using TextEditorTask;
using Xunit;

namespace TextEditorTaskTests
{
    public class TextEditorTest
    {
        [Fact]
        public void DeleteChar__WhenDeletingCharFromListOfTwoChars_ReturnCount1()
        {
            // arrange
            List<char> line1 = new List<char> { '1', '2' };
            List<char>[] list = new List<char>[1] { line1 };
            Receiver receiver = new Receiver(list);
            TextEditor textEditor = new TextEditor(receiver);
            int result = 1;

            // act
            textEditor.DeleteChar();
            int action = list[0].Count; 

            // assert
            Assert.Equal(result, action);
        }

        [Fact]
        public void DeleteChar__WhenDeleteCharAndChooseUndoCommand_InsertBackDeletedChar()
        {
            // arrange
            List<char> line1 = new List<char> { '1', '2' };
            List<char>[] list = new List<char>[1] { line1 };
            Receiver receiver = new Receiver(list);
            TextEditor textEditor = new TextEditor(receiver);
            int result = 2;

            // act
            textEditor.DeleteChar();
            textEditor.UndoCommand();
            int action = list[0].Count;

            // assert
            Assert.Equal(result, action);
        }

        [Fact]
        public void DeleteChar__WhenTryToDeleteCharFromEmptyLine_Return0()
        {
            // arrange
            List<char> line1 = new List<char> { '1', '2' };
            List<char>[] list = new List<char>[1] { line1 };
            Receiver receiver = new Receiver(list);
            TextEditor textEditor = new TextEditor(receiver);
            int result = 0;

            // act
            textEditor.DeleteChar();
            textEditor.DeleteChar();
            textEditor.DeleteChar();
            int action = list[0].Count;

            // assert
            Assert.Equal(result, action);
        }

        [Fact]
        public void InsertChar__InsertCharIntoListOf2CharsAndDoNotMoveCursor_PlaceCharInto0Index()
        {
            // arrange
            List<char> line1 = new List<char> { '1', '2' };
            List<char>[] list = new List<char>[1] { line1 };
            Receiver receiver = new Receiver(list);
            TextEditor textEditor = new TextEditor(receiver);
            var result = 0;

            // act
            textEditor.InsetChar('5');
            var action = list[0].IndexOf('5');

            // assert
            Assert.Equal(result, action);
        }

        [Fact]
        public void InsertChar__MoveCursorToCoordinates01AndInsertChar5_ReturnIndex1AndPlacedAccordingly()
        {
            // arrange
            List<char> line1 = new List<char> { '1', '2' };
            List<char>[] list = new List<char>[1] { line1 };
            Receiver receiver = new Receiver(list);
            TextEditor textEditor = new TextEditor(receiver);
            var result = 1;

            // act
            textEditor.MoveCursor(0, 1);
            textEditor.InsetChar('5');
            var action = list[0].IndexOf('5');

            // assert
            Assert.Equal(result, action);
        }

        [Fact]
        public void InsertChar__InsertChar5AndUndoCommand_ReturnCount2DeletedChar()
        {
            // arrange
            List<char> line1 = new List<char> { '1', '2' };
            List<char>[] list = new List<char>[1] { line1 };
            Receiver receiver = new Receiver(list);
            TextEditor textEditor = new TextEditor(receiver);
            var result = 2;

            // act
            textEditor.InsetChar('5');
            textEditor.UndoCommand();
            var action = list[0].Count;

            // assert
            Assert.Equal(result, action);
        }
        [Fact]
        public void InsertChar__InsertChar5AndUndoCommandRedoCommand_ReturnCount3InsertedAgain()
        {
            // arrange
            List<char> line1 = new List<char> { '1', '2' };
            List<char>[] list = new List<char>[1] { line1 };
            Receiver receiver = new Receiver(list);
            TextEditor textEditor = new TextEditor(receiver);
            var result = 3;

            // act
            textEditor.InsetChar('5');
            textEditor.UndoCommand();
            textEditor.RedoCommand();
            var action = list[0].Count;

            // assert
            Assert.Equal(result, action);
        }

        [Fact]
        public void MoveCursor_WhenCommandExecutedAndInsertingChar5_CharInsertsIntoGivenCoordinates()
        {
            // arrange
            List<char> line1 = new List<char> { '1', '2' };
            List<char>[] list = new List<char>[1] { line1 };
            Receiver receiver = new Receiver(list);
            TextEditor textEditor = new TextEditor(receiver);
            int result = 1;           

            // act
            textEditor.MoveCursor(0,1);
            textEditor.InsetChar('5');
            var action = list[0].IndexOf('5');

            // assert
            Assert.Equal(result, action);
        }

        [Fact]
        public void MoveCursor_WhenCommandExecutedUndoCommandInsertChar_ReturnIndex0CharInsertedAccordingly()
        {
            // arrange
            List<char> line1 = new List<char> { '1', '2' };
            List<char>[] list = new List<char>[1] { line1 };
            Receiver receiver = new Receiver(list);
            TextEditor textEditor = new TextEditor(receiver);
            int result = 0;

            // act
            textEditor.MoveCursor(0, 1);
            textEditor.UndoCommand();
            textEditor.InsetChar('5');
            var action = list[0].IndexOf('5');

            // assert
            Assert.Equal(result, action);
        }
    }
}
