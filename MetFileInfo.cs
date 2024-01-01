using System.Collections.Generic;
using System.IO;

namespace ShadowMET
{
    public class MetFileInfo
    {
        public FileInfo FileInfo;
        public string ImageName;
        public byte Parameter; //Size of image? 3 = 128 5 = 256?

        public List<MetCharInfo> CharInfos = new List<MetCharInfo>();
    }
}