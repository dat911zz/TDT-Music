using Google.Cloud.Firestore;
using System.Collections.Generic;

namespace TDT.Core.DTO.Firestore
{
    [FirestoreData]
    public class LyricDTO
    {
        private string _encodeId;
        private List<Sentence> _sentences;
        [FirestoreProperty] public List<Sentence> sentences { get => _sentences; set => _sentences = value; }
        [FirestoreProperty] public string encodeId { get => _encodeId; set => _encodeId = value; }
    }

    [FirestoreData]
    public class Sentence
    {
        [FirestoreProperty] public List<Word> words { get; set; }
    }

    [FirestoreData]
    public class Word
    {
        [FirestoreProperty] public string startTime { get; set; }
        [FirestoreProperty] public string endTime { get; set; }
        [FirestoreProperty] public string data { get; set; }
    }
}
