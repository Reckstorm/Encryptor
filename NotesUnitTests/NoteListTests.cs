using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesUnitTests
{
    public class NoteListTests
    {
        private static string title = "titile";
        private static string body = "body";
        private static string priority = "priority";
        Note note = new Note(title, body, priority);
        NoteList noteList = new NoteList();
        [Fact]
        public void TestNoteListFindPriority()
        {
            noteList.Add(note);
            Assert.Equal(noteList.Count, noteList.FindPriority(note.Priority).Count);
        }
        [Fact]
        public void TestNoteListFindDuplicates() 
        {
            noteList.Add(note);
            Assert.Equal(noteList.Count, noteList.FindDuplicates(note.Title).Count);
        }
        [Fact]
        public void TestNoteListFindIndexByTitle() 
        {
            noteList.Add(note);
            Assert.Equal(noteList.FindIndexByTitle(note.Title), 0);
        }
        [Fact]
        public void TestNoteListRemoveByTitle()
        {
            noteList.Add(note);
            Assert.True(noteList.RemoveByTitle(note.Title));
        }
        [Fact]
        public void TestNoteListToString()
        {
            noteList.Add(note);
            Assert.Equal(noteList.ToString(), note.ToString()+"\n");
        }
    }
}
