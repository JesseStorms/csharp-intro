using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerExercise
{
    public abstract class Logger { 
        public abstract void Log(string message);
        public virtual void Close()
        {
            //
        }
    }
    public class StreamLogger : Logger
    {
        private readonly StreamWriter writer;
        public StreamLogger(StreamWriter w)
        {
            writer = w;
        }
        public override void Log(string message)
        {
            this.writer.WriteLine(message);
            this.writer.Flush();
        }
    }
    public class NullLogger : Logger
    {
        public override void Log(string message)
        {
        }
    }

    public class FileLogger : StreamLogger
    {
        private readonly FileStream stream;

        public static Logger Create(string path)
        {
            var fileStream = File.OpenWrite(path);
            return new FileLogger(fileStream);
        }

        public FileLogger(FileStream stream) : base(new StreamWriter(stream))
        {
            this.stream = stream;
        }

        public override void Close()
        {
            this.stream.Close();
        }
    }

    public class LogBroadcaster : Logger
    {
        private readonly IList<Logger> loggers;

        public LogBroadcaster(IEnumerable<Logger> loggers)
        {
            this.loggers = loggers.ToList();
        }

        public override void Log(string message)
        {
            foreach (var log in loggers)
            {
                log.Log(message);
            }
        }

        public override void Close()
        {
            foreach (var log in loggers)
            {
                log.Close();
            }
        }
    }

}
