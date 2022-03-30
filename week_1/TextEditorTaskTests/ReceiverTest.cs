using System.Collections.Generic;
using TextEditorTask;
using Xunit;
using static TextEditorTask.TextEditor;

namespace TextEditorTaskTests
{
    public class ReceiverTest
    {
        [Fact]
        public void IsInserted_InsertChar3WithAcceptableCoordinates_ReturnTrue()
        {
            // arrange
            List<char> line1 = new List<char> { '1', '2' };
            List<char>[] list = new List<char>[1] { line1 };
            Receiver receiver = new Receiver(list);
            CursorCoordinates cursorCoordinates = new CursorCoordinates();
            bool result = true;

            // act
            bool action = receiver.IsInserted(cursorCoordinates, '3');

            // assert
            Assert.Equal(result, action);
        }

        [Fact]
        public void IsInserted_InsertChar3WithOutOfRangeIndex_ReturnFalse()
        {
            // arrange
            List<char> line1 = new List<char> { '1', '2' };
            List<char>[] list = new List<char>[1] { line1 };
            Receiver receiver = new Receiver(list);
            CursorCoordinates cursorCoordinates = new CursorCoordinates();
            cursorCoordinates.X = 5;
            bool result = false;

            // act
            bool action = receiver.IsInserted(cursorCoordinates, '3');

            // assert
            Assert.Equal(result, action);
        }

        [Fact]
        public void IsDeleted_DeleteChar_ReturnTrue()
        {
            // arrange
            List<char> line1 = new List<char> { '1', '2' };
            List<char>[] list = new List<char>[1] { line1 };
            Receiver receiver = new Receiver(list);
            CursorCoordinates cursorCoordinates = new CursorCoordinates();
            bool result = true;

            // act
            bool action = receiver.IsDeleted(cursorCoordinates);

            // assert
            Assert.Equal(result, action);
        }
        

    }
}
