using Digst.DigitalPost.UtilityLibrary.Memos.Models;

namespace Digst.DigitalPost.UtilityLibrary.Memos.Configuration
{
    public class MemoConfiguration
    {
        public MeMoHeader Header { get; set; }

        public MeMoBody Body { get; set; }

        public int NumberOfMemos { get; set; }

        public string MemoDirectoryName { get; set; }
    }
}