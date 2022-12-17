

namespace NotesUnitTests
{
    public class NoteTests
    {
        private static string title = "titile";
        private static string body = "body";
        private static string priority = "priority";
        Note note = new Note(title, body, priority);
        [Fact]
        public void TestNoteConstructor()
        {
            Assert.Equal(title, note.Title);
            Assert.Equal(body, note.Body);
            Assert.Equal(priority, note.Priority);
            Assert.True(note.Date is DateTime);
        }
        [Fact]
        public void TestNoteToString()
        {
            Assert.Equal($"{title}\n{priority}\n{body}\n{note.Date}", note.ToString());
        }
        [Fact]
        public void TestNoteCompareTo()
        {
            Assert.True(note.CompareTo(new Note(title, body, priority)) != 0);
        }
    }
}