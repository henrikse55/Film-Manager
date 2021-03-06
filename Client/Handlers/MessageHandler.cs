﻿using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Shared.Network;
using Shared.Enums;
using System.ComponentModel;
using System.IO;

namespace Client.Handler
{
    class MessageHandler
    {
        public List<Message> QueuedMessages = new List<Message>();

        public void QueueMessage(Message message)
        {
            QueuedMessages.Add(message);
        }

        async void init()
        {
            do
            {
               await RunCommand();
               Thread.Sleep(200);
            } while (true);
        }

        async Task RunCommand()
        {
            Message message = getNextInQueue();

            switch (message.Command)
            {
                case MessageIDs.SendMovies:
                    var result = await ReciveMovies(message.args);
                    break;
            }
        }

        Task<DataTable> ReciveMovies(String[] args)
        {
            DataTable table = new DataTable();
            byte[] Bytes = Encoding.ASCII.GetBytes(args[0]);
            MemoryStream stream = new MemoryStream(Bytes);
            table.ReadXml(stream);
            Task.Run(() => { return table; });
            return null;
        }

        Message getNextInQueue()
        {
            return QueuedMessages.First();
        }
    }
}
