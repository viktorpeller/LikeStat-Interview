﻿namespace Peller.Interview.CSharp.LikeStatistics.Parsers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    
    internal class BinaryParser
    {
        private FileStream fileStream;
        private BinaryReader binaryReader;

        internal void Open(string path)
        {
            this.fileStream = File.OpenRead(path);
            this.binaryReader = new BinaryReader(fileStream);
        }

        internal void Close()
        {
            this.binaryReader.Close();
        }

        internal bool HasReachedEnd
        {
            get
            {
                return this.binaryReader.PeekChar() < 0;
            }
        }

        internal Person GetPerson()
        {
            var result = new Person
                             {
                                 LikedPersons = new List<string>()
                             };

            result.Name = this.binaryReader.ReadString();

            var likeCount = this.binaryReader.ReadInt32();
            for (var i = 0; i < likeCount; i++)
            {
                result.LikedPersons.Add(
                    this.binaryReader.ReadString());
            }

            return result;
        }
    } 
}
