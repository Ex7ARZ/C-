using System;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Text;

namespace testlab4
{
//Класс игрока
//Объявление переменных, используемых в Playerклассе:

//Скрыть   копию кода
//Random randomNumber;

class player
{
    private StringBuilder msg; // MCI Error message
    private StringBuilder returnData; // MCI return data
    private int error;
    private string Pcommand; // String that holds the MCI command
    private ListView playlist; // ListView as a playlist with the song path
    public int NowPlaying { get; set; }
    public bool Paused { get; set; }
    public bool Loop { get; set; }
    public bool Shuffle { get; set; }
}

internal class ListView
{
}

Во-первых, есть объект типа, Randomкоторый возвращает случайное число, которое я использую для режима перемешивания. StringBuilderУстройство MCI использует два s: first ( msg) используется mciGetErrorStringдля получения сообщения для заданного intзначения, которое mciSendStringвозвращается ( mciSendStringвозвращает целочисленное значение, 0 для успешной операции и число для неудачной операции). returnDataиспользуется, когда я ожидаю ответное сообщение (при попытке получить статус: «играет», «приостановлен» и т. д.). Pcommandэто просто строка, которая содержит команду, которую я посылаю через mciSendString. Список ListViewвоспроизведения является очень важной переменной, поскольку он содержит список всех путей к файлам в списке воспроизведения, и я получаю доступ ко всем путям файлов через индекс (0 для первой песни, 1 для второй и т. Д.).NowPlayingсодержит индекс ListViewсписка воспроизведения, который представляет песню, которая играет. Булевы переменные просто используются для просмотра статуса игрока.

DllImport
Скрыть   копию кода
[DllImport("winmm.dll")]
private static extern int mciSendString(string strCommand, 
        StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback);
[DllImport("winmm.dll")]
public static extern int mciGetErrorString(int errCode, 
              StringBuilder errMsg, int buflen);
Вы должны импортировать методы MCI.

Конструктор класса
Скрыть   копию кода
public Player(ListView pl)
{
    randomNumber = new Random();
    playlist = pl;
    NowPlaying = 0;
    Loop = false;
    Shuffle = true;
    Paused= false;
    msg = new StringBuilder(128);
    returnData = new StringBuilder(128);
}
Вы должны передать ссылку на a ListViewпри создании нового класса проигрывателя, и это связь между формой и классом. Все остальные переменные установлены в соответствии с потребностями.

Методы закрытия и открытия
Скрыть   код термоусадочной    копии
public void Close()
{
    Pcommand = "close MediaFile";
    mciSendString(Pcommand, null, 0, IntPtr.Zero);
}


public bool Open(string sFileName)
{
    Close();
    // Try to open as mpegvideo 
    Pcommand = "open \"" + sFileName + 
               "\" type mpegvideo alias MediaFile";
    error = mciSendString(Pcommand, null, 0, IntPtr.Zero);
    if (error != 0)
    {
        // Let MCI deside which file type the song is
        Pcommand = "open \"" + sFileName + 
                   "\" alias MediaFile";
        error = mciSendString(Pcommand, null, 0, IntPtr.Zero);
        if (error == 0)
            return true;
        else
            return false;
    }
    else
        return true;
}
CloseМетод делает ничего особенного, это просто закрывает устройство , которое открыто. Даже если попытаться закрыть уже закрытое устройство, ничего плохого не произойдет.

OpenМетод принимает строку в качестве входного сигнала (аргумента), и он будет пытаться открыть данный путь к файлу. Но сначала он закрывает устройство, просто чтобы быть уверенным, что не будет одновременно запущено две песни. На следующем шаге он пытается открыть файл как тип mpegvideo. mciSendStringМетод возвращает значение 0 для успешной операции и ненулевое значение для неудачной операции. При сбое операции на следующем шаге устройство MCI решает, какой тип файла. Даже если эта операция завершится неудачно, она вернется false. Для всех остальных решений возвращается true.

Метод воспроизведения
Скрыть   копию кода
public bool Play(int track)
{
    if (Open(playlist.Items[track].SubItems[1].MediaTypeNames.Text))
    {
        Pcommand = "play MediaFile";
        error = mciSendString(Pcommand, null, 0, IntPtr.Zero);
        if (error == 0)
        {
            NowPlaying = track;
            return true;
        }
        else
        {
            Close();
            return false;
        }
    }
    else
        return false;
}
PlayМетод принимает целое значение в качестве аргумента , который представляет песню в списке воспроизведения. Он передает путь к файлу песни в Openметод. Если он возвращается true, то операция прошла успешно, и песня была загружена в устройство MCI, иначе она не смогла загрузить песню, и она вернется falseи не будет воспроизводить песню. На следующем шаге он отправляет команду воспроизведения и пытается воспроизвести песню. Если MCI возвращает 0, операция прошла успешно, она устанавливает NowPlayingпеременную в индекс дорожки, которая сейчас воспроизводится, и возвращает 0, в противном случае, если она не возвращает 0, она закрывает устройство, которое было успешно открыто, но не может играть, и возвращается false.

Методы паузы, остановки, возобновления
Скрыть   код термоусадочной    копии
public void Pause()
{
    if (Paused)
    {
        Resume();
        Paused = false;
    }
    else if(IsPlaying())
    {
        Pcommand = "pause MediaFile";
        error = mciSendString(Pcommand, null, 0, IntPtr.Zero);
        Paused = true;
    }
}

public void Stop()
{
    Pcommand = "stop MediaFile";
    error = mciSendString(Pcommand, null, 0, IntPtr.Zero);
    Paused = false;
    Close();
}

public void Resume()
{
    Pcommand = "resume MediaFile";
    error = mciSendString(Pcommand, null, 0, IntPtr.Zero);
}
PauseМетод сначала проверяет, приостановленные переменный true(если это true, то игрок сделал паузу). Затем он вызывает Resumeметод и устанавливает pausedпеременную в false(потому что проигрыватель больше не останавливается). Если игрок не приостановлен, то он проверяет, играет ли игрок (я объясню этот метод через минуту). Если он играет, он останавливает игрока и устанавливает pausedпеременную в true.

StopМетод просто останавливает устройство, устанавливает pausedпеременный false, и закрывает открытое устройство MCI.

ResumeМетод просто продолжает играть , когда игрок находится в режиме паузы, и вызывается только из Pauseметода.

Метод IsPlaying
Скрыть   копию кода
public bool IsPlaying()
{
    Pcommand = "status MediaFile mode";
    error = mciSendString(Pcommand, returnData, 128, IntPtr.Zero);
    if (returnData.Length == 7 && 
              returnData.ToString().Substring(0, 7) == "playing")
        return true;
    else
        return false;
}
}