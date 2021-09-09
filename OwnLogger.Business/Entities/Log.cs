using Microsoft.Extensions.Logging;
using System;

namespace OwnLogger.Business.Entities
{
    public class Log
    {
        public int Id {  get; set; }
        public string Message {  get; set; }
        public DateTime Created { get; set; }
        public LogLevel LogLevel {  get; set; }        
    }
}
