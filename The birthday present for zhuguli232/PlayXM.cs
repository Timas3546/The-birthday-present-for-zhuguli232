using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace The_birthday_present_for_zhuguli232
{
    class PlayXM
    {
        byte[] data;
        public PlayXM(string FileName)
        {
            data = System.IO.File.ReadAllBytes(FileName);
        }
        public PlayXM(byte[] XMData)
        {
            data = XMData;
        }
        internal struct BASSMOD_CONSTANTS
        {
            public const int BASS_MUSIC_LOOP = 4;
            public const int BASS_MUSIC_RAMPS = 2;
            public const int BASS_MUSIC_SURROUND = 512;
            public const int BASS_MUSIC_CALCLEN = 8192;
        }
        public const int BASS_SYNC_END = 2;
        [DllImport("BASSMOD.dll")]
        public static extern int BASSMOD_Init(int device, uint frequency, uint flags);
        [DllImport("BASSMOD.dll", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool BASSMOD_Free();
        [DllImport("BASSMOD.dll")]
        public static extern int BASSMOD_MusicLoad([MarshalAs(UnmanagedType.Bool)] bool mem, [In][MarshalAs(UnmanagedType.LPArray)] byte[] XMfile, uint offset, uint length, uint flags); //Select File to play
        [DllImport("BASSMOD.dll")]
        public static extern int BASSMOD_MusicPlay();
        public void Play()
        {
            BASSMOD_Init(-1, 44100, 0);
            BASSMOD_MusicLoad(true, data, 0, (uint)data.Length, BASSMOD_CONSTANTS.BASS_MUSIC_LOOP | BASSMOD_CONSTANTS.BASS_MUSIC_RAMPS | BASSMOD_CONSTANTS.BASS_MUSIC_SURROUND | BASSMOD_CONSTANTS.BASS_MUSIC_CALCLEN);
            BASSMOD_MusicPlay();
        }
        public void Stop()
        {
            BASSMOD_Free();
        }

    }
}
