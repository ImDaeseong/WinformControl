using System;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace WinformControl.Common
{
     public class clsIWavePlayer
     {
         private static clsIWavePlayer selfInstance = null;
         public static clsIWavePlayer getInstance
         {
             get
             {
                 if (selfInstance == null) selfInstance = new clsIWavePlayer();
                 return selfInstance;
             }
         }

         private static IWavePlayer wavePlayer;
         private static VolumeSampleProvider volumeSampleProvider;
         private static WaveFileReader reader;

         public clsIWavePlayer()
         {
             wavePlayer = null;
             volumeSampleProvider = null;
             reader = null;
         }

         ~clsIWavePlayer()
         {
             StopWavePlayer();
         }

         public void StopWavePlayer()
         {
             try
             {
                 if (wavePlayer != null)
                 {
                     if (wavePlayer.PlaybackState == PlaybackState.Playing)
                         wavePlayer.Stop();

                     wavePlayer.Dispose();
                     wavePlayer = null;
                 }

                 if (volumeSampleProvider != null)
                     volumeSampleProvider = null;

                 if (reader != null)
                 {
                     reader.Dispose();
                     reader.Close();
                     reader = null;
                 }
             }
             catch (Exception ex)
             {
                 wavePlayer = null;
                 volumeSampleProvider = null;
                 reader = null;

                 string sMsg = ex.Message.ToString();
             }
         }


         public void playAlamSound(float volumn, string SoundIndex)
         {
             StopWavePlayer();

             try
             {
                 String mp3Path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\WinformControl\\alert" + SoundIndex + ".wav";
                 wavePlayer = new WaveOut();
                 reader = new WaveFileReader(mp3Path);
                 volumeSampleProvider = new VolumeSampleProvider(reader.ToSampleProvider());
                 wavePlayer.Init(volumeSampleProvider);
                 wavePlayer.Volume = volumn;
                 wavePlayer.Play();
             }
             catch (Exception ex)
             {
                 string sMsg = ex.Message.ToString();
             }
         }

         public void volumnSlider_PreviewMouseUp(float volumn, string SelectedIndex)
         {
             StopWavePlayer();

             try
             {
                 String mp3Path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\WinformControl\\alert" + SelectedIndex + ".wav";
                 wavePlayer = new WaveOut();
                 reader = new WaveFileReader(mp3Path);
                 volumeSampleProvider = new VolumeSampleProvider(reader.ToSampleProvider());
                 volumeSampleProvider.Volume = volumn;
                 wavePlayer.Init(volumeSampleProvider);
                 wavePlayer.Play();
             }
             catch { }
         }

         public void SoundCombo_SelectionChanged(string SelectedIndex)
         {
             StopWavePlayer();

             try
             {
                 String mp3Path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\WinformControl\\alert" + SelectedIndex + ".wav";
                 wavePlayer = new WaveOut();
                 reader = new WaveFileReader(mp3Path);
                 volumeSampleProvider = new VolumeSampleProvider(reader.ToSampleProvider());
                 wavePlayer.Init(volumeSampleProvider);
                 wavePlayer.Play();
             }
             catch { }
         }
     }

}
