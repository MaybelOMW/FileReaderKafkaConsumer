using System;
using System.Collections.Generic;
using System.Text;

namespace KafkaConsumer.Service
{
    interface IService
    {
        void Start();
        void Stop();
    }
}
