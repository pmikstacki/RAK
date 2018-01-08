using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace RAK
{
    public  class Speaker
    {
        public Speaker()
        {
            Speak("Witamy w programie RAK: Rozszerzalnym Asystencie Komputerowym");
        }

        public void Speak(string msg)
        {
            // Initialize a new instance of the SpeechSynthesizer.
            using (SpeechSynthesizer synth = new SpeechSynthesizer())
            {

                // Configure the audio output. 
                synth.SetOutputToDefaultAudioDevice();

                // Speak a string synchronously.
                synth.Speak(msg);
            }
        }
    }
}
