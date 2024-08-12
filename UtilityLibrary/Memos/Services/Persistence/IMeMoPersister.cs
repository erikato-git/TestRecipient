using System.IO;
using Dk.Digst.Digital.Post.Memolib.Container;
using Dk.Digst.Digital.Post.Memolib.Model;

namespace Digst.DigitalPost.UtilityLibrary.Memos.Services.Persistence
{
    public interface IMeMoPersister
    {
        FileStream OpenFile(string fileName);

        FileStream CreateNewFile(string fileName);

        FileStream SaveMemo(Message message);

        void WriteTarEntry(MeMoContainerWriter writer, Message message);
    }
}